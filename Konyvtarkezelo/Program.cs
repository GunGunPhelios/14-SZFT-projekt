namespace Konyvtarkezelo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Konyv> konyvtar = new List<Konyv>();
            string fajlNeve = "konyvtar.txt";

            if (!File.Exists(fajlNeve))
            {
                Console.WriteLine("Hiba! A fájl nem található.");
                return;


            }
            konyvtar = File.ReadAllLines(fajlNeve)
    .Where(sor => !string.IsNullOrWhiteSpace(sor))
    .Select(sor => sor.Split(";"))
    .Where(adatok => adatok.Length == 5)
    .Select(adatok => new Konyv(
        adatok[0].Trim(),
        adatok[1].Trim(),
        adatok[2].Trim(),
        int.Parse(adatok[3].Trim()),
        int.Parse(adatok[4].Trim())
    ))
    .ToList();


            if (konyvtar.Count > 0)
            {
                Console.WriteLine("A fájlt sikeresen beolvastuk");
            }

            //2. fájl teljes tartalmának kiírása
            Console.WriteLine("Könyvtár tartalma:");
            konyvtar.ForEach(konyv => Console.WriteLine(konyv));

            //3. A könyvek számának meghatározása
            Console.WriteLine($"A könyvtárban található könyvek száma: {konyvtar.Count}");

            //4. Könyv kategóriák szerinti csoportosítása

            var kategoriaCsoport = konyvtar.GroupBy(k => k.Kategoria);
            foreach (var csoport in kategoriaCsoport)

                Console.WriteLine($" {csoport.Key}: {csoport.Count()} könyv ");


            // 5. A leghosszabb könyv 

            int maxOldalszam = konyvtar.Max(k => k.Oldalszam);
            var leghosszabbKonyvek = konyvtar.Where(k => k.Oldalszam == maxOldalszam).ToList();

            if (leghosszabbKonyvek.Count == 1)
            {
                Console.WriteLine($"A leghosszabb könyv: {leghosszabbKonyvek[0]}");

            }
            else
            {
                Console.WriteLine("Leghosszabb könyvek:");
                leghosszabbKonyvek.ForEach(k => Console.WriteLine($"{k.Cim} - {k.Oldalszam}"));

            }
                //6. Az 1950 után kiadott könyvek listázása

                Console.WriteLine("\n\n1950 után ki adott könyvek:");

                var ujabbKonyvek = konyvtar.Where(k => k.Kiadas_ev > 1950).OrderBy(k => k.Kiadas_ev).ToList();
                ujabbKonyvek.ForEach(k=> Console.WriteLine($"{k.Cim} - {k.Kiadas_ev}"));
            
        }

    }
}
