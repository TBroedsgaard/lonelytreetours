using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace Model
{
    internal class Entity : IEntity
    {
        public int? Id { get; set; }
        public bool Deleted { get; set; }
        public DateTime? LastUpdated { get; set; }

    }
}
