using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{

    /// <summary>
    /// Defines a token  
    /// </summary>
    public interface IToken<TParser>
    {
        TParser Into<TResult>(Action<TResult> map);
    }
}
