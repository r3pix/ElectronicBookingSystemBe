using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Decoration.Commands
{
    /// <summary>
    /// Command class for adding decoration 
    /// </summary>
    public class AddDecorationCommand : IRequest
    {
        /// <summary>
        /// Name of decoration
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Picture of decoration
        /// </summary>
        public IFormFile File { get; set; }
    }
}
