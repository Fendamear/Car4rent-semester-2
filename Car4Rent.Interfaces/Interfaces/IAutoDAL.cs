using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;

namespace Car4Rent.Interfaces.Interfaces
{
    public interface IAutoDAL
    {
        List<AutoDTO> GetAll(string begindatum, string einddatum);

        List<AutoDTO> GetAllByGebruiker(int id);

        AutoDTO GetByID(int autoID);
        void AutoToevoegen(AutoDTO autoDTO);

        void Delete(int AutoID);
    }
}
