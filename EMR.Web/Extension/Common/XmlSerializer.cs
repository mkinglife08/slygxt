using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace EMR.Web.Extension.Common
{
    /// <summary>
    /// XML序列化
    /// 包括将实体存储为XML文件，将XML转换为实体等操作
    /// </summary>
    public class XmlSerializer
    {
        public static void SaveToXml<T>(string filePath, T t)
        {
            if (!string.IsNullOrWhiteSpace(filePath) && t != null)
            {
                Type type = t.GetType();

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    xmlSerializer.Serialize(writer, t);
                    writer.Flush();
                }
            }
        }

        public static object LoadFromXml(string filePath, Type type)
        {
            object result = null;

            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(type);
                    result = xmlSerializer.Deserialize(reader);
                }
            }

            return result;
        }

        public static T LoadFromXml<T>(string filePath)
        {
            T result = default(T);
            if (File.Exists(filePath))
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    System.Xml.Serialization.XmlSerializer xmlSerializer = new System.Xml.Serialization.XmlSerializer(typeof(T));
                    result = (T)xmlSerializer.Deserialize(reader);
                }
            }
            return result;
        }

        public static string SerializeString<TObject>(TObject obj, Encoding encoding)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TObject));
                serializer.Serialize(ms, obj);

                return encoding.GetString(ms.ToArray());
            }
        }

        public static TObject DeserializeString<TObject>(string content, Encoding encoding)
        {
            using (MemoryStream ms = new MemoryStream(encoding.GetBytes(content)))
            {
                return Deserialize<TObject>(ms);
            }
        }

        public static void Serialize<TObject>(string file, TObject obj)
        {
            using (FileStream fs = File.Open(file, FileMode.Create, FileAccess.Write))
            {
                Serialize<TObject>(fs, obj);
            }
        }

        public static TObject Deserialize<TObject>(string filePath)
        {
            using (FileStream fs = File.OpenRead(filePath))
            {
                return Deserialize<TObject>(fs);
            }
        }

        private static void Serialize<TObject>(Stream s, TObject obj)
        {
            System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(TObject));
            serializer.Serialize(s, obj);
        }

        private static TObject Deserialize<TObject>(Stream s)
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(TObject));
            return (TObject)ser.Deserialize(s);
        }
    }
}