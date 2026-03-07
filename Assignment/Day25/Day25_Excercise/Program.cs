// namespace SecureTerminal
// {
//     internal class Program
//     {
//         static void Main(string[] args)
//         {
//             int i = 4;
//             string pin = string.Empty;
//             string e = string.Empty;
//             while (i > 0)
//             {
//                 ConsoleKeyInfo con = Console.ReadKey(true);

//                 if (con.Key != ConsoleKey.Backspace)
//                 {
//                     pin += con.KeyChar;
//                     e += '*';
//                 }
//                 else
//                 {
//                     pin = pin.Remove(pin.Length - 1);
//                     e = e.Remove(e.Length - 1);
//                     i=i+2;
//                 }
//                 Console.Clear();
//                 Console.Write(e);
//                 i--;
//             }
//             Console.WriteLine();
//             Console.WriteLine(pin);
//         }
//     }
// }




////# Day 25 Excercise : Cricket Platform Performance Tracker
/// 
public class Player
{
    public string Name { get; set; }
    public int RunsScored { get; set; }
    public int BallsFaced { get; set; }
    public bool IsOut { get; set; }
    public double StrikeRate { get; set; }
    public double Average { get; set; }
    
    public Player(string name, int runs, int balls, bool isOut)
    {
        Name = name;
        RunsScored = runs;
        BallsFaced = balls;
        IsOut = isOut;
        StrikeRate = balls > 0 ? (double)runs / balls * 100 : 0;
        Average = isOut ? (double)runs : runs;
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Enter CSV file path: ");
        string path = Console.ReadLine();
        
        List<Player> players = new List<Player>();
        
        try
        {
            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                string trimmedLine = line.Trim();
                if (string.IsNullOrEmpty(trimmedLine)) continue;
                
                string[] parts = trimmedLine.Split(',');
                if (parts.Length != 4) continue;
                
                string name = parts[0].Trim();
                if (!int.TryParse(parts[1].Trim(), out int runs) || !int.TryParse(parts[2].Trim(), out int balls) || !bool.TryParse(parts[3].Trim(), out bool isOut))
                {
                    continue;
                }
                
                Player player = new Player(name, runs, balls, isOut);
                players.Add(player);
            }
            var validPlayers = players
                .Where(p => p.BallsFaced >= 10)
                .OrderByDescending(p => p.StrikeRate)
                .ToList();

                
            Console.WriteLine("Name            Runs    SR      Avg     ");
            Console.WriteLine("---------------------------------------");
            foreach (Player p in validPlayers)
            {
                Console.WriteLine($"{p.Name,-15} {p.RunsScored,4}    {p.StrikeRate,5:F2}   {p.Average,6:F2}");
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("CSV file not found. Please check the file path.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}