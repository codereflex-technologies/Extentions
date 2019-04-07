using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public class DelimitedStringToken<TInput> : IToken <IMapper<int>>
    {
        public TInput dataValue;
        private IMapper<int> parser;

        public DelimitedStringToken(IMapper<int> parser, TInput datavalue)
        {
            this.dataValue = datavalue;
            this.parser = parser; 
        }

        public IMapper<int> Into<T>(Action<T> map)
        {
            T data = dataValue.Convert<TInput,T>();
            map(data);
            return parser;
        }
        
    }
}
