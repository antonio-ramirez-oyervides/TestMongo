using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestMongo.Common
{
    public class Error
    {
        public bool hasError { get; set; }
        public string errorNumber { get; set; }
        public string errorDescription { get; set; }

    }
}