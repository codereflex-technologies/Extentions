using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Codereflex.Common.Extentions
{
    public static class FileExtentions
    {
        /// <summary>
        /// Read each line and execute <paramref name="lineaction"/> function. 
        /// </summary>
        /// <param name="lineaction">Function to execute on each line </param>
        public static void ForEachLine(this TextReader reader, Action<string> lineaction)
        {
        
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                line.When(a => a.IsNullEmptyOrWhiteSpace()).IsFalse(() => lineaction(line));

            }
        }
    }
}
