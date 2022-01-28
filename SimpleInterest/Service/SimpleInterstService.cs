﻿using SimpleInterest.Service.Interface;

namespace SimpleInterest.Service
{
    public class SimpleInterstService : ISimpleInterstService
    {
        public int CalculateSimpleInterest(SimpleInterestModel siInput)
        {
            return (siInput.Principal * siInput.Year * siInput.RateOfInterest) / 100;
        }
    }
}
