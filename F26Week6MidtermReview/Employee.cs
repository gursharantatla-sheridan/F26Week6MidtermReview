using System;
using System.Collections.Generic;
using System.Text;

namespace F26Week6MidtermReview
{
    public abstract class Employee (int id, string? name, bool isUnionMember)
    {
        public int Id { get; set; } = id;
        public string? Name { get; set; } = name;
        public bool IsUnionMember { get; set; }= isUnionMember;

        public abstract double Earnings();
    }
}
