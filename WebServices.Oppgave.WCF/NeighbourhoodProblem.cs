using System;

namespace eCademy.NUh15.WebServices.Oppgave.WCF
{
    public class NeighbourhoodProblem
    {
        public string Reporter { get; set; }

        public string Description { get; set; }

        public GeoLocation Location { get; set; }

        public DateTime Registered { get; set; }
    }
}