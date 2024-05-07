using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Statistics: Base
{
        [Required]
        public int UserID {  get; set; }
        [Required]
        public int CategoryID {  get; set; }
        [Required]
        public double Value { get; set; }
    

}
