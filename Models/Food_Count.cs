using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Models
{

    public class Food_Count
    {
        public DateTime Sales_Date
        {
            set;
            get;
        }

        public string Location_Id
        {
            set;
            get;
        }

        public double Tran_Amount
        {
            set;
            get;
        }
    }
}