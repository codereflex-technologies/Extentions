using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    //Defines Json context to string type and provides functions to work with json.
    public class JsonContext : IContext<string>
    {
        private string jsonString;

        public JsonContext(string jsonstring)
        {
            this.jsonString = jsonstring;
        }

        public string Input { get => jsonString; }

        /// <summary>
        /// Initializes Json Mapper on given Json Context
        /// </summary>
        /// <returns></returns>
        public  IMapper<string> Map()
        {
            return new JsonPathMapper(this.Input);
        }

        /// <summary>
        /// Deserializes json string to object of <typeparamref name="T"/> type.
        /// </summary>
        /// <typeparam name="T">The Type of deserialized object</typeparam>
        /// <param name="isencodedstring">A value that indicates <paramref name="jsonstring"/> is in encoded string format.</param>
        /// <returns>Instance of <typeparamref name="T"/> if successfull else default</returns>
        public  T ToObject<T>(bool isencodedstring = false) where T : class, new()
        {
            try
            {
                string jsonstring = this.Input;
                if (isencodedstring)
                {
                    JToken token = JToken.Parse(this.Input);
                    jsonstring = token.ToString();
                }

                return JsonConvert.DeserializeObject<T>(jsonstring);
            }
            catch
            {
                return default(T);
            }

        }
        /// <summary>
        /// Removes escape characters and formats the string to json
        /// </summary>
        /// <returns>string in json format</returns>
        public string ToJsonFormat()
        {
            JToken token = JToken.Parse(this.Input);
            return token.ToString();

        }

    }
}
