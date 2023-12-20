using Lab_01.enums;
using Lab1.misc;

namespace Lab1
{
    public class Player
    {
        public Player() { }

        public Player(string inGameName, long chatId)
        {
            Id = Guid.NewGuid();
            InGameName = inGameName;
            ChatId = chatId;
            State = Menus.Start;
            Day = 0;
            Time = 4;
            Energy = 80;
            Health = 80;
            Happiness = 80;
            Money = 100;
        }

        public Player(string inGameName, long chatId, int day) : this(inGameName, chatId)
        {
            Day = day;
        }

        public Guid Id { get; init; }

        public long ChatId { get; set; }

        private string? _inGameName;
        public string? InGameName
        {
            get => _inGameName;
            set
            {
                if (value == null) _inGameName = "Женя";
                else if (value.Length <= 50) _inGameName = value;
                else if (value.Length > 50) throw new OverflowException("Ім'я було задовге");
            }
        }

        public Menus State { get; set; }

        private int _day;
        public int Day
        {
            get => _day;
            set
            {
                if (value >= 0 && value <= 14) _day = value;
                if (value > 14) _day = 14;
            }
        }

        private int _time;
        public int Time
        {
            get => _time;
            set
            {
                if (value < 0) _time = 0;
                if (value >= 0 && value <= 4) _time = value;
                if (value > 4) _time = 4;
            }
        }

        private int _energy;
        public int Energy
        {
            get => _energy;
            set
            {
                if (value <= 0) _energy = 0;
                if (value >= 0 && value <= 100) _energy = value;
                if (value > 100) _energy = 100;
            }
        }

        private int _health;
        public int Health
        {
            get => _health;
            set
            {
                if (value <= 0) _health = 0;
                if (value >= 0 && value <= 100) _health = value;
                if (value > 100) _health = 100;
            }
        }

        private int _happiness;
        public int Happiness
        {
            get => _happiness;
            set
            {
                if (value <= 0) _happiness = 0;
                if (value > 0 && value <= 100) _happiness = value;
                if (value > 100) _happiness = 100;
            }
        }

        public int Money { get; set; }

        public int Score => (Money + Energy + Health + Happiness) * (1 + Day / 30);

        /// <summary>
        /// Applies effect of interaction (watch static class Interactions) on player
        /// </summary>
        /// <param name="interaction"></param>
        /// <returns>false if delegate in interaction returned false</returns>
        internal bool ApplyInteraction(Interaction interaction)
        {
            State = Menus.Day;
            if (!interaction.DoContinue(Time)) return false;

            Time += interaction.Time;
            Money += interaction.Money;
            Energy += interaction.Energy;
            Happiness += interaction.Happiness;
            Health += interaction.Health;
            return true;
        }

        internal bool ApplyInteraction(int time, int money, int energy, int happiness, int health)
        {
            State = Menus.Day;

            Time += time;
            Money += money;
            Energy += energy;
            Happiness += happiness;
            Health += health;
            return true;
        }

        public override string ToString()
        {
            return $"Айді: {ChatId} \nІм'я: {InGameName}\nЧас: {Time}\nГроші: {Money}\nЕнергія: {Energy}\nЗдоров'я: {Health}\nЩастя: {Happiness}\nДень: {Day}\nОчки: {Score}";
        }
    }
}
