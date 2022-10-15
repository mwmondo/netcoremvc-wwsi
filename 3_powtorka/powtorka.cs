namespace powtorka
{
    public static class Program
    {
        public static void Main()
        {
            Console.WriteLine("Podaj swoje imię:");
            var name = Console.ReadLine();
            Console.WriteLine("Hello " + name);

            int result = 5 + 9;

            Operatory();
            InstrukcjeSterujaceIPetle();
            Kolekcje();
        }
        private static void Operatory()
        {
            // Zadanie 1

            int number = 0;
            float money = 0;
            string text = string.Empty;
            bool isLogged = false;
            char myChar = 'a';
            double price = 0;

            Console.WriteLine($"number={number}\n" +
                $"money={money}\n" +
                $"text={text}\n" +
                $"isLogged={isLogged}\n" +
                $"myChar={myChar}\n" +
                $"price={price}"
                );

            // Zadanie 2

            string myAge = "Age: ";
            int wifeAge = 18;
            string result = myAge + wifeAge;

            Console.WriteLine(result); // int wifeAge został skonwertowany na stringa niejawnie

            // Zadanie 3
            bool isTrue = true, isFalse = false, isReallyTrue = true;

            bool and = isTrue && isFalse;
            bool or = isTrue || isFalse;
            bool negative = !isFalse;

            Console.WriteLine($"{and} {or} {negative}");

            // Zadanie 4
            int a = 5, b = 12;
            int add = a + b, sub = a - b, div = a / b, mul = a * b, mod = a % b;

            Console.WriteLine($"{add} {sub} {div} {mul} {mod}");

            // Zadanie 5

            //string a = "Ala ", b = "ma ", c = "kota.";
            //string result = a + b + c;

            //Console.WriteLine(result); // ciągi znaków zostały dodane

        }
        private static void InstrukcjeSterujaceIPetle()
        {
            // Zadanie 1
            int n1 = 10, n2 = 20;
            if (n1 > n2)
                Console.WriteLine("n1 jest większe od n2");
            else if (n1 == n2)
                Console.WriteLine("n1 jest równe n2");

            // Zadanie 2
            int i = 0;
            for (i = 0; i < 10; i++)
            {
                Console.WriteLine("C#");
            }

            i = 0;
            while (i < 10)
            {
                Console.WriteLine("C#");
                i++;
            }

            // Zadanie 3

            int n = 10;

            for (i = 0; i < n; i++)
                Console.WriteLine(i + " - " + (i % 2 == 0 ? "Parzysta" : "Nieparzysta"));

            // Zadanie 4

            Console.WriteLine(Asterisks(5));

            // Zadanie 5

            int exam = 57;
            string answer = "";

            if (exam > 0 && exam < 39)
                answer = "Ocena Niedostateczna";
            else if (exam > 40 && exam < 54)
                answer = "Ocena Dopuszczająca";
            else if (exam > 55 && exam < 69)
                answer = "Ocena Dostateczna";
            else if (exam > 70 && exam < 84)
                answer = "Ocena Dobra";
            else if (exam > 85 && exam < 98)
                answer = "Ocena Bardzo Dobra";
            else if (exam > 99 && exam < 100)
                answer = "Ocena Celująca";
            else
                answer = "Wartość poza zakresem";

            Console.WriteLine(answer);
        }
        public static string Asterisks(int num)
        {
            string output = "";
            for (int i = 0; i <= num; i++)
            {
                for (int j = 0; j < i; j++)
                    output += "* ";

                output += "\n";
            }
            return output;
        }

        private static void Kolekcje()
        {
            // Zadanie 1

            string[] colors = new string[4];
            colors[0] = "niebieski";
            colors[1] = "zielony";
            colors[2] = "żółty";
            colors[3] = "biały";

            Console.WriteLine($"Mój pierwszy kolor to: {colors[0]}");
            Console.WriteLine($"Mój ostatni kolor to: {colors[colors.Length - 1]}");

            // Zadanie 2
            int[] numbers = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            int i = 0;
            for (i = 0; i < numbers.Length; i++)
                Console.WriteLine($"Liczba: {numbers[i]}");

            foreach (int number in numbers)
                Console.WriteLine($"Liczba: {number}");

            i = 0;
            while (i < numbers.Length)
            {
                Console.WriteLine($"Liczba: {numbers[i]}");
                i++;
            }

            // Zadanie 3

            List<string> fruits = new List<string>(4);
            fruits.Add("Jabłko");
            fruits.Add("Banan");
            fruits.Add("Gruszka");
            fruits.Add("Malina");

            Console.WriteLine(string.Join(", ", fruits));

            fruits.Remove(fruits.First());
            fruits.RemoveAt(fruits.Count - 1);

            Console.WriteLine(string.Join(" ", fruits));
        }
    }
}
