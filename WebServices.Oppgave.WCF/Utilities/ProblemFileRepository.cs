using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace eCademy.NUh15.WebServices.Oppgave.WCF.Utilities
{
    public class ProblemFileRepository
    {
        private string dataFilepath;

        public ProblemFileRepository(string dataFilename)
        {
            dataFilepath = Path.Combine(
                HttpContext.Current.Server.MapPath("~/App_Data"),
                dataFilename
            );
        }

        public List<NeighbourhoodProblem> GetAll()
        {
            return File.ReadAllLines(dataFilepath)
                .Select(Deserialize)
                .OrderByDescending(problem => problem.Registered)
                .ToList();
        }

        public void Add(NeighbourhoodProblem problem)
        {
            var line = Serialize(problem);
            using (var writer = File.AppendText(dataFilepath))
            {
                writer.WriteLine(line);
            }
        }

        private const char ColumnDelimiterChar = '|';
        private static readonly string ColumnDelimiterString = ColumnDelimiterChar.ToString();

        private const int NumberOfColumns = 6;

        private const int RegisteredColumn = 0;
        private const int LatitudeColumn = 1;
        private const int LongditudeColumn = 2;
        private const int LocationNameColumn = 3;
        private const int DescriptionColumn = 4;
        private const int ReporterColumn = 5;


        public static string Serialize(NeighbourhoodProblem problem)
        {
            var columns = new string[NumberOfColumns];

            columns[RegisteredColumn] = problem.Registered.ToBinary().ToString();
            columns[LatitudeColumn] = problem.Location.Latitude.ToString();
            columns[LongditudeColumn] = problem.Location.Longditude.ToString();
            columns[LocationNameColumn] = problem.Location.Name;
            columns[DescriptionColumn] = problem.Description;
            columns[ReporterColumn] = problem.Reporter;

            var row = string.Join(ColumnDelimiterString, columns);

            return row;
        }

        public static NeighbourhoodProblem Deserialize(string row)
        {
            var columns = row.Split(ColumnDelimiterChar);
            var problem = new NeighbourhoodProblem
            {
                Registered = DateTime.FromBinary(long.Parse(columns[RegisteredColumn])),
                Location = new GeoLocation
                {
                    Latitude = double.Parse(columns[LatitudeColumn]),
                    Longditude = double.Parse(columns[LongditudeColumn]),
                    Name = columns[LocationNameColumn]
                },
                Description = columns[DescriptionColumn],
                Reporter = columns[ReporterColumn]
            };
            return problem;
        }
    }
}