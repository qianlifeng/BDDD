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

        public BDDDConfigSection Config
        {
            get { return config; }
        }

        private void LoadConfig(string configSectionName)
        {
            config = (BDDDConfigSection) ConfigurationManager.GetSection(configSectionName);
        }
    }
}