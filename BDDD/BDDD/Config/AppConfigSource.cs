using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace BDDD.Config
{
    public class AppConfigSource : IConfigSource
    {
        private BDDDConfigSection config;

        public AppConfigSource()
        {
            LoadConfig(Constants.DEFALT_CONFIG_SECTION_NAME);
        }

        private void LoadConfig(string configSectionName)
        {
            config = (BDDDConfigSection)ConfigurationManager.GetSection(configSectionName);
        }

        public BDDDConfigSection Config
        {
            get { return config; }
        }
    }
}
