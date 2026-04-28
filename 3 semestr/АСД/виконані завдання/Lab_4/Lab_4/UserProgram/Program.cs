using System.Text;

namespace Lab_4.UserProgramCommunication
{
    internal class Program
    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            new UserProgramComm().InitialiseList();
        }
    }
}
