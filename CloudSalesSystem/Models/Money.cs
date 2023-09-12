namespace CloudSalesSystem.Models
{
    public class Money
    {
        public string Currency { get; set; } = string.Empty;
        public decimal Amount { get; set; }

        public Money(string Currency, decimal Amount)
        {
            this.Currency = Currency;
            this.Amount = Amount;
        }
    }
}
