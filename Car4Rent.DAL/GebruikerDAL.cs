using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces.DTO;
using System.Data.SqlClient;
using System.Data;

namespace Car4Rent.DAL
{
    public class GebruikerDAL : IGebruikerDAL
    {
        private DatabaseDAL dbs = new DatabaseDAL();

        public GebruikerDTO GetGebruikerByEmail(string email)
        {
            SqlCommand getGebruiker = new SqlCommand($"select G.GebruikerID, Naam, telnummer, adres, Regio, Gebruikersnaam,  email, wachtwoord, betaalgegevens from Gebruiker G " +
                                                     $"inner join Account A on g.AccountID = a.AccountID where email = @Email");


            getGebruiker.Parameters.AddWithValue("@Email", email);

            DataTable dataTable = dbs.Query(getGebruiker);
            GebruikerDTO gebruikerDTO = new GebruikerDTO();

            foreach(DataRow dataRow in dataTable.Rows)
            {
                gebruikerDTO = gebruikerDTOFill(gebruikerDTO, dataRow);
            }

            return gebruikerDTO;
        }

        private GebruikerDTO gebruikerDTOFill(GebruikerDTO gebruikerDTO, DataRow dataRow)
        {
            gebruikerDTO.GebruikerID = Convert.ToInt32(dataRow["GebruikerID"]);
            gebruikerDTO.Naam = Convert.ToString(dataRow["Naam"]);
            gebruikerDTO.Email = Convert.ToString(dataRow["email"]);
            gebruikerDTO.Wachtwoord = Convert.ToString(dataRow["wachtwoord"]);
            gebruikerDTO.GebruikersNaam = Convert.ToString(dataRow["Gebruikersnaam"]);
            gebruikerDTO.BetaalGegevens = Convert.ToString(dataRow["betaalgegevens"]);
            gebruikerDTO.Telnummer = Convert.ToInt32(dataRow["telnummer"]);
            gebruikerDTO.Adres = Convert.ToString(dataRow["adres"]);
            gebruikerDTO.regio = Convert.ToString(dataRow["Regio"]);

            return gebruikerDTO;
        }

        public void Create(GebruikerDTO gebruikerDTO)
        {
            var createGebruiker = new SqlCommand($"insert into Account (AccountID, GebruikerID, Gebruikersnaam, wachtwoord, email, betaalgegevens) " +
                                                 $"values(@AccountID, @GebruikerID, @Gebruikersnaam, @wachtwoord, @email, @betaalgegevens) " +
                                                 $"insert into Gebruiker(GebruikerID, AccountID, naam, telnummer, adres, Regio) " +
                                                 $"values(@GebruikerID, @AccountID, @naam, @telnummer, @adres, @Regio)");

            var maxAccountID = new SqlCommand($"select MAX(AccountID) as AccountID from Account");
            var maxGebruikerID = new SqlCommand($"select MAX(GebruikerID) as GebruikerID from Gebruiker");
            string columnAcc = "AccountID";
            string columnGebr = "GebruikerID";
            int AccountID = dbs.GetMaxID(maxAccountID, columnAcc);
            int GebruikerID = dbs.GetMaxID(maxGebruikerID, columnGebr);

            createGebruiker.Parameters.AddWithValue("@GebruikerID", GebruikerID);
            createGebruiker.Parameters.AddWithValue("@AccountID", AccountID);
            createGebruiker.Parameters.AddWithValue("@Gebruikersnaam", gebruikerDTO.GebruikersNaam);
            createGebruiker.Parameters.AddWithValue("@wachtwoord", gebruikerDTO.Wachtwoord);
            createGebruiker.Parameters.AddWithValue("@email", gebruikerDTO.Email);
            createGebruiker.Parameters.AddWithValue("@betaalgegevens", gebruikerDTO.BetaalGegevens);
            createGebruiker.Parameters.AddWithValue("@naam", gebruikerDTO.Naam);
            createGebruiker.Parameters.AddWithValue("@telnummer", gebruikerDTO.Telnummer);
            createGebruiker.Parameters.AddWithValue("@adres", gebruikerDTO.Adres);
            createGebruiker.Parameters.AddWithValue("@Regio", gebruikerDTO.regio);

            dbs.ExecuteQuery(createGebruiker);

        }


    }
}
