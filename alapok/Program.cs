using System;

namespace alapok
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // constans -> Ha valaminek adsz egy értéket és elötte lesz hogy const
            //             akkor nem lehet később megváltoztatni az értéket. Pl:

            //const double pi = 3.14159;
            //Console.WriteLine(pi);


            // type casting -> Konvertálni lehet egy értéket egy másik adat típussá.
            //                 Ez hasznos Pl ha a User input (String) mivel különböző
            //                 adat típusok más- más dolgokat tudnak.

            //double a = 3.14;
            //int b =  Convert.ToInt32(a);    // ez itt pl egy double-ből konvertál egy int-et 

            //int c = 123;
            //double d = Convert.ToDouble(c); // ez itt pl egy int-ből konvertál egy Double-t

            //int e = 321;
            //String f = Convert.ToString(e); // ez itt pl egy int-ből konvertál egy String-et

            //String g = "$";
            //char h = Convert.ToChar(g);     // ez itt pl egy String-ből konvertál egy char-t

            //String i = "true";
            //bool j = Convert.ToBoolean(i);  // ez itt pl egy String-ből konvertál egy booleant-et

            //Console.WriteLine(b.GetType());
            //Console.WriteLine(d.GetType());
            //Console.WriteLine(f.GetType());
            //Console.WriteLine(h.GetType());
            //Console.WriteLine(j.GetType());


            // User Input
            //

            //Console.Write("What is your name?");
            //String name = Console.ReadLine();

            //Console.Write("What is your age?");
            //int age = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Hello " + name);
            //Console.WriteLine("You are " + age + "years old");


            // Műveletek/Aritmetika


            //int friends = 5;

            // Egy változó növelése

            //friends = friends + 2;
            //friends += 2;
            //friends++;                //ez csak egyel tudja növelni többel nem.

            // Egy változó csökkentése

            //friends = friends - 2;
            //friends -= 2;
            //friends--;                //ez csak egyel tudja csökkenteni többel nem.

            // Egy változó szorzása

            //friends = friends * 2;
            //friends *= 1;

            // Egy változó osztása

            //friends = friends / 2;    //mivel int-ben van a változó (egész számot tárol)
            //friends /= 2;             //csak double-ben lehet maradékosan osztani

            // Maradékos osztás

            //int remainder = friends % 2;  //ez mindíg azt fogja visszaadni hogy mennyi a maradék (itt pl 1 lesz)

            //Console.WriteLine(friends);

            // Négyzetre emelés

            //double x = 3;
            //double a = Math.Pow(x, 2);    //ez annyit tesz hogy (három a négyzeten)
            //Console.WriteLine(a);

            // Gyökvonás

            //double x = 3;
            //double b = Math.Sqrt(x);    //ez annyit tesz hogy (gyök alatt a három)
            //Console.WriteLine(b);

            // Abszolút érték

            //double x = -3;
            //double c = Math.Abs(x);    //ez annyit tesz hogy (mínusz három abszolút értéke = plusz három)
            //Console.WriteLine(c);

            // Legközelebbi egész számra kerekítés

            //double x = 3;
            //double d = Math.Round(x);  // ha 0.5 < szám akkor felfelé ha pedig > akkor lefelé kerekít
            //Console.WriteLine(d);

            // Legközelebbi nagyobb egész számra kerekítés

            //double x = 3.3;
            //double e = Math.Ceiling(x);  // ha 0.3 a szám akkor is 4-re kerekít (Mindíg felfele kerekít)
            //Console.WriteLine(e);

            // Legközelebbi kissebb egész számra kerekítés

            //double x = 3.99;
            //double f = Math.Floor(x);  // ha 0.99 a szám akkor is 3-re kerekít (Mindíg lefele kerekít)
            //Console.WriteLine(f);

            // Megtalálja a legnagyobb számot

            //double x = 3.99;
            //double y = 5;
            //double g = Math.Max(x, y);
            //Console.WriteLine(g);

            // Megtalálja a legkissebb számot

            //double x = 3.99;
            //double y = 5;
            //double h = Math.Min(x, y);
            //Console.WriteLine(h);

            // Random számot generálása (sudo)

            //Random random = new Random();
            //int num = random.Next(1, 7);        // Random egész szám generálása 1 és 7 között
            //double num = random.NextDouble();   // Random tört szám 0 és 1 között
            //Console.WriteLine(num);


            // Egy derékszögű háromszög átfogójának kiszámítása

            //Console.WriteLine("Kéram az A oldalt : ");
            //double a = Convert.ToDouble(Console.ReadLine());

            //Console.WriteLine("Kéram az B oldalt : ");
            //double b = Convert.ToDouble(Console.ReadLine());

            //double c = Math.Sqrt((a * a) + (b * b));

            //Console.WriteLine("Az átfogó : " + c);


            //String methods

            //String fullName = "Marcell Herczeg";
            //String phoneNumber = "06-70-220-6176";

            //fullName = fullName.ToUpper(); //Összes nagybetűvel
            //fullName = fullName.ToLower(); //Összes kisbetűvel
            //Console.WriteLine( fullName );

            //phoneNumber = phoneNumber.Replace("-", "/");  // Kicseréli a "-"-t, "/"-re
            //Console.WriteLine( phoneNumber );

            //String userName = fullName.Insert(0,"@");     // A nevem elé ír egy "@" (új változó username)
            //Console.WriteLine( userName );

            //Console.WriteLine(fullName.Length);

            //String firstName = fullName.Substring(0, 7);    // A 0. karaktertől számolva 7db karaktert
            //Console.WriteLine(firstName);

            //String lastName = fullName.Substring(8, 7);     // A 8. karaktertől számolva 7db karaktert
            //Console.WriteLine(lastName);


            //if statements -> alapvető (ha) decision making

            //Console.WriteLine("Írd be hány éves vagy: ");
            //int age = Convert.ToInt32(Console.ReadLine());
            //if (age > 125)
            //{
            //    Console.WriteLine("A történelem eddig igazoltan legidősebb embere, a " +
            //        "francia Jeanne Louise Calment 122 évet élt, 1997-ben halt meg.");
            //}
            //else if (age <= 0)
            //{
            //    Console.WriteLine("Meg sem születtél");
            //}
            //else if (age >= 18)
            //{
            //    Console.WriteLine("Engedélyezett Bejelentkezés!");
            //}
            //else
            //{
            //    Console.WriteLine("Engedélytelen Bejelentkezés, nem vagy elég idős :( ");
            //}


            // Switch -> ha tul sok else if ág lenne abban az esetben lehet ezt használni

            //Console.WriteLine("Milyen nap van ma?");
            //String day = Console.ReadLine();

            //switch (day)
            //{
            //    case "Hétfő":
            //        Console.WriteLine("Hétfő van!");
            //        break;
            //    case "Kedd":
            //        Console.WriteLine("Kedd van!");
            //        break;
            //    case "Szerda":
            //        Console.WriteLine("Szerda van!");
            //        break;
            //    case "Csütörtök":
            //        Console.WriteLine("Csütörtök van!");
            //        break;
            //    case "Péntek":
            //        Console.WriteLine("Péntek van!");
            //        break;
            //    case "Szombat":
            //        Console.WriteLine("Szombat van!");
            //        break;
            //    case "Vasárnap":
            //        Console.WriteLine("Vasárnap van!");
            //        break;
            //    default:
            //        Console.WriteLine(day + " nem is egy nap.");
            //        break;
            //}


            //Logikai operátorok -> HAsználhatók ha több mint 1 feltétel true/false
            // && (AND)
            // || (OR)

            //Console.WriteLine("Hány fok van kint : (C)");
            //double temp = Convert.ToDouble(Console.ReadLine());

            //if (temp >= 10 && temp <= 25)          //Mindkét feltételnek teljesülnie kell
            //{
            //    Console.WriteLine("Meleg van kint!");
            //}
            //else if (temp <= -50 || temp >= 50)   //Elég csak egy feltételnek teljesülni hogy lefusson
            //{
            //    Console.WriteLine("NE PRÓBÁLJ MEG KIMENNI!");
            //}


            //While loop -> Addig ismétel valamit ameddig nem lesz igaz egy adott feltétel

            //Console.Write("Írd be a neved: ");
            //String name = Console.ReadLine();

            //while(name == "")           //Addig ismételjük ameddig nem ír be semmit a user
            //{
            //    Console.WriteLine("Írd be a neved: ");
            //    name = Console.ReadLine();
            //}

            //Console.WriteLine("Hello" + name);


            //For loops ->  Annyiszor ismétel egy kódot amennyiszer megmondjuk neki

            //for (int i = 0; i <= 10; i++)   // Mennyivel kezdődik ; Mennyinél álljon meg ; mennyivel akarjuk növelni a lépésszámot
            //{
            //    Console.WriteLine(i);
            //}

            //for (int i = 10; i > 0; i--)      // Visszaszámlálás
            //{
            //    Console.WriteLine(i);
            //}
            //Console.WriteLine("Boldog Újévet");


            //Egymásba ágyazott ciklus -> 

            //Console.WriteLine("Hány oszlop?: ");
            //int rows = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Hány sor?: ");
            //int columns = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Milyen karakterből álljon? : ");
            //String symbol = Console.ReadLine();

            //for (int i = 0; i< rows; i++)
            //{
            //    for(int j = 0; j < columns; j++)
            //    {
            //        Console.Write(symbol);
            //    }
            //    Console.WriteLine();
            //}


            //Random szám kitalálós játék

            Random random = new Random();
            bool playAgain = true;
            int min = 1;
            int max = 100;
            int guess;
            int number;
            int guesses;
            String response;

            while (playAgain)
            {
                guess = 0;
                guesses = 0;
                response = "";
                number = random.Next(min, max + 1);   

                while (guess != number)
                {
                    Console.WriteLine("Tippeld meg a random számot " + min + " - " + max + " között : ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("A tipped: " + guess);

                    if (guess > number)
                    {
                        Console.WriteLine(guess + " Ez a tipp túl magas.");
                    }
                    else if (guess < number)
                    {
                        Console.WriteLine(guess + " Ez a tipp túl alacsony.");
                    }
                    guesses++;
                }
                Console.WriteLine("Szám: " + number);
                guess = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Tippek száma" + guess);
                Console.WriteLine("Akarsz még játszani ? (Y/N) : ");
                response = Console.ReadLine();
                response = response.ToUpper();

                if (response == "Y")
                {
                    playAgain = true;
                }
                else
                {
                    playAgain = false;
                }
            }
            Console.WriteLine("Köszi hogy játszottál");





            Console.ReadKey();              //Hideolja a kódokat a konzolon.
        }
    }
}
