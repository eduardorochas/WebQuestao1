﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebQuestao1.Models
{
    public class NumberSequence
    {
        public int NumberSequenceID { get; set; }
        [Required]
        public string NumberSequenceName { get; set; }
        [Required]
        public string Module { get; set; }
        [Required]
        public string Prefix { get; set; }
        public int LastNumber { get; set; }
    }
}
