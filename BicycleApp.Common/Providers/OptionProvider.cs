﻿namespace BicycleApp.Common.Providers
{
    using BicycleApp.Common.Providers.Contracts;
    using Microsoft.Extensions.Configuration;

    public class OptionProvider : IOptionProvider
    {
        private readonly IConfiguration _configuration;

        public OptionProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string? ClientDefautPassword()
        {
            return _configuration.GetSection("ClientDefautPassword").Value;
        }       

        public string? EmailAccoutPassword()
        {
            return _configuration.GetSection("Email:Password").Value;
        }

        public string? EmailAccoutUsername()
        {
            return _configuration.GetSection("Email:Sender").Value;
        }
        public string? ClientEmailConfirmEnpoint()
        {
            return _configuration.GetSection("RegisterEmailConfirmEndPoint:Client").Value;
        }

        public string? EmployeeEmailConfirmEnpoint()
        {
            return _configuration.GetSection("RegisterEmailConfirmEndPoint:Employee").Value;
        }

        public string? GetPreviousWorkerPositionName(string currentWorkerPosition)
        {
            var positionFlow = _configuration.GetSection("StandartOrderWorkFlow").GetChildren();

            int currentPossition = 0;

            foreach (var item in positionFlow)
            {               
                if (item.Key.ToLower() == currentWorkerPosition.ToLower())
                {
                    currentPossition = int.Parse(item.Value);
                    break;
                }
            }
            var previousPosition = currentPossition - 1;
            if (previousPosition <= 1)
            {
                return positionFlow.FirstOrDefault(x => int.Parse(x.Value) == 2).Key;
            }

            return positionFlow.FirstOrDefault(x => int.Parse(x.Value) == previousPosition).Key;

        }
    }
}
