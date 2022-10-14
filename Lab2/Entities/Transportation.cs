﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logistic.DAL.Entities
{
    public class Transportation
    {
        public int Id { get; set; }

        public int DriverId { get; set; }

        public int RouteId { get; set; }

        public int CarId { get; set; }

        public int RateId { get; set; }
        
        public int CargoId { get; set; }

        public int CargoCount { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;


        public Driver Driver { get; set; }

        public Route Route { get; set; }

        public Car Car { get; set; }

        public Cargo Cargo { get; set; }

        public Rate Rate { get; set; }
    }
}
