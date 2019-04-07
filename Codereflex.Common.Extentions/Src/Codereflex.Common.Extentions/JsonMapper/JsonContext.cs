using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public class JsonContext : IContext
    {
        private string jsonString;

        public JsonContext(string jsonstring)
        {
            this.jsonString = jsonstring;
        }

        public string InputString { get => jsonString; }

        public  IMapper<string> Map()
        {
            return new JsonPathMapper(this.InputString);
        }

        /// <summary>
        /// Deserializes json string to object of <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The Type of deserialized object</typeparam>
        /// <param name="thisstring">Json string</param>
        /// <param name="isencodedstring">A value that indicates <paramref name="jsonstring"/> is in encoded string format.</param>
        /// <returns>Instance of <typeparamref name="T"/> if successfull else default</returns>
        public  T ToObject<T>(bool isencodedstring = false) where T : class, new()
        {
            

            try
            {
                string jsonstring = this.InputString;
                if (isencodedstring)
                {
                    JToken token = JToken.Parse(this.InputString);
                    jsonstring = token.ToString();
                }

                return JsonConvert.DeserializeObject<T>(jsonstring);
            }
            catch
            {
                return default(T);
            }

        }

        public  string ToJsonFormat()
        {

            JToken token = JToken.Parse(this.InputString);
            return token.ToString();

        }

    }
}
