namespace Lab4
{
    internal class PlayerHandler
    {
        private readonly Random _rand = new();
        private readonly Dictionary<long, Player> _players = new();

        internal void AddPlayer(string name)
        {
            long chatId = generateChatId();
            _players.Add(chatId, new Player(name, chatId));
        }

        internal void AddPlayerWithDay(string name, int day)
        {
            long chatId = generateChatId();
            _players.Add(chatId, new Player(name, chatId, day));
        }

        private long generateChatId()
        {
            long randomNumber = _rand.NextInt64();
            long chatId = randomNumber + 1000000000;
            return chatId;
        }

        internal void AddParsedPlayer(Player player)
        {
            try
            {
                _players.Add(player.ChatId, player);
            }
            catch (ArgumentException ex)
            {
                player.ChatId = generateChatId();
                _players.Add(player.ChatId, player);
                throw ex;
            }
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
            _players[chatId].Dispose();
            _players.Remove(chatId);
        }

        internal void WritePlayers()
        {
            if (_players.Count == 0) { Console.WriteLine("Гравців поки немає"); }
            Console.WriteLine($"Загальна кілкьість гравців: {Player.TotalPlayersCount}\n");
            foreach (var item in _players)
            {
                Console.WriteLine($"{item.Value}\n");
            }
        }

    }
}