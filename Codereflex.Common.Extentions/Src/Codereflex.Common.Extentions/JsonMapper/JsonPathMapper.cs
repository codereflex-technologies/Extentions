using Newtonsoft.Json.Linq;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Class implements <see cref="IJsonParser"/>.  
    /// </summary>
    public class JsonPathMapper : IMapper<string>
    {
        private string jsonString;
        private JObject jObject;
        private JToken token;

        public JsonPathMapper(string jsonstring)
        {
            this.jsonString = jsonstring;

        }

        /// <summary>
        /// Returns Json Token that matches <paramref name="jsonpath"/> expression.
        /// </summary>
        /// <param name="jsonpath">A string that contains json path expression</param>
        /// <returns>Token returned by <paramref name="jsonpath"/> expression</returns>
        
            

        public IToken<IMapper<string>> From(string jsonpath)
        {
            jObject = jObject ?? JObject.Parse(jsonString);
            token = jObject?.SelectToken(jsonpath, false);
            return new JsonToken(this, token);
        }
    }

      
    }



