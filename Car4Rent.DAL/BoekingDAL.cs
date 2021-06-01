using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces.DTO;
using System.Data.SqlClient;
using System.Data;

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

        public List<BoekingDTO> GetAllByGebruiker(int id)
        {
            SqlCommand getAllByGebruiker = new SqlCommand($"select BoekingNr, AutoID, HuurderID, Begindatum, Einddatum, BoekingDatum, prijs from Boeking" +
                                                          $"where HuurderID = @id");

            getAllByGebruiker.Parameters.AddWithValue("@id", id);

            DataTable dataTable = dbs.Query(getAllByGebruiker);
            List<BoekingDTO> boekingDTOs = new List<BoekingDTO>();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                BoekingDTO boekingDTO = new BoekingDTO();
                boekingDTOs.Add(BoekingDTOfill(boekingDTO, dataRow));
            }

            return boekingDTOs;
        }

        private BoekingDTO BoekingDTOfill(BoekingDTO boekingDTO, DataRow datarow)
        {
            boekingDTO.ID = Convert.ToInt32(datarow["BoekingNr"]);
            boekingDTO.AutoID = Convert.ToInt32(datarow["AutoID"]);
            boekingDTO.Huurder = Convert.ToInt32(datarow["HuurderID"]);
            boekingDTO.TotaalPrijs = Convert.ToInt32(datarow["prijs"]);
            boekingDTO.Begindatum = Convert.ToString(datarow["Begindatum"]);
            boekingDTO.Einddatum = Convert.ToString(datarow["Einddatum"]);
            boekingDTO.BoekingDatum = Convert.ToString(datarow["BoekingDatum"]);

            return boekingDTO;
        }
    }
}
