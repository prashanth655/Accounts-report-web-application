using System;

namespace WebApplication2.Models
{
    public class FoodCourt
    {
        public DateTime Sales_Date { get; internal set; }
        public string Location_Id { get; internal set; }
        public double Tran_Amount { get; internal set; }
        public DateTime Tran_Date { get; internal set; }
        public DateTime Sales_Data { get; internal set; }
        public string DateTime { get; internal set; }
    }
}