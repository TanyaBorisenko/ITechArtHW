using System;
using System.Collections.Generic;
using System.Linq;
using ITechArtHW.Exceptions;
using ITechArtHW.Models;
using Microsoft.Extensions.Logging;

namespace ITechArtHW
{
    public static class ShopSelection
    {
        public static void ShopInfo(IList<Shop> sortedPhoneShops, string store)
        {
            var logger = LoggerBuilder.GetLogger<Program>();
            var desiredShop = sortedPhoneShops
                .SingleOrDefault(s => s.Name.Equals(store, StringComparison.CurrentCultureIgnoreCase));

            try
            {
                if (desiredShop is null)
                {
                    throw new ShopNameException($"This shop: {store} is not found.");
                }
                else
                {
                    var phone = desiredShop.Phones.SingleOrDefault();
                    logger.LogDebug($"{phone?.Model} ({phone?.OperationSystemType}), price $ {phone?.Price}," +
                                    $"market launch date {phone?.MarketLaunchDate}," +
                                    $"in shop {store} has been successfully placed.");
                }
            }
            catch (ShopNameException)
            {
                Console.WriteLine("Enter shop again:");
                store = Console.ReadLine();
                desiredShop = sortedPhoneShops
                    .SingleOrDefault(s => s.Name.Equals(store, StringComparison.CurrentCultureIgnoreCase));

                if (desiredShop is null)
                {
                    throw new ShopNameException($"This shop: {store} is not found.");
                }
                else
                {
                    var phone = desiredShop.Phones.SingleOrDefault();
                    logger.LogDebug($"{phone?.Model} ({phone?.OperationSystemType}), price $ {phone?.Price}," +
                                    $"market launch date {phone?.MarketLaunchDate}," +
                                    $"in shop {store} has been successfully placed.");
                }
            }
        }
    }
}