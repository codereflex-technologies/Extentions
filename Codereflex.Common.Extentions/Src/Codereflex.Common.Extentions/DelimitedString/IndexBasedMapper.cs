using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public class IndexBasedMapper : IMapper<int>
    {
        private readonly string delimitedString;
        private readonly string delimitedBy;
        private List<string> stringitems;


        public IndexBasedMapper(string delimitedstring,string delimiter)
        {
            this.delimitedString = delimitedstring;
            this.delimitedBy = delimiter;
           
        }
        
       

        public IToken<IMapper<int>> From(int index)
        {
            stringitems= stringitems ?? delimitedString.Split(delimitedBy, StringSplitOptions.None).ToList();

            object value = stringitems.ElementAtOrDefault(index);
            return new DelimitedStringToken<object>(this, value);
        }
    }
}
