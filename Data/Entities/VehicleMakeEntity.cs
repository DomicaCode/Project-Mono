using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Abrv { get; set; }

        public List<VehicleModelEntity> Models { get; set; }
    }
}
