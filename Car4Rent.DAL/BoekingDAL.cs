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
            string column = "BoekingNr";

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
            SqlCommand getAllByGebruiker = new SqlCommand("select b.BoekingNr, b.AutoID, b.HuurderID, a.Merk, a.type_ as type, b.Begindatum, b.Einddatum, b.boekingDatum, b.prijs from Boeking b " +
                                                          "inner join Auto_ a on a.AutoID = b.AutoID " +
                                                          $"where b.HuurderID = @id");

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
        
        public BoekingDTO GetByID(int id)
        {
            SqlCommand getByID = new SqlCommand("select b.BoekingNr, b.AutoID, b.HuurderID, a.Merk, a.type_ as type, b.Begindatum, b.Einddatum, b.boekingDatum, b.prijs from Boeking b " +
                                                "inner join Auto_ a on a.AutoID = b.AutoID " +
                                               $"where b.BoekingNr = @id");

            getByID.Parameters.AddWithValue("@id", id);

            DataTable dataTable = dbs.Query(getByID);
            BoekingDTO boekingDTO = new BoekingDTO();

            foreach (DataRow dataRow in dataTable.Rows)
            {
                boekingDTO = BoekingDTOfill(boekingDTO, dataRow);
            }

            return boekingDTO;
        }
       

        public void Delete(BoekingDTO boekingDTO)
        {
            SqlCommand DeleteBoeking = new SqlCommand("DELETE from Boeking " +
                                                      "where BoekingNr = @BoekingNr");

            DeleteBoeking.Parameters.AddWithValue("@BoekingNr", boekingDTO.ID);

            dbs.ExecuteQuery(DeleteBoeking);
        }

        public bool CheckUpdateDAL(int id, string begindatum, string einddatum)
        {
            string test = "select distinct autoID, iif(AutoID not in (select distinct AutoID from boeking " +
                          "where '@begindatum' <= Einddatum and Begindatum <= '@einddatum'), 'true', 'false') as available from boeking " +
                         "where autoID = @autoID";

            SqlCommand Checkupdate = new SqlCommand("select distinct autoID, iif(AutoID not in (select distinct AutoID from boeking " +
                                                    "where @begindatum <= Einddatum and Begindatum <= @einddatum), 'true', 'false') as available from boeking " +
                                                    "where autoID = @autoID");

            Checkupdate.Parameters.AddWithValue("@begindatum", begindatum);
            Checkupdate.Parameters.AddWithValue("@einddatum", einddatum);
            Checkupdate.Parameters.AddWithValue("@autoID", id);

            DataTable dataTable = dbs.Query(Checkupdate);
            bool updateAvailable;

            DataRow dataRow = dataTable.Rows[0];
            updateAvailable = Convert.ToBoolean(dataRow["available"]);

            return updateAvailable;
        }

        public void Update(BoekingDTO boekingDTO)
        {
            SqlCommand updateBoeking = new SqlCommand("Update Boeking " +
                                                      $"SET AutoID = @AutoID, HuurderID = @HuurderID, Begindatum = @Begindatum, Einddatum = @einddatum, boekingdatum = @Boekingdatum, prijs = @prijs " +
                                                      $"where BoekingNr = @BoekingNr");

            updateBoeking.Parameters.AddWithValue("@BoekingNr", boekingDTO.ID);
            updateBoeking.Parameters.AddWithValue("@AutoID", boekingDTO.AutoID);
            updateBoeking.Parameters.AddWithValue("@HuurderID", boekingDTO.Huurder);
            updateBoeking.Parameters.AddWithValue("@Begindatum", boekingDTO.Begindatum);
            updateBoeking.Parameters.AddWithValue("@einddatum", boekingDTO.Einddatum);
            updateBoeking.Parameters.AddWithValue("@boekingdatum", boekingDTO.BoekingDatum);
            updateBoeking.Parameters.AddWithValue("@prijs", boekingDTO.TotaalPrijs);

            dbs.ExecuteQuery(updateBoeking);
        }


        private BoekingDTO BoekingDTOfill(BoekingDTO boekingDTO, DataRow datarow)
        {
            boekingDTO.ID = Convert.ToInt32(datarow["BoekingNr"]);
            boekingDTO.AutoID = Convert.ToInt32(datarow["AutoID"]);
            boekingDTO.Huurder = Convert.ToInt32(datarow["HuurderID"]);
            boekingDTO.TotaalPrijs = Convert.ToInt32(datarow["prijs"]);
            boekingDTO.Merk = Convert.ToString(datarow["Merk"]);
            boekingDTO.Type = Convert.ToString(datarow["type"]);
            boekingDTO.Begindatum = Convert.ToString(datarow["Begindatum"]);
            boekingDTO.Einddatum = Convert.ToString(datarow["Einddatum"]);
            boekingDTO.BoekingDatum = Convert.ToString(datarow["BoekingDatum"]);

            return boekingDTO;
        }
    }
}
