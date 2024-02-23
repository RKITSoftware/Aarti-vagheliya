using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalDemo_Advance_C_.Models
{
    public enum enmContactType
    {
        Supplier,
        Retailer,
        Wholesaler,
        Consumer
    }

    [Alias("CNT01")]
    public class CNT01
    {
        [AutoIncrement]
        public int T01F01 { get; set; } //Contact_Id
        public string T01F02 { get; set; } //Comapany_Name
        public string T01F03 { get; set; } //EmailId
        public string T01F04 { get; set; } //Description
        public string T01F05 { get; set; } //City
        public enmContactType T01F06 { get; set; } //Role_For_interaction
    }
}