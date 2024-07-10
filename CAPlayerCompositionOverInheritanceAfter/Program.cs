namespace CAPlayerCompositionOverInheritanceAfter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var choice = 0;
            var player = new Player();
            do
            {
                Console.Clear();
                choice = ReadChoice(choice);
                if (choice >= 1 && choice <= 3)
                {
                    IInformation info = null;
                    switch (choice)
                    {
                        case 1:
                            info = new Ronaldo();
                            break;
                        case 2:
                            info = new Messi();
                            break;
                        case 3:
                            info = new HALAND();
                            break;
                        default:
                            break;
                    }
                    player.AddPlayerInfo(info);
                    Console.WriteLine("Press any key to continue");
                }
                Console.ReadKey();
            } while (choice != 0);
            Console.WriteLine(player);
            Console.ReadKey();
        }
        private static int ReadChoice(int choice)
        {
            Console.WriteLine("Player Information");
            Console.WriteLine("------------");
            Console.WriteLine("1. Ronaldo");
            Console.WriteLine("2. Messi");
            Console.WriteLine("3. Haland");
            Console.WriteLine("select Player: ");
            if (int.TryParse(Console.ReadLine(), out int ch))
            {
                choice = ch;
            }

            return choice;
        }
    }
    class Player
    {
        public List<IInformation> PlayerInfo { get; private set; } = new List<IInformation>();
        public void AddPlayerInfo(IInformation information) => PlayerInfo.Add(information);
        private decimal Calculate()
        {
            var total = 0;
            foreach (var sal in PlayerInfo)
            {
                total += (int)(sal.Salary * 4 * 12);
            }
            return total;
        }
        public override string ToString()
        {
            var output = $"\n{nameof(Player)}";
            foreach (var info in PlayerInfo)
            {
                output += $"\n\tName: {info.Name}";
                output += $"\n\tClub: {info.Club}";
                output += $"\n\tPosition: {info.Position}";
                output += $"\n\tAge: {info.Age.ToString()} years old";
                output += $"\n\tContract: {info.Contract.ToString()}";
                output += $"\n\tSalary Per Week ({info.Salary.ToString("C")})";
                output += "\n************************************************";
            }
            output += $"\nTotal Salary Per Year: {Calculate().ToString("C")}";
            output += "\n------------------------------------------------";

            return output;
        }
    }
    public interface IInformation
    {
        string Name { get; }
        string Club { get; }
        string Position { get; }
        decimal Salary { get; }
        int Age { get; }
        int Contract { get; }
    }
    public class Ronaldo : IInformation
    {
        public string Name => nameof(Ronaldo);
        public string Club => "EL-NASR";
        public string Position => "ST";
        public decimal Salary => 500m;
        public int Age => 40;
        public int Contract => 2026;
    }
    public class Messi : IInformation
    {
        public string Name => nameof(Messi);
        public string Club => "INTER MEYAMI";
        public string Position => "RW";
        public decimal Salary => 450m;
        public int Age => 38;
        public int Contract => 2027;
    }
    public class HALAND : IInformation
    {
        public string Name => nameof(HALAND);
        public string Club => "Manchester City";
        public string Position => "ST";
        public decimal Salary => 200m;
        public int Age => 23;
        public int Contract => 2029;
    }
}

