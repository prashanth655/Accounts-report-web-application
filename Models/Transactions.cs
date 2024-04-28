using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Transactions
    {
        public string Card_No
        {
            internal set;
            get;
        }

        public string Tran_Date
        {
            internal set;
            get;
        }

        public string Location_Id
        {
            internal set;
            get;
        }

        public string Tran_Amount
        {
            internal set;
            get;
        }

        public string Location_Name
        {
            internal set;
            get;
        }

        public string Tran_Type
        {
            internal set; get;
        }
        public string Sales_Time 
        { 
           internal set; get;
        }
    }
}