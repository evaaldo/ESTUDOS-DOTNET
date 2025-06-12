namespace CONTRACT.API.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ContractBase64 { get; set; }
        public string? Author { get; set; }
        public bool Assigned { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
