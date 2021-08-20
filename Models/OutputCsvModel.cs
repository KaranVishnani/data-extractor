namespace data_extractor.Models
{
    public class OutputCsvModel
    {
       public string ISIN { get; set; }
       public string CFICode { get; set; }
       public string Venue { get; set; }
       public string ContractSize { get; set; }
    }
}
