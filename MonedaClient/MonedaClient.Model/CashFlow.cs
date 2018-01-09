﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonedaClient.Model
{
    public class CashFlow
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public virtual Frequency Frequency { get; set; }
        public virtual User User { get; set; }
        public virtual Account Account { get; set; }
    }
}
