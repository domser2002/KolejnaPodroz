﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class StopDetails : Base
    {
        public DateTime? ArrivalTime { get; set; } // null for first station
        public DateTime? DepartureTime { get; set; } // null for last station
        [Required]
        public int StationID { get; set; }
        [Required]
        public int ConnectionID { get; set; }   
    }
}
