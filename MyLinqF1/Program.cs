// Program.cs
// Les exports sont générés dans le dossier Data/Output du projet (relatif à la racine du projet).
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MyLinqF1.Data;
using MyLinqF1.Models;
using MyLinqF1.Services;
using MyLinqF1.Utils;

namespace MyLinqF1
{
    class Program
    {
        static void Main(string[] args)
        {
            var teams = F1DataSeeder.GetTeams();
            var pilots = F1DataSeeder.GetPilots();
            var queryService = new QueryService(teams, pilots);

            var outputDir = Path.Combine("Data", "Output");
            if (!Directory.Exists(outputDir))
                Directory.CreateDirectory(outputDir);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== Menu Principal ===");
                Console.WriteLine("1. Afficher toutes les écuries");
                Console.WriteLine("2. Afficher pilotes par écurie");
                Console.WriteLine("3. Nombre de pilotes par nationalité");
                Console.WriteLine("4. Exporter");
                Console.WriteLine("0. Quitter");
                int choice = ConsoleHelper.PromptInt("Choix > ", 0, 4);

                Console.Clear();
                switch (choice)
                {
                    case 1: queryService.ShowAllTeams(); break;
                    case 2:
                        string teamName = ConsoleHelper.PromptString("Nom de l'écurie : ");
                        queryService.ShowPilotsByTeam(teamName);
                        break;
                    case 3: queryService.GroupPilotsByNationality(); break;
                    case 4: ShowExportMenu(teams, pilots, outputDir); break;
                    case 0: return;
                }
                ConsoleHelper.Pause();
            }
        }

        private static void ShowExportMenu(List<Team> teams, List<Pilot> pilots, string outputDir)
        {
            Console.Clear();
            Console.WriteLine("=== Menu Export ===");
            Console.WriteLine("Les fichiers seront créés dans Data/Output");
            Console.WriteLine("1. Exporter toutes les écuries");
            Console.WriteLine("2. Exporter tous les pilotes");
            Console.WriteLine("3. Exporter pilotes d'une écurie");
            Console.WriteLine("0. Retour");
            int exportChoice = ConsoleHelper.PromptInt("Choix export > ", 0, 3);
            switch (exportChoice)
            {
                case 1:
                    ExportService.ExportAllFormats(
                        teams.Cast<object>().ToList(),
                        new[] { "Id", "Name", "Country" },
                        new Func<object,string>[]
                        {
                            o => ((Team)o).Id.ToString(),
                            o => ((Team)o).Name,
                            o => ((Team)o).Country
                        },
                        Path.Combine(outputDir, "teams")
                    );
                    break;
                case 2:
                    ExportService.ExportAllFormats(
                        pilots.Cast<object>().ToList(),
                        new[] { "Id", "FirstName", "LastName", "Nationality", "TeamId" },
                        new Func<object,string>[]
                        {
                            o => ((Pilot)o).Id.ToString(),
                            o => ((Pilot)o).FirstName,
                            o => ((Pilot)o).LastName,
                            o => ((Pilot)o).Nationality,
                            o => ((Pilot)o).TeamId.ToString()
                        },
                        Path.Combine(outputDir, "pilots")
                    );
                    break;
                case 3:
                    string filter = ConsoleHelper.PromptString("Nom de l'écurie : ");
                    var filtered = pilots.Join(teams, p => p.TeamId, t => t.Id,
                                        (p,t) => new { p, t.Name })
                                        .Where(x => x.Name.Equals(filter, StringComparison.OrdinalIgnoreCase))
                                        .Select(x => x.p)
                                        .Cast<object>().ToList();
                    ExportService.ExportAllFormats(
                        filtered,
                        new[] { "Id", "FirstName", "LastName", "Nationality", "TeamId" },
                        new Func<object,string>[]
                        {
                            o => ((Pilot)o).Id.ToString(),
                            o => ((Pilot)o).FirstName,
                            o => ((Pilot)o).LastName,
                            o => ((Pilot)o).Nationality,
                            o => ((Pilot)o).TeamId.ToString()
                        },
                        Path.Combine(outputDir, $"{filter}_pilots")
                    );
                    break;
                case 0: return;
            }
        }
    }
}


