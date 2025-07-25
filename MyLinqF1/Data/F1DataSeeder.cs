using MyLinqF1.Models;
using System.Collections.Generic;

namespace MyLinqF1.Data
{
    public static class F1DataSeeder
    {
        public static List<Team> GetTeams() => new List<Team>
        {
            new Team { Id = 1, Name = "Mercedes", Country = "Allemagne" },
            new Team { Id = 2, Name = "Red Bull", Country = "Autriche" },
            new Team { Id = 3, Name = "Ferrari", Country = "Italie" },
            new Team { Id = 4, Name = "McLaren", Country = "Royaume‑Uni" },
            new Team { Id = 5, Name = "Alpine", Country = "France" },
            new Team { Id = 6, Name = "AlphaTauri", Country = "Italie" },
            new Team { Id = 7, Name = "Aston Martin", Country = "Royaume‑Uni" },
            new Team { Id = 8, Name = "Alfa Romeo", Country = "Suisse" },
            new Team { Id = 9, Name = "Haas", Country = "États‑Unis" },
            new Team { Id = 10, Name = "Williams", Country = "Royaume‑Uni" },
        };

        public static List<Pilot> GetPilots() => new List<Pilot>
        {
            new Pilot { Id = 1, FirstName = "Lewis",      LastName = "Hamilton",      Nationality = "Britannique",    TeamId = 1 },
            new Pilot { Id = 2, FirstName = "George",     LastName = "Russell",       Nationality = "Britannique",    TeamId = 1 },
            new Pilot { Id = 3, FirstName = "Max",        LastName = "Verstappen",    Nationality = "Néerlandais",    TeamId = 2 },
            new Pilot { Id = 4, FirstName = "Sergio",     LastName = "Pérez",         Nationality = "Mexicain",       TeamId = 2 },
            new Pilot { Id = 5, FirstName = "Charles",    LastName = "Leclerc",       Nationality = "Monégasque",     TeamId = 3 },
            new Pilot { Id = 6, FirstName = "Carlos",     LastName = "Sainz",         Nationality = "Espagnol",       TeamId = 3 },
            new Pilot { Id = 7, FirstName = "Lando",      LastName = "Norris",        Nationality = "Britannique",    TeamId = 4 },
            new Pilot { Id = 8, FirstName = "Oscar",      LastName = "Piastri",       Nationality = "Australien",     TeamId = 4 },
            new Pilot { Id = 9, FirstName = "Esteban",    LastName = "Ocon",          Nationality = "Français",       TeamId = 5 },
            new Pilot { Id = 10, FirstName = "Pierre",    LastName = "Gasly",         Nationality = "Français",       TeamId = 6 },
            new Pilot { Id = 11, FirstName = "Lance",     LastName = "Stroll",        Nationality = "Canadien",       TeamId = 7 },
            new Pilot { Id = 12, FirstName = "Fernando",  LastName = "Alonso",        Nationality = "Espagnol",       TeamId = 7 },
            new Pilot { Id = 13, FirstName = "Valtteri",  LastName = "Bottas",        Nationality = "Finlandais",     TeamId = 8 },
            new Pilot { Id = 14, FirstName = "Zhou",      LastName = "Guanyu",        Nationality = "Chinois",        TeamId = 8 },
            new Pilot { Id = 15, FirstName = "Kevin",     LastName = "Magnussen",     Nationality = "Danois",         TeamId = 9 },
            new Pilot { Id = 16, FirstName = "Nico",      LastName = "Hülkenberg",    Nationality = "Allemand",       TeamId = 9 },
            new Pilot { Id = 17, FirstName = "Alex",      LastName = "Albon",         Nationality = "Thaïlandais",    TeamId = 10 },
            new Pilot { Id = 18, FirstName = "Logan",     LastName = "Sargeant",      Nationality = "Américain",      TeamId = 10 },
        };
    }
}
