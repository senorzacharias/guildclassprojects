using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Linq.Helpers
{
    public static class Helper
    {
        public static string ToXml<T>(T obj)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(SerializableDictionary<string, object>));
            SerializableDictionary<string, object> serializableDictionary = new SerializableDictionary<string, object>()
            {
                { "test", obj }
            };

            StringBuilder stringBuilder = new StringBuilder();
            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder))
            {
                xmlSerializer.Serialize(xmlWriter, serializableDictionary);
                return stringBuilder.ToString();
            }
        }

        public static T FromXmlFile<T>(string fileName)
        {
            string fileText = FileLoader.GetExpectedResults(fileName);
            return FromXml<T>(fileText);
        }

        private static T FromXml<T>(string xml)
        {
            using (StringReader stringReader = new StringReader(xml))
            {
                XmlRootAttribute xmlRootAttribute = new XmlRootAttribute
                {
                    ElementName = "dictionary",
                    IsNullable = true
                };

                Type deserializedType = typeof(SerializableDictionary<string, T>);
                XmlSerializer serializer = new XmlSerializer(deserializedType, xmlRootAttribute);
                object deserializedXml = serializer.Deserialize(stringReader);
                SerializableDictionary<string, T> result = deserializedXml as SerializableDictionary<string, T>;
                return result.First().Value;
            }
        }
    }
}
