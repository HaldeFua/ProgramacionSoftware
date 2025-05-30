namespace BillCalculator.Models
{
    public class Bill
    {
        public decimal BillAmount { get; set; }

        public int TipPercentage { get; set; }

        public decimal TipAmount => Math.Round(BillAmount * TipPercentage / 100, 2);

        public decimal TotalAmount => Math.Round(BillAmount + TipAmount, 2);
    }
}
