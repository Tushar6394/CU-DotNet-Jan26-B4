namespace SecureTerminal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 4;
            string pin = string.Empty;
            string e = string.Empty;
            while (i > 0)
            {
                ConsoleKeyInfo con = Console.ReadKey(true);

                if (con.Key != ConsoleKey.Backspace)
                {
                    pin += con.KeyChar;
                    e += '*';
                }
                else
                {
                    pin = pin.Remove(pin.Length - 1);
                    e = e.Remove(e.Length - 1);
                    i=i+2;
                }
                Console.Clear();
                Console.Write(e);
                i--;
            }
            Console.WriteLine();
            Console.WriteLine(pin);
        }
    }
}