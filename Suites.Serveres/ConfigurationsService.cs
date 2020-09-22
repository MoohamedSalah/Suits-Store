using Suites.DataBase;
using Suites.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suites.Serveres
{
    public class ConfigurationsService
    {
        #region Singleton
        public static ConfigurationsService Instance
        {
            get
            {
                if (instance == null) instance = new ConfigurationsService();

                return instance;
            }
        }
        private static ConfigurationsService instance { get; set; }
        private ConfigurationsService()
        {
        }
        #endregion

        public Config GetConfig(string Key)
        {
            using (var db = new SuitDBContext())
            {
                return db.Configration.Find(Key);
            }
        }
    }
}
