using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }

        public int MakeId { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }
    }
}
