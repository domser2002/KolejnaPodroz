using System.ComponentModel.DataAnnotations;

namespace Domain.Common;

public class Base
{
    [Key]
    public int ID { get; set; }
}
