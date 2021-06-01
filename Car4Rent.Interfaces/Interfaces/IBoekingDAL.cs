using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.DTO;

namespace Car4Rent.Interfaces.Interfaces
{
    public interface IBoekingDAL
    {
        void BoekingToevoegen(BoekingDTO boekingDTO);

        List<BoekingDTO> GetAllByGebruiker(int id);
    }
}
