using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;

namespace Car4Rent.Interfaces.Interfaces
{
    public interface IAutoDAL
    {
        List<AutoDTO> GetAll();

        AutoDTO GetByID(int autoID);
        void AutoToevoegen(AutoDTO autoDTO);

    }
}
