﻿namespace Buecher
{
    public class Buch
    {
        public Buch()
        {
            this.title = "";
            this.author = "";
        }

        public Buch(string? title, string? author)
        {
            this.title = title;
            this.author= author;
        }
        
        public int? id { get; set; }
        public string? title { get; set; }
        public string? author { get; set; }
        public string? type { get; set; }

        
    }

    
}