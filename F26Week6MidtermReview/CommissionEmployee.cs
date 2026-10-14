using System;
using System.Collections.Generic;
using System.Text;

namespace F26Week6MidtermReview
{
    // primary contructor
    public class CommissionEmployee (int id, string? name, bool isUnionMember, double grossSales, double commissionRate) : Employee (id, name, isUnionMember)
    {
        public double GrossSales { get; set; } = grossSales;
        public double CommissionRate { get; set; } = commissionRate;

        public override double Earnings()
        {
            return GrossSales * CommissionRate;
        }
    }
}
