using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DidiDerDenker.BirdsEyeView.Objects
{
    public class ConfigurationManager
    {
        #region fields
        private static string ConfigurationPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "BirdsEyeView\\Configuration.config");


        private static ConfigurationManager defaultInstance;

        private Configuration configuration;
        #endregion

        #region constructor

        #endregion

        #region public properties
        public static ConfigurationManager Default
        {
            get
            {
                if(null != defaultInstance)
                {
                    defaultInstance = new ConfigurationManager();
                }
                return defaultInstance;
            }
        }

        public Configuration Configuration
        {
            get { return this.configuration; }
            set
            {
                this.configuration = value;
            }
        }
        #endregion

        #region private and protected methods
        //private Configuration LoadConfiguration()
        //{
        //    Configuration config = new Configuration();

        //    return config;

        //}
        #endregion

        #region public methods
        public void WriteConfiguration()
        {
            if (!File.Exists(ConfigurationPath))
            {

            }
        }
        #endregion
    }
}
