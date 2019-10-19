using System;
using System.Configuration;

namespace _018ventilation.se.Classes
{
    public class NollartonHelpers
    {
        public static T GetAppSetting<T>(string key)
        {
            var setting = ConfigurationManager.AppSettings[key];
            if (null == setting) return default(T);
            return (T)Convert.ChangeType(setting, typeof(T));
        }
    }
}