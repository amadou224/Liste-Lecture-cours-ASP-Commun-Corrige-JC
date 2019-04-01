using System;
using System.Data.SqlClient;

namespace ListeLectureJCC.Models
{
    public class DataAccess
    {
        const string ConnectionString = @"Server=.\SQLExpress;Database=ListeLecture;Integrated Security=true";
        public static ConfirmationLectureModel ChargerConfirmationLectureDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne

                reader.Read();

                string titre = (string)reader["Titre"];
                DateTime dateFinLecture = (DateTime)reader["DateFinLecture"];

                ConfirmationLectureModel model = new ConfirmationLectureModel(titre, dateFinLecture);

                return model;
            }
        }

        public static void MettreAJourDateDeFinDeLecture(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    @"UPDATE Livre SET DateFinLecture = GETDATE() WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                command.ExecuteNonQuery();
            }
        }
        public static DetailModel ChargerDetailDepuisBDD(int idLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(
                    "SELECT Titre, Auteur, Note, DateDebutLecture, DateFinLecture FROM Livre WHERE ID = @idLivre", connection);
                command.Parameters.AddWithValue("@idLivre", idLivre);

                SqlDataReader reader = command.ExecuteReader();

                //On avance sur la première ligne
                reader.Read();

                string titre = (string)reader["Titre"];
                string auteur = (string)reader["Auteur"];

                short? note;
                if (reader.IsDBNull(2))
                {
                    note = null;
                }
                else
                {
                    note = (byte)reader["Note"];
                }

                DateTime dateDebutLecture = (DateTime)reader["DateDebutLecture"];

                DateTime? dateFinLecture;
                if (reader.IsDBNull(4))
                {
                    dateFinLecture = null;
                }
                else
                {

                    dateFinLecture = (DateTime)reader["DateFinLecture"];
                }

                Livre livre = new Livre(idLivre, titre, auteur, note, dateDebutLecture, dateFinLecture);
                DetailModel model1 = new DetailModel(livre);
                return model1;
            }

        }
        public static void InsererNouvoLivre(Livre nouvoLivre)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("Insert into Livre(Titre,Auteur,Note,DateDebutLecture,DateFinLecture ) Values(@titre,@auteur,@note,@datedeb,@datefin) ",connection);
                command.Parameters.AddWithValue("@titre",nouvoLivre.Titre );
                command.Parameters.AddWithValue("@auteur", nouvoLivre.Auteur);
                command.Parameters.AddWithValue("@note", nouvoLivre.Note);
                command.Parameters.AddWithValue("@datedeb", nouvoLivre.DateDeDebut);
                command.Parameters.AddWithValue("@datefin", nouvoLivre.DateDeFin);

                command.ExecuteNonQuery();
            }
        }




    }
}