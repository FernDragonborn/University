using static Lab_07.misc.Buttons;

namespace Lab_07.misc
{
    public record struct Interaction(string Name, int Time, int Money, int Energy, int Happiness, int Health, Func<int, bool> DoContinue);
    public static class Interactions
    {
        public static readonly Interaction IntrWorkBarista = new(BtnWorkBarista, -2, +20, -30, -7, -5, (time) => time >= 2);
        public static readonly Interaction IntrWorkTutor = new(BtnWorkTutor, -2, +25, -30, -12, 0, (time) => time >= 2);
        public static readonly Interaction IntrWorkFreelance = new(BtnWorkFreelance, -2, +15, -20, -5, 0, (time) => time >= 2);
        public static readonly Interaction IntrLeisureLake = new(BtnLeisureLake, -1, 0, -5, +10, +5, (_) => true);
        public static readonly Interaction IntrLeisureGym = new(BtnLeisureGym, -1, -5, -10, +15, +15, (_) => true);
        public static readonly Interaction IntrLeisureFriend = new(BtnLeisureFriend, -1, -10, -20, +10, +5, (_) => true);
    }
}