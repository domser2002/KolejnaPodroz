using Domain.Common;
using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.User;

public class User : CommonAccountInfo
{
    public DateTime? BirthDate { get; set; }
    public SeatType PreferedSeatType { get; set; }
    public SeatLocation PreferedSeatLocation { get; set; }
}

public class Discount : Base
{
    public DiscountType Type { get; set; }
    public int Percentage { get; set; }
}

public class UserDiscount : Base
{
    public int UserID { get; set; }
    public int DiscountID { get; set; }
}

public class PersonalRanking : Base
{
    public int UserID { get; set; }
    public List<(string category, int rank)> personalRanking { get; set; } = new();
}