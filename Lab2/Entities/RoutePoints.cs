using Logistic.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Entities
{
    public class RoutePoint
    {
        public int Id { get; set; }

        public int RouteId { get; set; }

        public int PointId { get; set; }


        public Route Route { get; set; }

        public Point Point { get; set; }
    }
}
