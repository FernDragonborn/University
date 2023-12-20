namespace Lab1
{
    internal class PlayerHandler
    {
        private readonly Random _rand = new();
        private readonly Dictionary<long, Player> _players = new();

        internal void AddPlayer(string name)
        {
            long randomNumber = _rand.NextInt64();
            long chatId = randomNumber + 1000000000;
            _players.Add(chatId, new Player(name, chatId));
        }

        internal void AddPlayerWithDay(string name, int day)
        {
            long randomNumber = _rand.NextInt64();
            long chatId = randomNumber + 1000000000;
            _players.Add(chatId, new Player(name, chatId, day));
        }

        internal Player FindPlayer(long chatId)
        {
            return _players[chatId];
        }

        internal Player FindPlayer(string name)
        {
            return _players.FirstOrDefault(x => x.Value.InGameName == name).Value;
        }

        internal void RemovePlayer(long chatId)
        {
            _players.Remove(chatId);
        }

        internal void WritePlayers()
        {
            if (_players.Count == 0) { Console.WriteLine("Гравців поки немає"); }
            foreach (var item in _players)
            {
                Console.WriteLine($"{item.Value}\n");
            }
        }

    }
}