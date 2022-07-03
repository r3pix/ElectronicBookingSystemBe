using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Application.CQRS.Room.Commands
{
    /// <summary>
    /// Command class for adding room
    /// </summary>
    public class AddRoomCommand : IRequest
    {
        /// <summary>
        /// Name of the room
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Maximal count of places
        /// </summary>
        public int TotalMaxPlaces { get; set; }

        /// <summary>
        /// Maximal count of tables
        /// </summary>
        public int TotalMaxTables { get; set; }

        /// <summary>
        /// Width of the room
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Height of the room
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Length of the room
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// Short room description
        /// </summary>
        public string Description { get; set; }


        /// <summary>
        /// Cost of the room
        /// </summary>
        public float Cost { get; set; }

        /// <summary>
        /// Picture of the room
        /// </summary>
        public IFormFile File { get; set; }
    }
}
