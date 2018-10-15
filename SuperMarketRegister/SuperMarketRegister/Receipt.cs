using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketRegister
{

    // I have implemented this class on the basis that we do not need to worry about
    // implementing a removeItem method. If this was the case I may have taken a 
    // different approach, perhaps using an observable collection and updating the values
    // in the oncollectionChanged event

    public class Receipt
    {

        private readonly List<ReceiptItem> _receiptItems;
        private readonly object _addItemLock = new object();

        public double Tax  { get; private set; } 
        public double SubTotal { get; private set; }
        public double Total { get; private set; }

        private const double TaxRate = 0.1;

        public Receipt()
        {
            _receiptItems = new List<ReceiptItem>();
        }

        // I've made the assumption that the text should all be left aligned to be consistent,
        // although if you copy paste directly from the unit test in the word document
        // it's inconsistent. I therefore aligned the soda items with the others
        public override string ToString()
        {
            var sortedItems = _receiptItems.OrderBy(x => x.Descp).ToList();
            var sbItemsSummary = new StringBuilder();
            foreach (var item in sortedItems)
            {
                sbItemsSummary.AppendLine($"{item.Qty} {item.Descp} @ ${item.Price:N} = ${item.LineTotal:N}");
            }

            sbItemsSummary.AppendLine($"SubTotal = ${SubTotal:N}");
            sbItemsSummary.AppendLine($"Tax ({TaxRate:P0}) = ${Tax:N}");
            sbItemsSummary.Append($"Total = ${Total:N}");

            return sbItemsSummary.ToString();

        }

        public void AddItem(int qty, string desc,double price)
        {
            // Thread safety to ensure UpdateTotals is in sync
            lock (_addItemLock)
            {
                var receiptItem = new ReceiptItem() { Descp = desc, Qty = qty, Price = price,LineTotal = qty*price};
                _receiptItems.Add(receiptItem);
                UpdateTotals();
            }
        }
        
        // alternative would have been to calculate all of these in the ToString() method
        // rather than every time an item is added. However have public getters on Subtotal, Tax and 
        // Total so these are updated as we go
        private void UpdateTotals()
        {
            UpdateSubTotal();
            UpdateTax();
            UpdateTotal();
        }

        private void UpdateSubTotal()
        {
            SubTotal = _receiptItems.Sum(x => x.LineTotal);
        }

        private void UpdateTax()
        {
            Tax = SubTotal * TaxRate;
        }

        private void UpdateTotal()
        {
            Total = SubTotal + Tax;

        }


    }

    
}
