using System;
using System.Collections.Generic;
using System.Text.Json;
using ITechArtHW.Models;
using Microsoft.Extensions.Logging;

namespace ITechArtHW
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = LoggerBuilder.GetLogger<Program>();
            var jsonFile = FileReader.ReadFileProjectRoot("Shops.json");
            var shops = JsonSerializer.Deserialize<IList<Shop>>(jsonFile);

            SortingPhonesInShops sortingPhonesInShops = new SortingPhonesInShops();
            sortingPhonesInShops.Sort(shops);

            logger.LogInformation("Which mobile phone do you want to buy?");
            var phoneModel = Console.ReadLine();

            var sortedPhoneShops = ModelSelection.GetAvailablePhoneShops(shops, phoneModel);

            logger.LogDebug($"In which store do you want to buy the mobile phone {phoneModel}");
            var store = Console.ReadLine();

            ShopSelection.ShopInfo(sortedPhoneShops, store);
        }
    }
}