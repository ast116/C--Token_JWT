namespace UIN.Library.Api.Models
{
    public enum Categorie
    {
        Science,
        Litterature,
        Histoire,
        Technique,
        Autre
    }

    public class Livre
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Titre { get; set; }

        public string Auteur { get; set; }

        public string ISBN { get; set; }

        public int AnneePublication { get; set; }

        public Categorie Categorie { get; set; }

        public bool Disponible { get; set; } = true;

        public DateTime DateAjout { get; set; } = DateTime.UtcNow;

        public string AjouteParUserId { get; set; }
    }
}