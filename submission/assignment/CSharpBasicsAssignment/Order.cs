using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpBasicsAssignment
{

    public struct Point
    {
        public int X;
        public int Y;
    }

    public class Order
    {
        public int OrderId;
        public string CustomerName;
        public int Quantity;
        public decimal UnitPrice;
        public decimal TotalPrice;
        public bool IsPaid;
        public double DiscountPercent;
        public string ShippingCity;
        public char Priority;
        public long ItemCode;

        public void CalculateTotal()
        {
            TotalPrice = Quantity * UnitPrice *
                         (decimal)(1 - DiscountPercent / 100);
        }

        public void PrintSummary()
        {
            Console.WriteLine(
                $"Order ID: {OrderId} | " +
                $"Customer: {CustomerName} | " +
                $"Total: {TotalPrice} | " +
                $"Paid: {IsPaid}"
            );
        }
    }
}
