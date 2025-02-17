﻿using System;
using Microsoft.Extensions.Logging;

namespace ITechArtHW
{
    public class LoggerBuilder
    {
        private static readonly ILoggerFactory LoggerFactory = Microsoft.Extensions.Logging.LoggerFactory.Create(
            config =>
            {
                config.AddConsole();
                config.AddDebug();
                config.SetMinimumLevel(LogLevel.Debug);
            });

        public static ILogger GetLogger(Type category)
        {
            return LoggerFactory.CreateLogger(category);
        }

        public static ILogger<T> GetLogger<T>()
        {
            return LoggerFactory.CreateLogger<T>();
        }
    }
}