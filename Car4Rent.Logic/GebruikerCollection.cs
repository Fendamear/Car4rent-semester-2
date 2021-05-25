using System;
using System.Collections.Generic;
using System.Text;
using Car4Rent.Interfaces.Interfaces;
using Car4Rent.Interfaces.DTO;
using Car4rent.Factory;

namespace Car4Rent.Logic
{
    public class GebruikerCollection
    {
        private IGebruikerDAL GebruikerDataAcces = GebruikerFactory.GetGebruikerDAL();


        public Gebruiker GetGebruikerByEmail(string email)
        {
            return DTOToGebruiker(GebruikerDataAcces.GetGebruikerByEmail(email));
        }

        private Gebruiker DTOToGebruiker(GebruikerDTO gebruikerDTO)
        {
            Gebruiker gebruiker = new Gebruiker();
            gebruiker.GebruikerID = gebruikerDTO.GebruikerID;
            gebruiker.Naam = gebruikerDTO.Naam;
            gebruiker.Email = gebruikerDTO.Email;
            gebruiker.Wachtwoord = gebruikerDTO.Wachtwoord;
            gebruiker.Telnummer = gebruiker.Telnummer;
            gebruiker.Adres = gebruiker.Adres;

            return gebruiker;
        }

        private GebruikerDTO GebruikerToDTO(Gebruiker gebruiker)
        {
            GebruikerDTO gebruikerDTO = new GebruikerDTO();
            gebruikerDTO.Naam = gebruiker.Naam;
            gebruikerDTO.Email = gebruiker.Email;
            gebruikerDTO.GebruikersNaam = gebruiker.GebruikersNaam;
            gebruikerDTO.BetaalGegevens = gebruiker.BetaalGegevens;
            gebruikerDTO.Wachtwoord = gebruiker.Wachtwoord;
            gebruikerDTO.Telnummer = gebruiker.Telnummer;
            gebruikerDTO.Adres = gebruiker.Adres;
            gebruikerDTO.regio = gebruiker.regio;

            return gebruikerDTO;
        }


        public void CreateGebruiker(Gebruiker gebruiker)
        {
            GebruikerDTO gebruikerDTO = GebruikerToDTO(gebruiker);

            GebruikerDataAcces.Create(gebruikerDTO);
        }




    }
}
