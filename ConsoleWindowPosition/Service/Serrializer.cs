using System;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleWindowPosition.Service.Serializer
{
    internal class Config
    {
        private const string defaultName = "Config.xml";
        private readonly string fileName = null;
        private readonly XmlSerializer serializer = new XmlSerializer(typeof(Properties));
        public Properties Properties { get; set; } = new Properties();

        public Config() : this(defaultName) { }

        public Config(string fileName)
        {
            this.fileName = Path.GetFullPath(fileName);
        }

        public bool FileExist => File.Exists(fileName);

        public bool ReadConfig()
        {
            try
            {
                if (FileExist)
                {
                    using (StreamReader streamReader = new StreamReader(fileName))
                    {
                        Properties = serializer.Deserialize(streamReader) as Properties;
                    }
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }

        public void WriteConfig()
        {
            try
            {
                using (StreamWriter streamWriter = new StreamWriter(fileName))
                {
                    serializer.Serialize(streamWriter, Properties);
                }
            }
            catch (Exception) { }
        }
    }
}