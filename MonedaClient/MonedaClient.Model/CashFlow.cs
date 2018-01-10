﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        public FrequencyEnum Frequency { get; set; }
        public User User { get; set; }
        public Account Account { get; set; }
    }
    public enum FrequencyEnum
    {
        [Description("Single")]
        Single,
        [Description("Single")]
        Weekly,
        [Description("Single")]
        Monthly,
        [Description("Single")]
        Quarterly,
        Yearly
    }
}
