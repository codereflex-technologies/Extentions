using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public class DelimitedStringContext : IContext<string>
    {
        public string Input { get; }

        public string Delimiter { get; }

        public DelimitedStringContext(string delimitedstring, string delimiter)
        {
            this.Input = delimitedstring;
            this.Delimiter = delimiter;
        }

        public  IMapper<int> Map()
        {
            return new IndexBasedMapper(this.Input, this.Delimiter);
        }
    }
}
