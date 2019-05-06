using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Class that defines abstract Json Token.
    /// </summary>
    public class JsonToken : IToken<IMapper<string>>
    {
        private JsonPathMapper jsonParser;
        private JToken jToken;
        public JsonToken(JsonPathMapper jsonparser, JToken jtoken)
        {
            jsonParser = jsonparser;
            jToken = jtoken;
        }
        /// <summary>
        /// Maps value from Json Token to <paramref name="map"/>
        /// </summary>
        /// <typeparam name="TResult">The type of Json Token value</typeparam>
        /// <param name="map">Reference to mapping function </param>
        /// <returns></returns>
        public IMapper<string> Into<TResult>(Action<TResult> map)
        {
            jToken.ThrowIfNull<JToken>();
            
            TResult result = jToken == null ? default(TResult) : jToken.Value<TResult>();
            map(result);
            return jsonParser;
        }

    }
}
