using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Common
{
    public class Complaint : Base
    {
        public int UserID { get; set; }
        [Required]
        [MaxLength(50)]
        public string Title { get; set; }   
        [Required]
        [MaxLength(250)]
        public string Content {  get; set; }
        [MaxLength(250)]
        public string Response { get; set; }
        [Required]
        public bool IsResponded { get; set; }
    }
}
