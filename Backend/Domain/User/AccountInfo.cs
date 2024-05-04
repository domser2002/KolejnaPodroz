using Domain.Common;

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
    public class AccountInfo : CommonAccountInfo
    {
        public DateOnly? BirthDate = null;
        public SeatTypes PreferedSeatType;
        public SeatLocations PreferedSeatLocation;
        public List<DiscountTypes> DiscountTypes = new();
        public List<int> DiscountPercentages = new();
    }
}
