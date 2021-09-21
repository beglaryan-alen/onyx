using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Onyx.IO
{
    public static class XmlExt
    {
        public static string ToXML<T>(this T instance)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (MemoryStream ms = new MemoryStream())
                {
                    serializer.Serialize(ms, instance);
                    ms.Position = 0;
                    TextReader reader = new StreamReader(ms);
                    return reader.ReadToEnd();
                }
            }
            catch
            {
                return null;
            }
        }

        public static T FromXml<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (TextReader reader = new StringReader(xml))
                {
                    return (T)serializer.Deserialize(reader);
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
