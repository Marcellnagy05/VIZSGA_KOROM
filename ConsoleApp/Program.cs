
namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Auto> autok = Auto.ReadFromCsv();

            //5. Feladat
            Console.Write("5. Feladat:");
            Console.Write($"{autok.Count()} autó található a listában. \n");

            //6. Feladat
            Console.Write("6. Feladat:");
            int osszesen = 0;
            autok.ForEach(auto => {
                osszesen += auto.EladottDb;
            });
            float atlag = osszesen / autok.Count();
            Console.WriteLine($"Az autók esetében az átlagosan eladott darabszám {atlag} \n");

            //7. Feladat
            Console.Write("7. Feladat:\n");
            autok.Where(auto => int.Parse(auto.GyartasiEv) > 2025 - 5).ToList().ForEach(auto =>
            {
                Console.WriteLine($"\t - {auto.Marka} {auto.Modell}: {auto.GyartasiEv}");
            });

            //8. Feladat
            Console.Write("8. Feladat: Legsikeresebb márkák listája az eladott darabszám alapján:\n");
            autok.OrderByDescending(x => x.EladottDb).ToList().ForEach(auto =>
            {
                Console.WriteLine($"\t - {auto.Marka}: {auto.EladottDb} darab");
            });
        }
    }
}
