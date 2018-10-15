using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketRegister
{
    class ReceiptItem
    {
        public int Qty { get; set; }
        public String Descp { get; set; }
        public Double Price { get; set; }
        public Double LineTotal { get; set; }
    }
}
