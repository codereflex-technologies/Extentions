using System;
using System.IO;

namespace Codereflex.Common.Extentions
{
    /// <summary>
    /// Defines file context to string type and defines functions to work with file
    /// </summary>
    public class FileContext : IContext<string>
    {
        private string filePath;
        private StreamReader filestream;
        public string Input => filePath;



        public FileContext(string filepath)
        {
            this.filePath = filepath;

        }

       
        
        /// <summary>
        /// Returns stream reader for the specified file.
        /// </summary>
        /// <returns>return stream reader</returns>
        public StreamReader Stream()
        {
            try
            {
                filestream = filestream ?? new System.IO.StreamReader(this.Input);

            }
            catch when (filestream != null)
            {
                filestream.Close();
                throw;
            }
            catch
            {
                throw;
            }
            return filestream;
        }

        
    }
}