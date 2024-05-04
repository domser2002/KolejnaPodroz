using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Statistics: Base
{
        [Required]
        public int UserID {  get; set; }
        public List<(string category, int num)> statistics { get; set; } = new();
    

}
