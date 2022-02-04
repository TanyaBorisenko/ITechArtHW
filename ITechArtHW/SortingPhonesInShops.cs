using System.Collections.Generic;
using ITechArtHW.Models;
using Microsoft.Extensions.Logging;

namespace ITechArtHW
{
    public class SortingPhonesInShops
    {
        public void Sort(IList<Shop> shops)
        {
            var logger = LoggerBuilder.GetLogger<Program>();
            int countAvailableIosPhones = 0;
            int countAvailableAndroidPhones = 0;
            foreach (var shop in shops)
            {
                foreach (var phone in shop.Phones)
                {
                    if (phone.IsAvailable && phone.OperationSystemType == "IOS")
                    {
                        countAvailableIosPhones++;
                    }

                    if (phone.IsAvailable && phone.OperationSystemType == "Android")
                    {
                        countAvailableAndroidPhones++;
                    }
                }

                logger.LogDebug($"Shop ID: {shop.Id}, Name: {shop.Name}");
                logger.LogDebug($"Shop description: {shop.Description}");
                logger.LogDebug($"Phones with Android operation system = {countAvailableAndroidPhones} ," +
                                $" phones with IOS operation system = {countAvailableIosPhones}.");
            }
        }
    }
}