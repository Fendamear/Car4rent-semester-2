using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces.DTO;
using System.Data.SqlClient;

namespace Car4Rent.DAL
{
    public class BoekingDAL : IBoekingDAL
    {
        private DatabaseDAL dbs = new DatabaseDAL();

        public void BoekingToevoegen(BoekingDTO boekingDTO)
        {
            var BoekingToevoegen = new SqlCommand($"insert into Boeking (BoekingNr, AutoID, HuurderID, Begindatum, Einddatum, BoekingDatum, prijs) "+ 
                                                  $"values (@BoekingNr, @AutoID, @HuurderID, @Begindatum, @Einddatum, @BoekingDatum, @prijs)");

            var query = new SqlCommand($"select MAX(BoekingNr) as BoekingNr from Boeking");
            string column = "BoekinNr";

            BoekingToevoegen.Parameters.AddWithValue("@BoekingNr", dbs.GetMaxID(query, column));
            BoekingToevoegen.Parameters.AddWithValue("@AutoID", boekingDTO.AutoID);
            BoekingToevoegen.Parameters.AddWithValue("@HuurderID", 1);
            BoekingToevoegen.Parameters.AddWithValue("@Begindatum", boekingDTO.Begindatum);
            BoekingToevoegen.Parameters.AddWithValue("@Einddatum", boekingDTO.Einddatum);
            BoekingToevoegen.Parameters.AddWithValue("@Boekingdatum", DateTime.Now);
            BoekingToevoegen.Parameters.AddWithValue("@prijs", boekingDTO.TotaalPrijs);

            dbs.ExecuteQuery(BoekingToevoegen);
        }
    }
}
