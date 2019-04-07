using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Class for object extention methods.
    /// </summary>
    public static class ObjectExtentions
    {
        /// <summary>
        /// Serialize given <paramref name="instance"/> to json.
        ///</summary>
        //// <typeparam name="T">Type of <paramref name="instance"/></typeparam>
        /// <param name="instance">The object to be serialized.</param>
        /// <param name="encodejsonstring">The value that indicates if json string should be encoded to javascript string format.</param>
        /// <returns></returns>
        public static string ToJson<T> (this T instance,bool encodejsonstring = false) where T : class
        {
            
            if (instance == null) return string.Empty;
            string jsonstring;
            try
            {
                jsonstring = JsonConvert.SerializeObject(instance);
                if(encodejsonstring) {
                   jsonstring = HttpUtility.JavaScriptStringEncode(jsonstring, true);
                }
            }
            catch
            {
                return string.Empty;
            }
            return jsonstring;
            }

        /// <summary>
        /// Serailize given <paramref name="instance"/> to json
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="instance"/></typeparam>
        /// <param name="instance">The object to be serialized</param>
        /// <returns></returns>
        public static string ToXml<T>(this T instance) where T : class
        {
            if (instance == null) { return string.Empty; }
            XmlSerializer serializer = new XmlSerializer(instance.GetType());
            
            string xmlstring = string.Empty;

            using (var xmlstringwriter = new StringWriter())
            {
                using (XmlWriter writer = XmlWriter.Create(xmlstringwriter))
                {
                    serializer.Serialize(writer, instance);
                    xmlstring = xmlstringwriter.ToString(); 
                }
            }
            return xmlstring;
        }

       
    }



   
}
