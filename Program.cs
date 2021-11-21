using System;

namespace Census
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            var myDictionary = new Dictionary<string, Tuple<string, DateTime, string>>();
            {
                myDictionary.Add("01234567891", new Tuple<string, DateTime, string>(
                    "Mate Matić", new DateTime(2000, 1, 1), "zaposlen"));
                myDictionary.Add("01334577892", new Tuple<string, DateTime, string>(
                    "Ana Anić", new DateTime(2002, 10, 1), "zaposlen"));
                myDictionary.Add("02135568893", new Tuple<string, DateTime, string>(
                    "Luka Lukić", new DateTime(1999, 8, 12), "nezaposlen"));
                myDictionary.Add("02135777893", new Tuple<string, DateTime, string>(
                    "Luka Matić", new DateTime(1999, 8, 24), "nezaposlen"));
                myDictionary.Add("02135777888", new Tuple<string, DateTime, string>(
                    "Eva Ević", new DateTime(1999, 8, 24), "zaposlen"));
                myDictionary.Add("02200777888", new Tuple<string, DateTime, string>(
                    "Lana Lanić", new DateTime(1963, 12, 25), "zaposlen"));

            };

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu(myDictionary);
            }
        }
        private static bool MainMenu(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Ispis stanovnistva");
            Console.WriteLine("2 - Ispis stanovnika po OIB-u");
            Console.WriteLine("3 - Ispis OIB-a po unosu imena i prezimena");
            Console.WriteLine("4 - Unos novog stanovnika");
            Console.WriteLine("5 - Brisanje stanovnika po OIB-u");
            Console.WriteLine("6 - Brisanje stanovnika po imenu i prezimenu te datumu rodenja");
            Console.WriteLine("7 - Brisanje svih stanovnika");
            Console.WriteLine("8 - Uredivanje stanovnika");
            Console.WriteLine("9 - Statistika");
            Console.WriteLine("0 - Izlaz iz aplikacije");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintoutOfThePopulation(myDictionary);
                    return true;
                case "2":
                    PrintoutOfThePopulationByOIB(myDictionary);
                    return true;
                case "3":
                    PrintoutOfThePopulationByName(myDictionary);
                    return true;
                case "4":
                    AddingNewElement(myDictionary);
                    return true;
                case "5":
                    DeleteElementByOIB(myDictionary);
                    return true;
                case "6":
                    DeleteElementByName(myDictionary);
                    return true;
                case "7":
                    DeleteAllElements(myDictionary);
                    return true;
                case "8":
                    EditingElements(myDictionary);
                    return true;
                case "9":
                    Statistics(myDictionary);
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        private static void PrintoutOfThePopulation(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu1(myDictionary);
            }
        }
        private static bool MainMenu1(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Onako kako su spremljeni");
            Console.WriteLine("2 - Po datumu rodenja uzlazno");
            Console.WriteLine("3 - Po datumu rodenja silazno");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintoutOfThePopulationBySaving(myDictionary);
                    return true;
                case "2":
                    PrintoutOfThePopulationByDateUpward(myDictionary);
                    return true;
                case "3":
                    PrintoutOfThePopulationByDateDownward(myDictionary);
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        private static void PrintoutOfThePopulationBySaving(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                if (value.Item3 == "zaposlen")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(item.Key + item.Value);
            }
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void PrintoutOfThePopulationByDateUpward(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<DateTime> list = new List<DateTime>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                list.Add(value.Item2);
            }
            var list2 = list.OrderBy(x => x.Year).ToList();
            HashSet<DateTime> newlist = new HashSet<DateTime>(list2);
            List<DateTime> listWithoutDuplicates = newlist.ToList();
            foreach (var item in listWithoutDuplicates)
            {
                foreach (var item2 in myDictionary)
                {
                    Tuple<string, DateTime, string> value = myDictionary[item2.Key];
                    if (value.Item2 == item)
                    {
                        if (value.Item3 == "zaposlen")
                            Console.ForegroundColor = ConsoleColor.Green;
                        else
                            Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(myDictionary[item2.Key]);
                    }
                }
            }
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void PrintoutOfThePopulationByDateDownward(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<DateTime> list = new List<DateTime>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                list.Add(value.Item2);
            }
            var list2 = list.OrderBy(x => x.Year).ToList();
            List<string> listOfKey = new List<string>();
            HashSet<DateTime> newlist = new HashSet<DateTime>(list2);
            List<DateTime> listWithoutDuplicates = newlist.ToList();
            foreach (var item in listWithoutDuplicates)
            {
                foreach (var item2 in myDictionary)
                {
                    Tuple<string, DateTime, string> value = myDictionary[item2.Key];
                    if (value.Item2 == item)
                        listOfKey.Add(item2.Key);
                }
            }
            listOfKey.Reverse();
            foreach (var item in listOfKey)
            {
                Tuple<string, DateTime, string> value = myDictionary[item];
                if (value.Item3 == "zaposlen")
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(myDictionary[item]);
            }
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void PrintoutOfThePopulationByOIB(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            string OIB = Console.ReadLine();
            if (myDictionary.ContainsKey(OIB) == false)
            {
                Console.WriteLine("Nema stanovnika pod tim OIB-om! Pokusajte ponovo.");
                OIB = Console.ReadLine();
            }
            Tuple<string, DateTime, string> value = myDictionary[OIB];
            Console.WriteLine(value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void PrintoutOfThePopulationByName(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite ime i prezime: ");
            string name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ime i prezime ne moze biti prazno! Molim vas ponovo unesite.");
                name = Console.ReadLine();
            }
            Console.Write("\r\nUnesite datum rodenja u obliku godina/mjesec/dan: ");
            DateTime dateOFBirth = Convert.ToDateTime(Console.ReadLine());
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                if (name != value.Item1 & dateOFBirth != value.Item2)
                {
                    Console.WriteLine("Nema stanovnika pod tim imenom i prezimenom, te datumom rodenja! Pokusajte ponovo.");
                    name = Console.ReadLine();
                    dateOFBirth = Convert.ToDateTime(Console.ReadLine());
                }
                Console.WriteLine("OIB: " + item.Key);
                Console.ReadLine();
            }
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void AddingNewElement(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            var OIB = Console.ReadLine();
            Console.Write("\r\nUnesite ime i prezime: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Ime i prezime ne moze biti prazno! Molim vas ponovo unesite.");
                name = Console.ReadLine();
            }
            Console.Write("\r\nUnesite datum rodenja u obliku godina/mjesec/dan: ");
            DateTime dateOFBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\r\nUnesite stanje zaposlenja: ");
            var employmentStatus = Console.ReadLine();

            myDictionary.Add(OIB, new Tuple<string, DateTime, string>(
                    name, dateOFBirth, employmentStatus));
            Console.WriteLine("Popis stanovnika nakon dodavanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void DeleteElementByOIB(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            string OIB = Console.ReadLine();
            if (myDictionary.ContainsKey(OIB) == false)
            {
                Console.WriteLine("Nema stanovnika pod tim OIB-om! Pokusajte ponovo.");
                OIB = Console.ReadLine();
            }
            myDictionary.Remove(OIB);
            Console.WriteLine("Popis stanovnika nakon brisanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + " " + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void DeleteElementByName(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite Ime i Prezime: ");
            string name = Console.ReadLine();
            Console.Write("\r\nUnesite datum rodenja u obliku godina/mjesec/dan: ");
            DateTime dateOFBirth = Convert.ToDateTime(Console.ReadLine());
            Console.Write("\r\nUnesite status zaposlenja: ");
            string employmentStatus = Console.ReadLine();
            
            var myTuple = new Tuple<string, DateTime, string>(name, dateOFBirth, employmentStatus);
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                if (name == value.Item1 & dateOFBirth == value.Item2 & employmentStatus == value.Item3)
                    myDictionary.Remove(item.Key);
            }
            Console.WriteLine("Popis stanovnika nakon brisanja: ");
            foreach (var item2 in myDictionary)
                Console.WriteLine(item2.Key + item2.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void DeleteAllElements(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            myDictionary.Clear();
            Console.WriteLine("Popis stanovnika nakon brisanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void EditingElements(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu2(myDictionary);
            }
        }
        private static bool MainMenu2(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 - Uredi OIB stanovnika");
            Console.WriteLine("2 - Uredi ime i prezime stanovnika");
            Console.WriteLine("3 - Uredi datum rođenja");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditOIB(myDictionary);
                    return true;
                case "2":
                    EditName(myDictionary);
                    return true;
                case "3":
                    EditDateOfBirth(myDictionary);
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        private static void EditOIB(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            string OIB = Console.ReadLine();
            if (myDictionary.ContainsKey(OIB) == false)
            {
                Console.WriteLine("Nema stanovnika pod tim OIB-om! Pokusajte ponovo.");
                OIB = Console.ReadLine();
            }
            Console.Write("\r\nUnesite novi OIB: ");
            string newOIB = Console.ReadLine();
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = SecondaryMenu(myDictionary, OIB, newOIB);
            }
        }
        private static bool SecondaryMenu(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, string newOIB)
        {
            Console.Clear();
            Console.WriteLine("Potvrdite odabranu akciju:");
            Console.WriteLine("1 - Da");
            Console.WriteLine("2 - Ne, povratak na izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditOIBAddition(myDictionary, OIB, newOIB);
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }
        private static void EditOIBAddition(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, string newOIB)
        {
            Console.Clear();
            Tuple<string, DateTime, string> value = myDictionary[OIB];
            myDictionary.Remove(OIB);
            myDictionary.Add(newOIB, value);
            Console.WriteLine("Popis stanovnika nakon uredivanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void EditName(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            string OIB = Console.ReadLine();
            if (myDictionary.ContainsKey(OIB) == false)
            {
                Console.WriteLine("Nema stanovnika pod tim OIB-om! Pokusajte ponovo.");
                OIB = Console.ReadLine();
            }
            Console.Write("\r\nUnesite novo ime i prezime: ");
            string newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Ime i prezime ne moze biti prazno! Molim vas ponovo unesite.");
                newName = Console.ReadLine();
            }
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = SecondaryMenu2(myDictionary, OIB, newName);
            }
        }
        private static bool SecondaryMenu2(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, string newName)
        {
            Console.Clear();
            Console.WriteLine("Potvrdite odabranu akciju:");
            Console.WriteLine("1 - Da");
            Console.WriteLine("2 - Ne, povratak na izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditNameAddition(myDictionary, OIB, newName);
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }
        private static void EditNameAddition(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, string newName)
        {
            Console.Clear();
            Tuple<string, DateTime, string> value = myDictionary[OIB];
            DateTime dateOfBirth = value.Item2;
            string employmentStatus = value.Item3;
            myDictionary.Remove(OIB);
            myDictionary.Add(OIB, new Tuple<string, DateTime, string>(
                    newName, dateOfBirth, employmentStatus));
            Console.WriteLine("Popis stanovnika nakon uredivanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void EditDateOfBirth(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.Write("\r\nUnesite OIB: ");
            string OIB = Console.ReadLine();
            if (myDictionary.ContainsKey(OIB) == false)
            {
                Console.WriteLine("Nema stanovnika pod tim OIB-om! Pokusajte ponovo.");
                OIB = Console.ReadLine();
            }
            Console.Write("\r\nUnesite novi datum rodenja u obliku godina/mjesec/dan: ");
            DateTime dateOFBirth = Convert.ToDateTime(Console.ReadLine());
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = SecondaryMenu3(myDictionary, OIB, dateOFBirth);
            }
        }
        private static bool SecondaryMenu3(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, DateTime dateOfBirth)
        {
            Console.Clear();
            Console.WriteLine("Potvrdite odabranu akciju:");
            Console.WriteLine("1 - Da");
            Console.WriteLine("2 - Ne, povratak na izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    EditDateOfBirthAddition(myDictionary, OIB, dateOfBirth);
                    return true;
                case "2":
                    return false;
                default:
                    return true;
            }
        }
        private static void EditDateOfBirthAddition(Dictionary<string, Tuple<string, DateTime, string>> myDictionary, string OIB, DateTime dateOFBirth)
        {
            Console.Clear();
            Tuple<string, DateTime, string> value = myDictionary[OIB];
            string name = value.Item1;
            string employmentStatus = value.Item3;
            myDictionary.Remove(OIB);
            myDictionary.Add(OIB, new Tuple<string, DateTime, string>(
                    name, dateOFBirth, employmentStatus));
            Console.WriteLine("Popis stanovnika nakon uredivanja: ");
            foreach (var item in myDictionary)
                Console.WriteLine(item.Key + item.Value);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void Statistics(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu3(myDictionary);
            }
        }
        private static bool MainMenu3(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            Console.WriteLine("Odaberite akciju:");
            Console.WriteLine("1 -  Postotak nezaposlenih (od 0 do 23 godine i od 65 do 100 godine) i postotak zaposlenih (od 23 do 65 godine)");
            Console.WriteLine("2 - Ispis najcesceg imena i koliko ga stanovnika ima");
            Console.WriteLine("3 - Ispis najcesceg prezimena i koliko ga stanovnika ima");
            Console.WriteLine("4 - Ispis datuma na koji je rođen najveći broj ljudi i koji je to datum");
            Console.WriteLine("5 - Ispis broja ljudi rođenih u svakom od godišnjih doba (poredat godišnja doba s obzirom na broj ljudi rođenih u istim)");
            Console.WriteLine("6 - Ispis najmlađeg stanovnika");
            Console.WriteLine("7 - Ispis najstarijeg stanovnika");
            Console.WriteLine("8 - Prosječan broj godina (na 2 decimale)");
            Console.WriteLine("9 - Medijan godina");
            Console.WriteLine("0 - Povratak na glavni izbornik");
            Console.Write("\r\nUnesite odabir: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PercentageOfUnemployed(myDictionary);
                    return true;
                case "2":
                    MostOftenName(myDictionary);
                    return true;
                case "3":
                    MostOftenSurname(myDictionary);
                    return true;
                case "4":
                    MostOftenDateOfBirth(myDictionary);
                    return true;
                case "5":
                    Seasons(myDictionary);
                    return true;
                case "6":
                    YoungestPerson(myDictionary);
                    return true;
                case "7":
                    OldestPerson(myDictionary);
                    return true;
                case "8":
                    PercentageOfAge(myDictionary);
                    return true;
                case "9":
                    MedianOfYear(myDictionary);
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }
        private static void PercentageOfUnemployed(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            double countEmployed = 0;
            double countUnemployed = 0;
            double countUnemployed2 = 0;
            var today = DateTime.Today;
            List<string> list = new List<string>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                DateTime birthyear = value.Item2;
                var age = today.Year - birthyear.Year;
                
                if (0 <= age && age <= 23)
                {   
                    if (value.Item3 == "nezaposlen")
                        countUnemployed += 1;
                }
                if (65 <= age && age <= 100)
                {
                    if (value.Item3 == "nezaposlen")
                        countUnemployed2 += 1;
                }
                if (23 <= age && age <= 100)
                {
                    if (value.Item3 == "zaposlen")
                        countEmployed += 1;
                }
            }
            double count = myDictionary.Count;
            Console.WriteLine("Postotak nezaposlenih od 0 do 23 godina iznosi: " + (countUnemployed/count)*100 + " %.");
            Console.WriteLine("Postotak nezaposlenih od 65 do 100 godina iznosi: " + (countUnemployed2 / count) * 100 + " %.");
            Console.WriteLine("Postotak zaposlenih od 23 do 65 godina iznosi: " + (countEmployed / count) * 100 + " %.");
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void MostOftenName(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<string> list = new List<string>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                var str1 = (value.Item1 + " ").Split(' ');
                var name = str1[0];
                list.Add(name);
            }
            var groupsWithCounts = from s in list
                                   group s by s into g
                                   select new
                                   {
                                       Item = g.Key,
                                       Count = g.Count()
                                   };

            var groupsSorted = groupsWithCounts.OrderByDescending(g => g.Count);
            string mostFrequest = groupsSorted.First().Item;
            int count = 0;
            foreach (var item in list)
            {
                if (item == mostFrequest)
                    count++;
            }
            Console.WriteLine("Najcesce ime je " + mostFrequest + ", te ga ima " + count + " stanovnika.");
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void MostOftenSurname(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<string> list = new List<string>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                var str1 = (value.Item1 + " ").Split(' ');
                var surname = str1[1];
                list.Add(surname);
            }
            var groupsWithCounts = from s in list
                                   group s by s into g
                                   select new
                                   {
                                       Item = g.Key,
                                       Count = g.Count()
                                   };

            var groupsSorted = groupsWithCounts.OrderByDescending(g => g.Count);
            string mostFrequest = groupsSorted.First().Item;
            int count = 0;
            foreach (var item in list)
            {
                if (item == mostFrequest)
                    count++;
            }
            Console.WriteLine("Najcesce prezime je " + mostFrequest+ ", te ga ima " + count + " stanovnika.");
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void MostOftenDateOfBirth(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<DateTime> list = new List<DateTime>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                list.Add(value.Item2);
            }
            var groupsWithCounts = from s in list
                                   group s by s into g
                                   select new
                                   {
                                       Item = g.Key,
                                       Count = g.Count()
                                   };

            var groupsSorted = groupsWithCounts.OrderByDescending(g => g.Count);
            DateTime mostFrequest = groupsSorted.First().Item;
            Console.WriteLine("Najcesci datum rodenja je: " + mostFrequest);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void Seasons(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            int countWinter = 0;
            int countSpring = 0;
            int countSummer = 0;
            int countAutumn = 0;
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                DateTime birthyear = value.Item2;
                int month =  birthyear.Month;
                int day = birthyear.Day;
                
                if (month == 1)
                    countWinter++;
                
                else if (month == 2)
                    countWinter++ ;
                
                else if (month == 3)
                {
                    if (1 <= day && day <= 20)
                        countWinter++;

                    else if (21 <= day && day <= 31)
                        countSpring++;
                }
                else if (month == 4)
                    countSpring++;

                else if (month == 5)
                    countSpring++;

                else if (month == 6)
                {
                    if (1 <= day && day <= 20)
                        countSpring++;

                    else if (21 <= day && day <= 30)
                        countSummer++;
                }

                else if (month == 7)
                    countSummer++;

                else if (month == 8)
                    countSummer++;

                else if (month == 9)
                {
                    if (1 <= day && day <= 22)
                        countSpring++;

                    else if (23 <= day && day <= 30)
                        countAutumn++;
                }

                else if (month == 10)
                    countAutumn++;

                else if (month == 11)
                    countAutumn++;

                else if (month == 12)
                {
                    if (1 <= day && day <= 20)
                        countAutumn++;
                    else if  (21 <= day && day <= 31)
                        countWinter++;
                }
            }
            Console.WriteLine("Broj ljudi rodenih tijekom zime iznosi: " + countWinter);
            Console.WriteLine("Broj ljudi rodenih tijekom proljeca iznosi: " + countSpring);
            Console.WriteLine("Broj ljudi rodenih tijekom ljeta iznosi: " + countSummer);
            Console.WriteLine("Broj ljudi rodenih tijekom jeseni iznosi: " + countAutumn);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }      
        private static void YoungestPerson(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<DateTime> list = new List<DateTime>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                list.Add(value.Item2);
            }
            var list2 = list.OrderBy(x => x.Year).ToList();
            List<string> listOfKey = new List<string>();
            foreach (var item in list2)
            {
                foreach (var item2 in myDictionary)
                {
                    Tuple<string, DateTime, string> value = myDictionary[item2.Key];
                    if (value.Item2 == item)
                        listOfKey.Add(item2.Key);
                }
            }
            string key = listOfKey[listOfKey.Count - 1];
            Console.WriteLine(myDictionary[key]);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void OldestPerson(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<DateTime> list = new List<DateTime>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                list.Add(value.Item2);
            }
            var list2 = list.OrderBy(x => x.Year).ToList();
            List<string> listOfKey = new List<string>();
            foreach (var item in list2)
            {
                foreach (var item2 in myDictionary)
                {
                    Tuple<string, DateTime, string> value = myDictionary[item2.Key];
                    if (value.Item2 == item)
                        listOfKey.Add(item2.Key);
                }
            }
            listOfKey.Reverse();
            string key = listOfKey[listOfKey.Count - 1];
            Console.WriteLine(myDictionary[key]);
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void PercentageOfAge(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            var today = DateTime.Today;
            List<int> list = new List<int>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                DateTime birthyear = value.Item2;
                var age = today.Year - birthyear.Year;
                list.Add(age);
                
            }
            double total = list.Sum();
            double count = list.Count;
            Console.WriteLine("Prosjecan broj godina iznosi: " + Math.Round((total / count), 2, MidpointRounding.ToEven));
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
        private static void MedianOfYear(Dictionary<string, Tuple<string, DateTime, string>> myDictionary)
        {
            Console.Clear();
            List<int> list = new List<int>();
            foreach (var item in myDictionary)
            {
                Tuple<string, DateTime, string> value = myDictionary[item.Key];
                DateTime birthyear = value.Item2;
                var year = birthyear.Year;
                list.Add(year);

            }
            int count = list.Count;
            if (count % 2 == 0)
            {
                double a = list[(count / 2) + 1];
                double b = list[count / 2];
                double Median = (a + b) / 2;
                Console.WriteLine("Medijan godina iznosi: " + Math.Round(Median, 2, MidpointRounding.ToEven));
            }
            else
            {
                double Median =  list[count / 2];
                Console.WriteLine("Medijan godina iznosi: " + Math.Round(Median, 2, MidpointRounding.ToEven));
            }
            Console.WriteLine("Pritisnite enter za povratak na izbornik...");
            Console.ReadLine();
        }
    }
}

        

