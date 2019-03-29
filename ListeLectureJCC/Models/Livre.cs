using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListeLectureJCC.Models
{
    public class Livre
    {
        public int ID { get; private set; }
        public string Titre { get; private set; }
        public string Auteur { get; private set; }
        public int? Note { get; private set; }
        public DateTime DateDeDebut { get; private set; }
        public DateTime? DateDeFin { get; private set; }

        public Livre(int iD, string titre, string auteur, int? note, DateTime dateDeDebut, DateTime? dateDeFin)
        {
            ID = iD;
            Titre = titre;
            Auteur = auteur;
            Note = note;
            DateDeDebut = dateDeDebut;
            DateDeFin = dateDeFin;
        }
    }
}