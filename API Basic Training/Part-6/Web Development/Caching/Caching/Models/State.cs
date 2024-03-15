using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Caching.Models
{
    public class State
    {
        public int StateId { get; set; }
        public string StateName { get;  set; }
        public string StateCode { get; set; }
    }
}