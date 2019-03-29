using System;

namespace ListeLectureJCC.Models
{
    public class DetailModel
    {
        public Livre LivreCourant { get; private set; }
       

        public DetailModel (Livre newLivre)
        {
            LivreCourant = newLivre;    
        }
    }
}