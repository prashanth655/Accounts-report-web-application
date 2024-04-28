namespace WebApplication2.Models
{
    internal class Card_Tran : Food_Count
    {
        public int Sales_Date { get; set; }
        public string Location_Id { get; set; }
        public int Tran_Amount { get; set; }
    }
}