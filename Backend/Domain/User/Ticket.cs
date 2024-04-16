using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.User
{
    public class Ticket : Base
    {
        [Required]
        public int OwnerID;
        public Connection Connection = new();
    }
}
