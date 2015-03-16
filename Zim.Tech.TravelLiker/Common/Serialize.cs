using System;
using System.IO;
using System.Text;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Runtime.Serialization;

namespace Zim.Tech.TravelLiker.Common
{
    public class XmlNamespace
    {
        public string NameSpace { get; set; }
        public string Url { get; set; }
    }
    public class Serialize<T>
    {
        #region SerializeXmlToString
        /// <summary>
        /// To serialize serializable object to xml format and input into a file
        /// </summary>
        /// <param name="outputFileName">The fullpath of the file that will take in the serialised object in xml format</param>
        /// <param name="objectToSerialize">The object to be serialised into a file/param>
        /// <param name="objectType">The object type</param>
        public static string SerializeXmlToString(T objectToSerialize)
        {
            return SerializeXmlToString(string.Empty, "", objectToSerialize);
            //StringWriter textWriter = new StringWriter();
            //XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            //ns.Add("", "");
            //XmlSerializer sFormatter = new XmlSerializer(typeof(T));

            //sFormatter.Serialize(textWriter, objectToSerialize, ns);

            //return textWriter.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="url"></param>
        /// <param name="objectToSerialize"></param>
        public static string SerializeXmlToString(string nameSpace, string url, T objectToSerialize)
        {
            StringBuilder output = new System.Text.StringBuilder();
            StringWriter textWriter = new StringWriter(output);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            ns.Add(nameSpace, url);
            XmlSerializer sFormatter = new XmlSerializer(typeof(T), url);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            using (XmlWriter stringWriter = XmlWriter.Create(output, settings))
            {
                sFormatter.Serialize(stringWriter, objectToSerialize, ns);
                return output.ToString();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="nameSpace"></param>
        /// <param name="url"></param>
        /// <param name="objectToSerialize"></param>
        public static string SerializeXmlToString(List<XmlNamespace> xmlNamespaces, T objectToSerialize)
        {
            StringBuilder output = new System.Text.StringBuilder();
            StringWriter textWriter = new StringWriter(output);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            foreach (XmlNamespace xNameSpace in xmlNamespaces)
                ns.Add(xNameSpace.NameSpace, xNameSpace.Url);
            XmlSerializer sFormatter = new XmlSerializer(typeof(T), xmlNamespaces[0].Url);

            XmlWriterSettings settings = new XmlWriterSettings();
            settings.OmitXmlDeclaration = true;
            settings.Indent = true;
            using (XmlWriter stringWriter = XmlWriter.Create(output, settings))
            {
                sFormatter.Serialize(stringWriter, objectToSerialize, ns);
                return output.ToString();
            }
        }
        #endregion

        #region SerializeXmlToFile
        /// <summary>
        /// To serialize serializable object to xml format and input into a file
        /// </summary>
        /// <param name="outputFileName">The fullpath of the file that will take in the serialised object in xml format</param>
        /// <param name="objectToSerialize">The object to be serialised into a file/param>
        /// <param name="objectType">The object type</param>
        public static void SerializeXmlToFile(string outputFileName, T objectToSerialize)
        {
            SerializeXmlToFile("", "", outputFileName, objectToSerialize);
        }
        /// <summary>
        /// To serialize serializable object to xml format and input into a file
        /// </summary>
        /// <param name="outputFileName">The fullpath of the file that will take in the serialised object in xml format</param>
        /// <param name="objectToSerialize">The object to be serialised into a file/param>
        /// <param name="objectType">The object type</param>
        public static void SerializeXmlToFile(string nameSpace, string url, string outputFileName, T objectToSerialize)
        {
            Stream stream = File.Open(outputFileName, FileMode.Create);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add(nameSpace, url);
            XmlSerializer sFormatter = new XmlSerializer(typeof(T));
            sFormatter.Serialize(stream, objectToSerialize, ns);
            stream.Close();
        }
        #endregion

        #region DeserializeXmlFromFile
        /// <summary>
        /// To deserialize file containing serialized xml format object back to the object
        /// </summary>
        /// <param name="inputFileName">The fullpath of the file that contains the serialized object in xml format</param>
        /// <returns>The deserialized object</returns>
        public static T DeSerializeXmlFromFile(string inputFileName)
        {
            T objectDeSerialized = default(T);
            try
            {
                if (File.Exists(inputFileName) == true)
                {
                    FileStream fs = new FileStream(inputFileName, FileMode.OpenOrCreate);
                    XmlSerializer sFormatter = new XmlSerializer(typeof(T));
                    XmlReader reader = XmlReader.Create(fs);

                    if (sFormatter.CanDeserialize(reader))
                        objectDeSerialized = (T)sFormatter.Deserialize(reader);
                    fs.Close();
                }
            }
            catch (IOException err)
            {

            }
            return objectDeSerialized;
            /*
			T deserializedObject = default(T);
			TextReader textReader = null;
			TextWriter textWriter = null;
			Stream stream = null;

			if (File.Exists(inputFileName))
			{
				try
				{
					textReader = new StreamReader(inputFileName, Encoding.UTF8);
					textWriter = new StreamWriter(inputFileName + ".txt", false, Encoding.UTF8);
					textWriter.Write(textReader.ReadToEnd());
					textWriter.Close();
					textReader.Close();
					textReader = new StreamReader(inputFileName + ".txt", Encoding.UTF8);
					stream = new MemoryStream(Encoding.UTF8.GetBytes(textReader.ReadToEnd()));
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					//deserializedObject = (T)serializer.Deserialize(textReader);
					deserializedObject = (T)serializer.Deserialize(stream);
					textReader.Close();
					stream.Close();
					File.Delete(inputFileName + ".txt");
				}
				catch (Exception ex)
				{
					//Log.WriteError(ex.Message);
					if (textReader != null)
						textReader.Close();
					if (textWriter != null)
						textWriter.Close();
					if (stream != null)
						stream.Close();
					if (File.Exists(inputFileName + ".txt"))
						File.Delete(inputFileName + ".txt");
				}
			}

			return deserializedObject;
            */
        }

        public static T DeSerializeXmlFromANSIFile(string inputFileName)
        {
            T deserializedObject = default(T);
            TextReader textReader = null;
            TextWriter textWriter = null;
            Stream stream = null;

            if (File.Exists(inputFileName))
            {
                try
                {
                    textReader = new StreamReader(inputFileName, Encoding.Default);
                    textWriter = new StreamWriter(inputFileName + ".txt", false, Encoding.Default);
                    textWriter.Write(textReader.ReadToEnd());
                    textWriter.Close();
                    textReader.Close();
                    textReader = new StreamReader(inputFileName + ".txt", Encoding.Default);
                    stream = new MemoryStream(Encoding.Default.GetBytes(textReader.ReadToEnd()));
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    //deserializedObject = (T)serializer.Deserialize(textReader);
                    deserializedObject = (T)serializer.Deserialize(stream);
                    textReader.Close();
                    stream.Close();
                    File.Delete(inputFileName + ".txt");
                }
                catch (Exception ex)
                {
                    //Log.WriteError(ex.Message);
                    if (textReader != null)
                        textReader.Close();
                    if (textWriter != null)
                        textWriter.Close();
                    if (stream != null)
                        stream.Close();
                    if (File.Exists(inputFileName + ".txt"))
                        File.Delete(inputFileName + ".txt");
                }
            }

            return deserializedObject;
        }
        #endregion


        #region DeserializeXmlFromString
        /// <summary>
        /// To deserialize file containing serialized xml format object back to the object
        /// </summary>
        /// <param name="inputFileName">The fullpath of the file that contains the serialized object in xml format</param>
        /// <returns>The deserialized object</returns>
        public static T DeserializeXmlFromString(string xmlValue)
        {
            T objectDeSerialized = default(T);
            try
            {
                if (string.IsNullOrEmpty(xmlValue) == false)
                {
                    XmlSerializer sFormatter = new XmlSerializer(typeof(T));
                    StringReader sReader = new StringReader(xmlValue);
                    XmlReader reader = XmlReader.Create(sReader);

                    if (sFormatter.CanDeserialize(reader))
                        objectDeSerialized = (T)sFormatter.Deserialize(reader);
                }
            }
            catch (IOException err)
            {

            }
            return objectDeSerialized;
            /*
			T deserializedObject = default(T);
			TextReader textReader = null;
			TextWriter textWriter = null;
			Stream stream = null;

			if (File.Exists(inputFileName))
			{
				try
				{
					textReader = new StreamReader(inputFileName, Encoding.UTF8);
					textWriter = new StreamWriter(inputFileName + ".txt", false, Encoding.UTF8);
					textWriter.Write(textReader.ReadToEnd());
					textWriter.Close();
					textReader.Close();
					textReader = new StreamReader(inputFileName + ".txt", Encoding.UTF8);
					stream = new MemoryStream(Encoding.UTF8.GetBytes(textReader.ReadToEnd()));
					XmlSerializer serializer = new XmlSerializer(typeof(T));
					//deserializedObject = (T)serializer.Deserialize(textReader);
					deserializedObject = (T)serializer.Deserialize(stream);
					textReader.Close();
					stream.Close();
					File.Delete(inputFileName + ".txt");
				}
				catch (Exception ex)
				{
					//Log.WriteError(ex.Message);
					if (textReader != null)
						textReader.Close();
					if (textWriter != null)
						textWriter.Close();
					if (stream != null)
						stream.Close();
					if (File.Exists(inputFileName + ".txt"))
						File.Delete(inputFileName + ".txt");
				}
			}

			return deserializedObject;
            */
        }

        
        public static T DeserializeXmlFromString(string xmlValue, Type [] extraTypes)
        {
            T objectDeSerialized = default(T);
            try
            {
                if (string.IsNullOrEmpty(xmlValue) == false)
                {
                    XmlSerializer sFormatter = new XmlSerializer(typeof(T), extraTypes);
                    StringReader sReader = new StringReader(xmlValue);
                    XmlReader reader = XmlReader.Create(sReader);

                    if (sFormatter.CanDeserialize(reader))
                        objectDeSerialized = (T)sFormatter.Deserialize(reader);
                }
            }
            catch (IOException err)
            {

            }
            return objectDeSerialized;
        }

        public static XElement RemoveAllNamespaces(XElement e)
        {
            return new XElement(e.Name.LocalName,
              (from n in e.Nodes()
               select ((n is XElement) ? RemoveAllNamespaces(n as XElement) : n)),
                  (e.HasAttributes) ?
                    (from a in e.Attributes()
                     where (!a.IsNamespaceDeclaration)
                     select new XAttribute(a.Name.LocalName, a.Value)) : null);
        }

        public static T DeserializeXmlFromStringWithoutNamespace(string xmlValue)
        {
            T objectDeSerialized = default(T);
            try
            {
                XElement xRoot = XDocument.Parse(xmlValue).Root;
                xmlValue = RemoveAllNamespaces(xRoot).ToString();
                if (string.IsNullOrEmpty(xmlValue) == false)
                {
                    XmlSerializer sFormatter = new XmlSerializer(typeof(T));
                    StringReader sReader = new StringReader(xmlValue);
                    XmlReader reader = XmlReader.Create(sReader);

                    if (sFormatter.CanDeserialize(reader))
                        objectDeSerialized = (T)sFormatter.Deserialize(reader);
                }
            }
            catch (IOException err)
            {

            }
            return objectDeSerialized;
        }


        public static T DeserializeXmlFromStringWithoutNamespace(string xmlValue, Type[] extraTypes)
        {
            T objectDeSerialized = default(T);
            try
            {
                XElement xRoot = XDocument.Parse(xmlValue).Root;
                xmlValue = RemoveAllNamespaces(xRoot).ToString();
                if (string.IsNullOrEmpty(xmlValue) == false)
                {
                    XmlSerializer sFormatter = new XmlSerializer(typeof(T), extraTypes);
                    StringReader sReader = new StringReader(xmlValue);
                    XmlReader reader = XmlReader.Create(sReader);

                    if (sFormatter.CanDeserialize(reader))
                        objectDeSerialized = (T)sFormatter.Deserialize(reader);
                }
            }
            catch (IOException err)
            {

            }
            return objectDeSerialized;
        }
        #endregion

    }
}
