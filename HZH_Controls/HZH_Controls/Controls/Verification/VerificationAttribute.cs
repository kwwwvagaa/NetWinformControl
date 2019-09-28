using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public class VerificationAttribute : Attribute
    {
        public VerificationAttribute(string strRegex = "", string strErrorMsg = "")
        {
            Regex = strRegex;
            ErrorMsg = strErrorMsg;
        }
        public string Regex { get; set; }
        public string ErrorMsg { get; set; }

    }
}
