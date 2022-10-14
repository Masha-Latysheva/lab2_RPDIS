using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.DAL.Entities
{
    public class Rate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int VolumeRate { get; set; }

        public int CarryingRate { get; set; }


        public List<Transportation> Transportations { get; set; }
    }
}
