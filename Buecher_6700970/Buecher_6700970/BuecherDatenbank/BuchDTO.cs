﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuchDatenbank
{
    public class BuchDTO
    {
        public int Id { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? type { get; set; }

    }
}
