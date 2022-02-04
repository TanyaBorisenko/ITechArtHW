using System.Collections.Generic;

namespace ITechArtHW.Models
{
    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public IList<Phone> Phones { get; set; }

        public override string ToString()
        {
            return $"Phones: {string.Join("\n", Phones)}.\nShop id: {Id}, Name : {Name}, Description: {Description}.";
        }
    }
}