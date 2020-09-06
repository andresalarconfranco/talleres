using Javeriana.Pica.ApplicationCore.Interfaces;
using Javeriana.Pica.ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Services
{
    public class DummyService : IAppLogger<BasketService>
    {
        public void LogInformation(string message, params object[] args)
        {
            
        }

        public void LogWarning(string message, params object[] args)
        {
            
        }
    }
}
