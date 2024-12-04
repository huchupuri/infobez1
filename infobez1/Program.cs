using System.Text;

namespace cezar
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = 1; 
            int key;

            Console.WriteLine("Введите предложение,которое нужно зашифровать:");
            string sentence = Console.ReadLine();

            Console.WriteLine("Введите ключ:");
            while (!int.TryParse(Console.ReadLine(), out key))
            {
                Console.WriteLine("Введите целое число");
            }
            key %= 30;

            StringBuilder answer = new StringBuilder();
            string alfphabet = "АБВГДЕЖЗИКЛМНОПРСТУФХЦЧШЩЬЪЭЮЯ";
            int m = alfphabet.Length;

            int len = sentence.Length;
            for (int i = 0; i < len; i++)
            {
                if (alfphabet.Contains(char.ToUpper(sentence[i])))
                {

                    if (key + alfphabet.IndexOf(char.ToUpper(sentence[i])) < m)
                    {
                        if (char.IsLower(sentence[i])) 
                        { 
                            answer.Append(char.ToLower(alfphabet[alfphabet.IndexOf(char.ToUpper(sentence[i])) + key]));
                        }
                        else
                        {
                            answer.Append(alfphabet[alfphabet.IndexOf(char.ToUpper(sentence[i])) + key]);
                        }
                    }
                    else
                    {
                        if (char.IsLower(sentence[i]))
                        {
                            answer.Append(char.ToLower(alfphabet[Math.Abs(m - alfphabet.IndexOf(char.ToUpper(sentence[i])) - key)]));
                        }
                        else
                        {
                            answer.Append(alfphabet[Math.Abs(m - alfphabet.IndexOf(char.ToUpper(sentence[i])) - key)]);
                        }
                    }
                }
                else
                {
                    answer.Append(sentence[i]);
                }
            }
            Console.WriteLine(answer);
        }
    }
}