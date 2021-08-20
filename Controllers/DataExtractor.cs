using Microsoft.AspNetCore.Mvc;
using data_extractor.Models;
using System.Globalization;
using CsvHelper;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using YamlDotNet.Serialization;
using System;
using Microsoft.Extensions.Logging;

namespace data_extractor.Controllers
{
    public class DataExtractor : Controller
    {
        private readonly ILogger<DataExtractor> _logger;

        public DataExtractor(ILogger<DataExtractor> logger)
        {
            _logger = logger;
        }

        [HttpGet("/extract-data")]
        public void UploadCsvAndDownloadExtractedDataFile()
        {
            IEnumerable<OutputCsvModel> outputRecords;

            // extracting the csv file content into the list of 'InputCsvModel' model object using CsvHelper,
            // and transforming data into the list of 'OutputCsvModel' model object.
            using (StreamReader reader = new StreamReader("docs\\DataExtractor_Example_Input.csv"))
            {
                reader.ReadLine();
                using (CsvReader csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    IEnumerable<InputCsvModel> records = csv.GetRecords<InputCsvModel>();
                    outputRecords = records.Select( x => new OutputCsvModel{
                        ISIN = x.ISIN,
                        CFICode = x.CFICode,
                        Venue = x.Venue,
                        ContractSize = GetPriceMultiplierValue(x.AlgoParams)}
                    ).ToList();
                }
            }

            // storing the extracted data into the output csv file using CsvHelper.
            using (var writer = new StreamWriter("docs\\DataExtractor_Output.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(outputRecords);
            }
        }

        // extracts the value of 'PriceMultiplier' from 'AlgoParams' string
        private string GetPriceMultiplierValue(string algoParams)
        {
            IDeserializer deserializer = new DeserializerBuilder().Build();
            Dictionary<string,string> response = new Dictionary<string, string>();
            try
            {
                response = deserializer.Deserialize<Dictionary<string,string>>(algoParams.Replace("|;", "\n").Replace(":", ": "));
            }
            catch(Exception exception)
            {
                _logger.LogError("string parse error: ", exception);                
            }
            return response["PriceMultiplier"];
        }
    }
}
