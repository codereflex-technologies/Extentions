using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public static class GenericExtentions
    {
        /// <summary>
        /// Converts <paramref name="input"/> from <typeparamref name="TInput"/> type to <typeparamref name="TResult"/> type
        /// </summary>
        /// <typeparam name="TInput">Type of <paramref name="input"/></typeparam>
        /// <typeparam name="TResult">Type to be converted to</typeparam>
        /// <param name="input">The </param>
        /// <returns><paramref name="input"/> converted to type of <typeparamref name="TResult"/></returns>
        public static TResult Convert<TInput, TResult>(this TInput input)
        {
            try
            {
                var converter = TypeDescriptor.GetConverter(typeof(TResult));
                if (converter != null)
                {

                    return (TResult)converter.ConvertFrom(input);
                }
                return default(TResult);
            }
            catch (NotSupportedException)
            {
                return default(TResult);
            }
        }

        /// <summary>
        /// Validates <paramref name="instance"/> and throws error if <paramref name="instance"/> is null.  
        /// </summary>
        /// <typeparam name="T">Type of <paramref name="instance"/></typeparam>
        /// <param name="instance">object instance to verify</param>
        /// <param name="throwwhennull">Indicates if excepion should be thrown when <paramref name="instance"/> is null</param>
        public static void ThrowIfNull<T>(this T instance, bool throwwhennull = true) where T : class
        {
            if (instance == null && throwwhennull)
                throw new ArgumentNullException(nameof(instance));
        }
    }
}
