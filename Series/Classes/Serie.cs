using Series.Enum;

namespace Series.Classes
{
    public class Serie : BaseEntity
    {

        private Genre Genre { get; set; }

        private String Title { get; set; }

        private String Description { get; set; }

        private int Year { get; set; }

        private bool Deleted { get; set; }

        public Serie(int id, Genre genre, string title, string description, int year)
        {
            this.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
            this.Deleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Genre: " + this.Genre + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Start Year: " + this.Year;
            return retorno;
        }

        public string ReturnTitle()
        {
            return this.Title;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public void Delete() { 
            this.Deleted = true;
        }

        public bool ReturnDeleted() { 
            return this.Deleted;
        }
    }
}
