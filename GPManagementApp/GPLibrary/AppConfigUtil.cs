using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Reflection;
using System.IO;
using System.Xml;

namespace GPLibrary
{
    public class AppConfigUtil
    {

        public static List<String> ReadAppSettingsConfig(String key, Boolean all, String filePath)
        {
            //string filePath = System.IO.Path.GetFullPath("App.config");
            if (filePath != null)
            {
                AppDomain.CurrentDomain.SetData("APP_CONFIG_FILE", filePath);
            }

            List<String> result = new List<String>();
            if (all)
            {
                foreach (String _key in ConfigurationManager.AppSettings)
                {
                    String value = ConfigurationManager.AppSettings[_key];
                    result.Add(value);
                }
                return result;
            }
            else
            {
                result.Add(ConfigurationManager.AppSettings[key]);
                return result;
            }


        }

        public static Boolean AddConfigure(String key, String value, String filePath)
        {
            Boolean FLAG = false;
            try
            {
                var map = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
                // Open App.Config of executable
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                // Add an Application Setting if not exist

                config.AppSettings.Settings.Add(key, value);
                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                FLAG = true;
            }
            catch (ConfigurationErrorsException ex)
            {
                FLAG = false;
                throw ex;
            }
            return FLAG;
        }

        public static Boolean EditConfigure(String key, String value, String filePath)
        {
            Boolean FLAG = false;
            try
            {
                var map = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
                // Open App.Config of executable
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                // Add an Application Setting if not exist

                config.AppSettings.Settings[key].Value = value;
                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                FLAG = true;
            }
            catch (Exception ex)
            {
                FLAG = false;
                throw ex;
            }

            return FLAG;

        }

        public static Boolean RemoveConfigure(String key, String filePath)
        {
            Boolean FLAG = false;
            try
            {
                var map = new ExeConfigurationFileMap { ExeConfigFilename = filePath };
                // Open App.Config of executable
                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(map, ConfigurationUserLevel.None);

                // Add an Application Setting if not exist

                config.AppSettings.Settings.Remove(key);
                // Save the changes in App.config file.
                config.Save(ConfigurationSaveMode.Modified);

                // Force a reload of a changed section.
                ConfigurationManager.RefreshSection("appSettings");
                FLAG = true;
            }
            catch (Exception ex)
            {
                FLAG = false;
                throw ex;
            }
            return FLAG;
        }
    }
}
