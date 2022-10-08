﻿using Microsoft.Extensions.Configuration;


namespace Programmentwurf_6700970.Controllers
{
    public class KonfigurationsLeser : IKonfigurationsLeser
    {
        private readonly IConfiguration _configuration;

        public KonfigurationsLeser(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public string LiesDatenbankVerbindungZurMariaDB()
        {
            return _configuration.GetConnectionString("MariaDB");
        }
    }

    public interface IKonfigurationsLeser
    {
        string LiesDatenbankVerbindungZurMariaDB();
    }
}
