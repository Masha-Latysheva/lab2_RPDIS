using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.DAL.Entities
{
    public class Car
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public int OrganizationId { get; set; }

        public int CarryingWeight { get; set; }

        public int CarryingVolume { get; set; }


        public List<Transportation> Transportations { get; set; }

        public Organization Organization { get; set; }
    }
}
