using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Defines context for given <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">Type of input passed on to context</typeparam>
    public interface IContext<T>
    {
        
         T Input { get;  }
    }
}
