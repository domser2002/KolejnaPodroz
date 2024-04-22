using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.User;

public class User : CommonAccountInfo
{
    public DateTime? BirthDate {  get; set; }
    public SeatType PreferedSeatType { get; set; }
    public SeatLocation PreferedSeatLocation { get; set; }
    public List<Discount> Discounts { get; set; }
}

public class Discount : Base
{
    [Key]
    public int Id { get; set; }
    public DiscountType Type { get; set; }
    public int Percentage {  get; set; }
    public List<User> Users { get; set; }
}
