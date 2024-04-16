using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.User
{
    public class Ticket : Base
    {
        [Required]
        public int OwnerID { get;  set; }
        public int ConnectionID { get; set; }
    }
}
