﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LootLoOnline_FunctionApp.Models
{
    public class DealsOfTheDay
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Nullable<System.DateTime> startTime { get; set; }
        public Nullable<System.DateTime> endTime { get; set; }
        public string title { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string url { get; set; }
        public string category { get; set; }
        public string imageUrls_default { get; set; }
        public string imageUrls_mid { get; set; }
        public string imageUrls_low { get; set; }
        public string availability { get; set; }
    }
}
