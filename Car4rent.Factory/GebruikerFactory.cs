using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.DAL;

namespace Car4rent.Factory
{
    public class GebruikerFactory
    {
        public static IGebruikerDAL GetGebruikerDAL()
        {
            return new GebruikerDAL();
        }
    }
}
