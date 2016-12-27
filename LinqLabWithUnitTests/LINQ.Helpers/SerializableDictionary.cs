using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Linq.Helpers
{
    [XmlRoot("dictionary")]
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, IXmlSerializable
    {
        private static readonly Dictionary<string, XmlSerializer> _serializers = new Dictionary<string, XmlSerializer>();
        private static readonly object _deadbolt = new object();

        public void WriteXml(XmlWriter writer)
        {
            // Base types
            string baseKeyType = typeof(TKey).AssemblyQualifiedName;
            string baseValueType = typeof(TValue).AssemblyQualifiedName;
            writer.WriteAttributeString("keyType", baseKeyType);
            writer.WriteAttributeString("valueType", baseValueType);

            foreach (TKey key in this.Keys)
            {
                // Start
                writer.WriteStartElement("item");

                // Key
                Type keyType = key.GetType();
                XmlSerializer keySerializer = GetTypeSerializer(keyType.AssemblyQualifiedName);

                writer.WriteStartElement("key");
                if (keyType != typeof(TKey)) { writer.WriteAttributeString("type", keyType.AssemblyQualifiedName); }
                keySerializer.Serialize(writer, key);
                writer.WriteEndElement();

                // Value
                TValue value = this[key];
                Type valueType = value.GetType();
                XmlSerializer valueSerializer = GetTypeSerializer(valueType.AssemblyQualifiedName);

                writer.WriteStartElement("value");
                if (valueType != typeof(TValue)) { writer.WriteAttributeString("type", valueType.AssemblyQualifiedName); }
                valueSerializer.Serialize(writer, value);
                writer.WriteEndElement();

                // End
                writer.WriteEndElement();
            }
        }

        public void ReadXml(XmlReader reader)
        {
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();

            if (wasEmpty)
            {
                return;
            }

            // Base types
            string baseKeyType = typeof(TKey).AssemblyQualifiedName;
            string baseValueType = typeof(TValue).AssemblyQualifiedName;

            while (reader.NodeType != XmlNodeType.EndElement)
            {
                // Start
                reader.ReadStartElement("item");

                // Key
                XmlSerializer keySerializer = GetTypeSerializer(reader["type"] ?? baseKeyType);
                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();

                // Value
                XmlSerializer valueSerializer = GetTypeSerializer(reader["type"] ?? baseValueType);
                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                reader.ReadEndElement();

                // Store
                this.Add(key, value);

                // End
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }

        XmlSchema IXmlSerializable.GetSchema()
        {
            return null;
        }

        private XmlSerializer GetTypeSerializer(string type)
        {
            if (!_serializers.ContainsKey(type))
            {
                lock (_deadbolt)
                {
                    if (!_serializers.ContainsKey(type))
                    {
                        _serializers.Add(type, new XmlSerializer(Type.GetType(type)));
                    }
                }
            }
            return _serializers[type];
        }
    }
}
