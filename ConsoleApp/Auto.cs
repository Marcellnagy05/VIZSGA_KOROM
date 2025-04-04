using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class Auto
    {
        public int Sorszam { get; set; }
        public string Marka { get; set; }
        public string Modell { get; set; }
        public string GyartasiEv { get; set; }
        public string Szin { get; set; }
        public int EladottDb { get; set; }
        public int AtlagEladasiAr { get; set; }
        public Auto(string line)
        {
            string[] fields = line.Split(';');

            Sorszam = int.Parse(fields[0]);
            Marka = fields[1];
            Modell = fields[2];
            GyartasiEv = fields[3];
            Szin = fields[4];
            EladottDb = int.Parse(fields[5]);
            AtlagEladasiAr = int.Parse(fields[6]);
        }


        public static List<Auto> ReadFromCsv()
        {
            List<Auto> autok = new List<Auto>();
            using (StreamReader sr = new StreamReader("autok.csv"))
            {
                bool elsoSor = true;

                while (!sr.EndOfStream)
                {
                    string sor = sr.ReadLine();

                    if (elsoSor)
                    {
                        elsoSor = false;
                        continue;
                    }

                    Auto auto = new Auto(sor);
                    autok.Add(auto);
                }
            }
            return autok;
        }
    }
}
