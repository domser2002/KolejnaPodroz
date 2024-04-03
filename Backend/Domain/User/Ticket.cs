using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.User
{
    public class Ticket : Base
    {
        [Required]
        public int OwnerID;
        public Connection Connection = new();
    }
}
