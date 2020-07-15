using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Codereflex.Common.Extentions
{
    //Defines xml context to string type and provides functions to work with xml.
    public class XmlContext : IContext<string>
    {
        private string xmlString;

        public XmlContext(string xmlstring)
        {
            this.xmlString = xmlstring;
        }
        public string Input { get => xmlString; }

        /// <summary>
        /// Deserializes xml string to object of <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The Type of deserialized object</typeparam>
        /// <returns>Instance of <typeparamref name="T"/> if successfull else default</returns>
        public T ToObject<T>() where T : class, new()
        {
            try
            {
                T result = default(T);
                string jsonstring = this.Input;
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                using (StringReader stringReader = new StringReader(jsonstring))
                {
                    result = (T)serializer.Deserialize(stringReader);
                }
                return result; 
            }
            catch
            {
                return default(T);
            }

        }
    }
}
