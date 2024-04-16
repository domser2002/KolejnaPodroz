using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.Server
{
    public class Advertisment : Base
    {
        [Required]
        [MaxLength(50)]
        public string CompanyName = string.Empty;
        [Required]
        [MaxLength(250)]
        public string Content = string.Empty;
    }
}
