namespace ITechArtHW.Models
{
    public class Phone
    {
        public string Model { get; set; }
        public string OperationSystemType { get; set; }
        public string MarketLaunchDate { get; set; }
        public string Price { get; set; }
        public bool IsAvailable { get; set; }
        public int ShopId { get; set; }

        public override string ToString()
        {
            return $"{Model}, with OS: {OperationSystemType}, market launch date: {MarketLaunchDate}, price: {Price}," +
                   $" shop ID {ShopId} ";
        }
    }
}