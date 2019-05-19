using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Codereflex.Common.Extentions
{
     
    /// <summary>
    /// Class for string extention methods.
    /// </summary>
   public static class StringExtentions
   {
      

        /// <summary>
        /// Deserializes xml string to object of  <typeparamref name="T"/> type
        /// </summary>
        /// <typeparam name="T">The Type  of deserialized object</typeparam>
        /// <param name="xmlstring">Xml string</param>
        /// <returns>Instance of  <typeparamref name="T"/> if successfull else default</returns>
        public static T XmlToObject<T>(this string xmlstring) where T: class,new()
        {

            xmlstring.ThrowIfNullEmptyOrWhiteSpace();
            var serializer = new XmlSerializer(typeof(T));
            using (var stream = new StringReader(xmlstring))
            {
                try { 
                    return (T)serializer.Deserialize(stream);
                }
                catch
                {
                   return default(T);
                }
            }
        }
        /// <summary>
        /// Validates if <paramref name="jsonstring"/> is valid and well formed json
        /// </summary>
        /// <param name="jsonstring">String to validate</param>
        /// <returns>true if <paramref name="jsonstring"/> valid json else false</returns>
        public static bool IsJson(this string jsonstring)
        {
            if ( jsonstring.IsNullEmptyOrWhiteSpace() )
            {
                return false;
            }

            jsonstring = jsonstring.Trim();

            Predicate<string> IsWellFormed = (s => {
                                                        try  {
                                                            JToken.Parse(s);
                                                        }
                                                        catch { 
                                                            return false;
                                                        }
                                                        return true;
                                                   });

            return (jsonstring.StartsWith("{") && jsonstring.EndsWith("}")
            || jsonstring.StartsWith("[") && jsonstring.EndsWith("]"))
            && IsWellFormed(jsonstring);
        }

        /// <summary>
        /// Validates if <paramref name="value"/> is null, empty or whitespace.
        /// </summary>
        /// <param name="value">string to validate</param>
        /// <returns></returns>
        public static bool IsNullEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        // <summary>
        /// Returns Json context for the given <paramref name="jsonstring"/>
        /// </summary>
        /// <param name="jsonstring"></param>
        /// <returns></returns>
        public static DelimitedStringContext DelimtedString(this string jsonstring, string delimiter)
        {
            return new DelimitedStringContext(jsonstring, delimiter);
        }

        // <summary>
        /// Returns Json context for the given <paramref name="jsonstring"/>
        /// </summary>
        /// <param name="jsonstring"></param>
        /// <returns></returns>
        public static JsonContext Json(this string jsonstring)
        {
            return new JsonContext(jsonstring);
        }

        public static FileContext File(this string filepath)
        {
             
            return new FileContext(filepath); 
        }

        /// <summary>
        /// Validates <paramref name="value"/> and throws exception if <paramref name="value"/> is null ,empty or whitespace  
        /// </summary>
        /// <param name="value"></param>
        public static void ThrowIfNullEmptyOrWhiteSpace(this string value) 
        {
            
            if (value.IsNullEmptyOrWhiteSpace())
            {
                throw new ArgumentException(nameof(value));
            }
        }
      
        /// <summary>
        /// Returns substring between <paramref name="delimiter1"/> and <paramref name="delimiter2"/>
        /// </summary>
        /// <param name="value">The string to search for a match</param>
        /// <param name="delimiter1">starting delimiter text </param>
        /// <param name="delimiter2">ending delimiter text</param>
        /// <returns></returns>
        public static string BetweenDelimiters(this string value,string delimiter1,string delimiter2 )
        {
            //build regular expression
            string regexpression = $"(?<={delimiter1})([^//]+)(?={delimiter2})";
            var match = Regex.Match(value, regexpression,
                                       RegexOptions.IgnoreCase);
           
            return match.Value;
        }
        public static void To<T>(this string value,Action<T> onsuccess,bool throwexceptiononerror = false)
        {
            try
            {
                T returnvalue = (T)Convert.ChangeType(value, typeof(T));
                onsuccess(returnvalue);
            }
            catch (FormatException)  
            {
                if(throwexceptiononerror)
                {
                    throw;
                }
                else
                {
                    onsuccess(default(T));
                }
            }
        }
    }
}
