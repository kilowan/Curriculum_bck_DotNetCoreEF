namespace curriculum.Models
{
    public class PhoneNumber
    {
        public int number { get; }
        public string prefix { get; }
        public PhoneNumber(int number, string prefix)
        {
            this.number = number;
            this.prefix = prefix;
        }
        public PhoneNumber(int number)
        {
            this.number = number;
            this.prefix = "+34";
        }
        public PhoneNumber(Data.Models.PhoneNumber phoneNumber)
        {
            this.number = phoneNumber.number;
            this.prefix = phoneNumber.prefix;
        }
    }
}
