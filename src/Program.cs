using System;

namespace data_extractor
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting with extraction...");
            DataExtractor dataExtractorObject = new DataExtractor();
            dataExtractorObject.UploadCsvAndDownloadExtractedDataFile();
            Console.WriteLine("Data extraction completed...");
        }
    }
}
