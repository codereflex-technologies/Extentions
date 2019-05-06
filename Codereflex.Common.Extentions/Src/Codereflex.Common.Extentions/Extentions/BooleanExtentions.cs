using System;
using System.Collections.Generic;
using System.Text;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Defines extention methods boolean type 
    /// </summary>
    public static class BooleanExtentions
    {
        /// <summary>
        /// Validates given <paramref name="input"/> and calls <paramref name="ontrue"/> action if true.
        /// </summary>
        /// <param name="input">input boolean value</param>
        /// <param name="ontrue">Action to be execute when <paramref name="input"/> is validated to be true. </param>
        /// <returns></returns>
        public static bool IsTrue(this bool input, Action ontrue)
        {
            if (input == true) { ontrue(); }
            return input;
        }

        /// <summary>
        /// Validates given <paramref name="input"/> and calls <paramref name="onfalse"/> action if false.
        /// </summary>
        /// <param name="input">input boolean value</param>
        /// <param name="onfalse">Action to be execute when <paramref name="input"/> is validated to be false.</param>
        /// <returns></returns>
        public static bool IsFalse(this bool input, Action onfalse)
        {
            if (input == false) { onfalse(); }
            return input;
        }

      
    }
}
