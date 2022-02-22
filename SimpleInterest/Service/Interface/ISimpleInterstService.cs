namespace SimpleInterest.Service.Interface
{
    public interface ISimpleInterstService
    {
        public int CalculateSimpleInterest(SimpleInterestModel siInput);
        public int CalculateSimpleInterestYearly(int siInput);
    }
}
