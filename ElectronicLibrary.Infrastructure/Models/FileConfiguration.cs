using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Infrastructure.Models
{
    /// <summary>
    /// Class mapping Appsettings Section
    /// </summary>
    public class FileConfiguration
    {
        /// <summary>
        /// File upload path
        /// </summary>
        public string UploadPath { get; set; }

        /// <summary>
        /// URL for File Controller
        /// </summary>
        public string FileControllerAddress { get; set; }
    }
}
