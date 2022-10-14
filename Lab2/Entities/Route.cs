using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Logistic.DAL.Entities
{
    public class Route
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int RouteLength { get; set; }


        public List<Transportation> Transportations { get; set; }
    }
}
