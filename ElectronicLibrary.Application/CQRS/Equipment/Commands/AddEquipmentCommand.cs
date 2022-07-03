using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Equipment.Commands
{
    public class AddEquipmentCommand : IRequest
    {
        /// <summary>
        /// Name of the equipment
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Cost of the decoration
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Photo of equipment
        /// </summary>
        public IFormFile File { get; set; }
    }
}
