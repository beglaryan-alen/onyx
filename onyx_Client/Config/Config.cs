using Onyx.IO;
using System;
using System.ComponentModel;
using System.IO;

namespace Onyx.Config
{
    public class Config
    {
        public delegate void ConfigChangedHandler();
        public event ConfigChangedHandler ConfigChanged;

        private static string path = "config.onyx";

        private static Config instance;

        private string _lang;
        public string Lang
        {
            get => _lang;  set
            {
                _lang = value;
                ConfigChanged?.Invoke();
            }
        }

        private string _baseUrl;

        public string BaseUrl
        {
            get => _baseUrl;  set
            {
                _baseUrl = value;
                ConfigChanged?.Invoke();
            }
        }
        private string _authUrl;

        public string AuthUrl
        {
            get => _authUrl; set
            {
                _authUrl = value;
                ConfigChanged?.Invoke();
            }
        }


        private Config()
        {
            Lang = "en";
            BaseUrl = "http://localhost:8010";
            AuthUrl = "http://localhost:8002";
        }

        public static Config getConfig()
        {
            if (instance == null)
            {
                instance = new Config();
                //Можно добавить проверку, поэтому bool
                IO.IO.GetInstance<Config>(ref instance, path);
                return instance;
            }

            return instance;
        }
    }
}
