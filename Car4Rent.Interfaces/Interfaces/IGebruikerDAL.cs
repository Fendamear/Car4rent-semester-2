using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.DTO;

namespace Car4Rent.Interfaces.Interfaces
{
    public interface IGebruikerDAL
    {
        GebruikerDTO GetGebruikerByEmail(string email);

        void Create(GebruikerDTO gebruikerDTO);
    }
}
