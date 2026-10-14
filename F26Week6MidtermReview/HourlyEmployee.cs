using System;
using System.Collections.Generic;
using System.Text;

namespace F26Week6MidtermReview
{
    public class HourlyEmployee : Employee
    {
        public int Hours { get; set; }
        public double Wage { get; set; }

        // traditional parameterized contructor
        public HourlyEmployee (int id, string? name, bool isUnionMember, int hours, double wage) : base (id, name, isUnionMember)
        {
            Hours = hours;
            Wage = wage;
        }

        public override double Earnings()
        {
            if (Hours <= 40)
                return Hours * Wage;
            else
                return (40 * Wage) + (Hours - 40) * Wage * 1.5;
        }
    }
}
