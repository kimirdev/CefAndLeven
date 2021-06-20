using System;

namespace Levenshtein
{
    class Program
    {
        static void Main(string[] args)
        {
            //string liga1 = "Кюн Н.";
            //string liga2 = "Мартинес Педро";
            //string fon1 = "Кун Н";
            //string fon2 = "Мартинес Портеро П.";

            string liga1 = "ФК ЗЕНИТ";
            string liga2 = "ФК ДИНАМО";
            string fon1 = "ЗЕНАТ";
            string fon2 = "ДИНОМО";

            int distance1 = LevenshteinDistance(liga1.Split(" ")[1], fon1);
            int distance2 = LevenshteinDistance(liga2, fon2);
            Console.WriteLine($"DIS1 - {distance1}\nDIS2 - {distance2}");
        }

        public static int LevenshteinDistance(string string1, string string2)
        {
            if (string1 == null) throw new ArgumentNullException("string1");
            if (string2 == null) throw new ArgumentNullException("string2");
            int diff;
            int[,] m = new int[string1.Length + 1, string2.Length + 1];

            for (int i = 0; i <= string1.Length; i++) { m[i, 0] = i; }
            for (int j = 0; j <= string2.Length; j++) { m[0, j] = j; }

            for (int i = 1; i <= string1.Length; i++)
            {
                for (int j = 1; j <= string2.Length; j++)
                {
                    diff = (string1[i - 1] == string2[j - 1]) ? 0 : 1;

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1, m[i, j - 1] + 1), m[i - 1, j - 1] + diff);
                }
            }
            return m[string1.Length, string2.Length];
        }
    }
}
