using MyLinqF1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLinqF1.Services
{
    public class QueryService
    {
        private readonly List<Team> _teams;
        private readonly List<Pilot> _pilots;

        public QueryService(List<Team> teams, List<Pilot> pilots)
        {
            _teams  = teams;
            _pilots = pilots;
        }

        public void ShowAllTeams() =>
            _teams.ForEach(t => Console.WriteLine($"{t.Id}: {t.Name} ({t.Country})"));

        public void ShowPilotsByTeam(string teamName)
        {
            var q = from p in _pilots
                join t in _teams on p.TeamId equals t.Id
                where t.Name.Contains(teamName, StringComparison.OrdinalIgnoreCase)
                select new { t.Name, Pilot = $"{p.FirstName} {p.LastName}" };

            foreach (var item in q)
                Console.WriteLine($"{item.Name} → {item.Pilot}");
        }

        public void GroupPilotsByNationality()
        {
            var grouped = _pilots
                .GroupBy(p => p.Nationality)
                .Select(g => new { Nationality = g.Key, Count = g.Count() });

            foreach (var g in grouped)
                Console.WriteLine($"{g.Nationality}: {g.Count}");
        }
    }
}