using System.Text;

namespace Lab_3
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            new UserProgramCommunication().InitialiseList();
        }
    }
}