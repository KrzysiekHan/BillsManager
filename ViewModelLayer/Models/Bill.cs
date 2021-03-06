﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModelLayer.Interfaces;

namespace ViewModelLayer.Models
{
    public class Bill : IBill
    {
        public int BillId { get; set; }
        public decimal DueAmount { get; set; }
        public DateTime DueDate { get; set; }
        public bool Periodical { get; set; }
        public string Description { get; set; }
        public int RecipientId { get; set; }
        public int BillTypeId { get; set; }
        public IRecipient Recipient { get; set; }  
        public IBillType BillType { get; set; }
        public int Period { get; set; }
        public bool Paid { get; set; }
    }
}
