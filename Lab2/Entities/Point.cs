using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.DAL.Entities
{
    public class Point
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public List<Route> StartRoutes { get; set; }

        public List<Route> EndRoutes { get; set; }
    }
}
