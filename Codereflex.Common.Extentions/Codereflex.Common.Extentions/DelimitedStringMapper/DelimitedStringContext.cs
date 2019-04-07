using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public class DelimitedStringContext : IContext
    {
        public string InputString { get; }

        public string Delimiter { get; }

        public DelimitedStringContext(string delimitedstring, string delimiter)
        {
            this.InputString = delimitedstring;
            this.Delimiter = delimiter;
        }

        public  IMapper<int> Map()
        {
            return new IndexBasedMapper(this.InputString, this.Delimiter);
        }
    }
}
