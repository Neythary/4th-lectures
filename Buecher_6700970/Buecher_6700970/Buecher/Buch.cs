namespace Buecher
{
    public class Buch
    {
        // implementiert die Oberklasse Buch mit den notwendigen Parametern Title & Author, sowie zwei zusätzlichen 
        // Parametern Id & Type
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
        
        public string? title { get; set; }
        public string? author { get; set; }

        
    }

    
}