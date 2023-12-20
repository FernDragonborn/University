using Lab1.enums;
using System.Text;
using System.Text.RegularExpressions;
using static Lab_01.misc.Messages;
using static Lab1.misc.Interactions;

namespace Lab1;
internal class Program
{
    public static void Main()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        Console.OutputEncoding = Encoding.GetEncoding(1251);
        Console.InputEncoding = Encoding.GetEncoding(1251);

        PlayerHandler handler = new();
        var state = State.MainMenu;

        WriteMenu();
        Player? chosenPlayer = null;

        while (true)
        {
            string? input = "";
            try
            {
                input = Console.ReadLine();
            }
            catch
            {
                Console.WriteLine("Помилка зчитування з консолі. Спробуйте перезапустити програму");
            }

            if (string.IsNullOrEmpty(input)) { Console.WriteLine("Команда не розпізнана\n"); continue; }
            input = input.Trim();
            // Input name
            if (state == State.GetName)
            {
                if (input == "0") { WriteMessageMenuAndSetDefaultState(out state, $"Ви повернулись до головного меню"); continue; }

                string name = input;
                if (!Regex.IsMatch(name, @"^[A-Za-zА-Яа-я][\p{L}\s]{1,19}$"))
                {
                    Console.WriteLine("Перевірте чи ім'я більше 2х та менше 20ти символів, та чи воно складається із букв");
                    continue;
                }

                int day = 0;
                while (true)
                {
                    Console.WriteLine("Гравець починає з першого дня?\n1 - так\n2 - ні\n");
                    try
                    {
                        input = Console.ReadLine();
                    }
                    catch
                    {
                        Console.WriteLine("Помилка зчитування з консолі. Спробуйте перезапустити програму");
                        continue;
                    }

                    if (string.IsNullOrEmpty(input))
                    {
                        WriteError();
                        continue;
                    }

                    input = input.Trim();
                    if (input == "2")
                    {
                        Console.WriteLine("Введіть номер дню з якого почати: ");
                        try
                        {
                            day = Convert.ToInt32(Console.ReadLine());
                        }
                        catch
                        {
                            Console.WriteLine("Помилка формату, спробуйте ще раз\n");
                            continue;
                        }
                    }
                    break;
                }

                if (day != 0) { handler.AddPlayerWithDay(name, day); }
                else { handler.AddPlayer(name); }
                WriteMessageMenuAndSetDefaultState(out state, $"додано гравця з іменем {name}");
                continue;
            }

            if (state == State.ChoosePlayer)
            {
                if (input == "0") { WriteMessageMenuAndSetDefaultState(out state, $"Ви повернулись до головного меню"); continue; }

                try
                {
                    //if id used
                    if (long.TryParse(input, out long id))
                    {
                        chosenPlayer = handler.FindPlayer(id);
                    }
                    //if name used
                    else
                    {
                        chosenPlayer = handler.FindPlayer(input);
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Перевірте чи правильно введений айді шуканого гравця");
                    continue;
                }
                catch (ArgumentException)
                {
                    WriteError();
                    continue;
                }

                if (chosenPlayer is null) { WriteErrorMenuAndSetDefaultState(out state); continue; }

                state = State.Interaction;
                Console.Clear();
                Console.WriteLine(chosenPlayer);
                Console.WriteLine($"\n\n{MessageWork}\n\n{MessageLeisure}\n\nОберіть бажаний пункт\n\nАбо напишіть 7, щоб застосувати кастомну дію");
                continue;
            }

            if (state == State.Interaction)
            {
                if (input == "0") { WriteMessageMenuAndSetDefaultState(out state, $"Ви повернулись до головного меню"); continue; }

                if (input == "7")
                {
                    state = State.CustomInteraction;
                    Console.WriteLine("Введіть 5 характеристик через кому ось так: \"-1,20,-10,-15,-5\"\n\nперша - час, друга - гроші, третя - щастя, четверта - здоров'я");
                    continue;
                }

                if (chosenPlayer is null)
                {
                    WriteMenu();
                    Console.WriteLine("Якась помилка, гравець дорівнював null, вас перенесло до основного меню");
                    state = State.MainMenu;
                    continue;
                }
                if (string.IsNullOrEmpty(input)) { WriteError(); }
                if (!int.TryParse(input.Trim(), out int menuItem)) { WriteError(); }

                string message = "";
                switch (menuItem)
                {
                    case 1:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrWorkBarista);
                        break;
                    case 2:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrWorkTutor);
                        break;
                    case 3:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrWorkFreelance);
                        break;
                    case 4:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrLeisureLake);
                        break;
                    case 5:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrLeisureGym);
                        break;
                    case 6:
                        message = WriteStateAndApplyInteraction(chosenPlayer, IntrLeisureFriend);
                        break;
                    default:
                        WriteError();
                        break;
                }
                WriteMessageMenuAndSetDefaultState(out state, message);
                continue;
            }

            if (state == State.CustomInteraction)
            {
                if (input == "0") { WriteMessageMenuAndSetDefaultState(out state, $"Ви повернулись до головного меню"); continue; }

                if (chosenPlayer is null)
                {
                    WriteMenu();
                    Console.WriteLine("Якась помилка, гравець дорівнював null, вас перенесло до основного меню");
                    state = State.MainMenu;
                    continue;
                }
                if (string.IsNullOrEmpty(input)) { WriteError(); }

                var inputArr = input.Split(',');
                if (inputArr.Length != 5) { Console.WriteLine("Ви не коректно ввели значення, спробуйте ще раз"); }
                int[] intArr = new int[5];
                for (int i = 0; i < inputArr.Length; i++)
                {
                    if (!int.TryParse(inputArr[i], out intArr[i]))
                    {
                        Console.WriteLine("Ви не коректно ввели значення, спробуйте ще раз");
                        break;
                    }
                }

                chosenPlayer.ApplyInteraction(intArr[0], intArr[1], intArr[2], intArr[3], intArr[4]);

                string interactionString = $"Час: {intArr[0]}\nГроші: {intArr[1]}\nЕнергія: {intArr[2]}\nЩастя: {intArr[3]}\nЗдоров'я: {intArr[4]}";
                string message = $"Дію застосовано:\n\n{interactionString}\n\n{chosenPlayer}";

                WriteMessageMenuAndSetDefaultState(out state, message);
                continue;
            }

            if (state == State.DeletePlayer)
            {
                if (input == "0") { WriteMessageMenuAndSetDefaultState(out state, $"Ви повернулись до головного меню"); continue; }
                Player? player;
                try
                {
                    if (long.TryParse(input, out long id))
                    {
                        player = handler.FindPlayer(id);
                    }
                    else
                    {
                        player = handler.FindPlayer(input);
                    }
                }
                catch (KeyNotFoundException)
                {
                    Console.WriteLine("Перевірте чи правильно введений айді шуканого гравця");
                    continue;
                }
                catch (ArgumentException)
                {
                    WriteError();
                    continue;
                }

                if (player == null) { Console.WriteLine("Гравця із таким іменем не знайдено\n"); continue; }
                WriteMessageMenuAndSetDefaultState(out state, $"Гравець \"{player.InGameName}\" успішно видалений. Вас перенесено у голвоне меню");
                handler.RemovePlayer(player.ChatId);
                continue;
            }

            if (!int.TryParse(input, out int numInput))
            {
                WriteError();
                continue;
            }

            WriteMenu();
            switch (numInput)
            {
                //exit
                case 0:
                    Console.WriteLine("Робота програми завершена");
                    Environment.Exit(0);
                    continue;
                //Create palyer
                case 1:
                    state = State.GetName;
                    Console.WriteLine("Напишіть ім'я нового гравця: ");
                    continue;
                //Write all players to console
                case 2:
                    handler.WritePlayers();
                    continue;
                //Choose object 
                case 3:
                    state = State.ChoosePlayer;
                    Console.WriteLine("Напишіть ім'я або айді гравця для пошуку: ");
                    continue;
                //Delete player
                case 4:
                    state = State.DeletePlayer;
                    Console.WriteLine("Напишіть ім'я або айді гравця для видалення: ");
                    continue;
                default:
                    WriteError();
                    continue;
            }

        }
    }

    private static string WriteStateAndApplyInteraction(Player chosenPlayer, misc.Interaction interaction)
    {
        chosenPlayer.ApplyInteraction(interaction);
        string interactionString = $"{interaction.Name}\nЧас: {interaction.Time}\nГроші: {interaction.Money}\nЕнергія: {interaction.Energy}\nЩастя: {interaction.Happiness}\nЗдоров'я: {interaction.Health}";
        return $"Дію застосовано:\n\n{interactionString}\n\n{chosenPlayer}";
    }

    private static void WriteError()
    {
        Console.WriteLine("Команда не розпізнана, спробуйте ще раз");
    }

    private static void WriteErrorMenuAndSetDefaultState(out State state)
    {
        state = State.MainMenu;
        WriteMenu();
        Console.WriteLine("Команда не розпізнана. Вас перенесено до головного меню");
    }

    private static void WriteMessageMenuAndSetDefaultState(out State state, string message)
    {
        state = State.MainMenu;
        WriteMenu();
        Console.WriteLine(message);
    }

    private static void WriteMenu()
    {
        Console.Clear();
        Console.WriteLine("Меню\n1: Додати нового гравця\n2: Вивести існуючих гравців\n3: Застосувати дію до конкретного гравця за айді або ім'ям\n4: Видалити гравця\n0: Вийти або назад\n\n");
    }
}
