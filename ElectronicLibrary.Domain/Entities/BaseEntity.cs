using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicLibrary.Domain.Entities
{
    /// <summary>
    /// Used for polymorphism
    /// </summary>
    public abstract class BaseEntity
    {

    }

    /// <summary>
    /// BaseEntity class modelling essential fields of every entity
    /// </summary>
    /// <typeparam name="TKey">Type of the key in the entity</typeparam>
    public abstract class BaseEntity<TKey> : BaseEntity where TKey : struct
    {
        /// <summary>
        /// Key of the entity
        /// </summary>
        public TKey Id { get; set; }

        /// <summary>
        /// Date of creation
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// Date of the last modification
        /// </summary>
        public DateTime LMDate { get; set; }

        /// <summary>
        /// Email of creator
        /// </summary>
        public string CreateEmail { get; set; }

        /// <summary>
        /// Email of the last modificator
        /// </summary>
        public string LMEmail { get; set; }

        /// <summary>
        /// Flag used to determine whether entity is active
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Base constructor activating entity
        /// </summary>
        public BaseEntity()
        {
            IsActive = true;
        }
    }
}
