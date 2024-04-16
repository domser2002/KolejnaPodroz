using Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Domain.User
{
    public enum SeatTypes
    {

    }
    public enum SeatLocations
    {

    }
    public enum DiscountTypes
    {

    }
    public class User : CommonAccountInfo
    {
        public DateTime? BirthDate {  get; set; }
        public SeatTypes PreferedSeatType { get; set; }
        public SeatLocations PreferedSeatLocation { get; set; }
        public List<Discount> Discounts { get; set; }
    }

    public class Discount : Base
    {
        [Key]
        public int Id { get; set; }
        public DiscountTypes Type { get; set; }
        public int Percentage {  get; set; }
        public List<User> Users { get; set; }
    }
}
