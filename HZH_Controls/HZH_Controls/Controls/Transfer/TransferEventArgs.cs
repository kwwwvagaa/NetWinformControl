using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HZH_Controls.Controls
{
    public class TransferEventArgs : EventArgs
    {
        public object[] TransferDataSource { get; set; }
        /// <summary>
        /// true:right  false:left
        /// </summary>
        /// <value><c>true</c> if [to right or left]; otherwise, <c>false</c>.</value>
        public bool ToRightOrLeft { get; set; }
    }
    public delegate void TransferEventHandler(object sender,TransferEventArgs e);
   
}
