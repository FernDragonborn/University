using System.Text;

namespace Lab_2;

internal class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        new UserProgramCommunication().InitialiseList();
    }
}