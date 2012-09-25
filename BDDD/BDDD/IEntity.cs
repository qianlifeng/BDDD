using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BDDD
{
    /// <summary>
    /// Represents that the implemented classes are domain entities.
    /// imitate from:http://apworks.codeplex.com/
    /// </summary>
    public interface IEntity : IEquatable<IEntity>
    {
        /// <summary>
        /// Gets or sets the identifier of the entity.
        /// </summary>
        Guid ID { get; set; }
    }
}
