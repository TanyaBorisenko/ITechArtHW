using System;
using System.Collections.Generic;
using System.Linq;
using ITechArtHW.Exceptions;
using ITechArtHW.Models;
using Microsoft.Extensions.Logging;

namespace ITechArtHW
{
    public class ModelSelection
    {
        public static IList<Shop> GetAvailablePhoneShops(IList<Shop> shops, string phoneModel)
        {
            var logger = LoggerBuilder.GetLogger<Program>();
            var availablePhoneShops = new List<Shop>();
            foreach (var shop in shops)
            {
                var existentPhones = shop.Phones
                    .Where(s => s.Model.Equals(phoneModel, StringComparison.CurrentCultureIgnoreCase)).ToList();

                try
                {
                    if (existentPhones.Any())
                    {
                        var availablePhones = existentPhones.Where(ep => ep.IsAvailable).ToList();
                        try
                        {
                            if (!availablePhones.Any())
                            {
                                throw new PhoneModelException("This mobile phone is out of stock.");
                            }
                            else
                            {
                                shop.Phones = availablePhones;
                                availablePhoneShops.Add(shop);
                                logger.LogDebug($"{shop}");
                            }
                        }
                        catch (Exception e)
                        {
                            logger.LogInformation($"Fail: {e.Message}");
                            throw;
                        }
                    }
                    else
                    {
                        throw new PhoneModelException("This mobile phone is not found.");
                    }
                }
                catch (Exception e)
                {
                    logger.LogInformation($"Fail: {e.Message}");
                    throw;
                }
            }

            return availablePhoneShops;
        }
    }
}