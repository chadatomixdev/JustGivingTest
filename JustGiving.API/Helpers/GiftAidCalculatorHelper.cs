namespace JG.FinTechTest.API.Helpers
{
    public class GiftAidCalculatorHelper
    {
        public const decimal taxRate = 20;

        public decimal Calculate(decimal donation)
        {
            return donation * (taxRate / (100 - taxRate));
        }
    }
}