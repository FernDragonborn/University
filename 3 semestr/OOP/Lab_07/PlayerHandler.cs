using System.Text;
using System.Text.Json;

namespace Lab_07;

internal class PlayerHandler
{
    private readonly Random _rand = new();
    private readonly Dictionary<long, Player> _players = new();

    internal int count => _players.Count;

    //only for tests
    internal void AddPlayerWithChatId(string name, long chatId)
    {
        Player p = new(name, chatId);
        _players.Add(chatId, p);
    }

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

    internal bool TryParsePlayer(string s)
    {
        Player player;
        if (!Player.TryParse(s, out player))
        {
            return false;
        }

        try
        {
            _players.Add(player.ChatId, player);
        }
        catch (ArgumentException ex)
        {
            player.ChatId = generateChatId();
            _players.Add(player.ChatId, player);
            return true;
        }

        return true;
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
        if (_players.Count == 0)
        {
            Console.WriteLine("Гравців поки немає");
        }

        Console.WriteLine($"Загальна кілкьість гравців: {Player.TotalPlayersCount}\n");
        foreach (var item in _players)
        {
            Console.WriteLine($"{item.Value}\n");
        }
    }

    internal void ClearCollection()
    {
        _players.Clear();
    }

    internal void SaveToFileCSV(string path, out string message)
    {
        StringBuilder sb = new();
        foreach (var item in _players.Values)
        {
            sb.Append(item.ToString() + ",\n");
        }
        //remove unnescessary separator
        sb.Remove(sb.Length - 2, 2);
        try
        {
            File.WriteAllText(path, sb.ToString());
            message = $"CSV-файл знаходиться за шляхом: {Path.GetFullPath(path)}";
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }

    internal void ReadFromFileCsv(string path, out string message)
    {
        try
        {
            string text = File.ReadAllText(path);
            var lines = text.Split(",\n");

            message = "\nЗміст CSV-файлу:\n\n";
            foreach (var item in lines)
            {
                message += item + "\n\n";
            }
            foreach (var item in lines)
            {
                Player? player;
                bool isSuccess = Player.TryParse(item, out player);
                if (isSuccess) _players.Add(player.ChatId, player);
            }
        }
        catch (IOException ex)
        {
            message = $"Помилка прочитання CSV-файлу: {ex.Message}";
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }

    internal void SaveToFileJson(string path, out string message)
    {
        try
        {
            StringBuilder sb = new();
            foreach (var item in _players.Values)
            {
                sb.Append(JsonSerializer.Serialize(item));
                sb.Append("\n");
            }
            File.WriteAllText(path, sb.ToString());
            message = $"JSON-файл знаходиться за шляхом: {Path.GetFullPath(path)}";
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }

    internal void ReadFromFileJson(string path, out string message)
    {
        try
        {
            List<string> lines = File.ReadAllLines(path).ToList();

            message = "\nContents of JSON Account file:\n\n";
            foreach (var item in lines)
            {
                message += item + "\n";
            }

            foreach (var line in lines)
            {
                Player? account = JsonSerializer.Deserialize<Player>(line);
                if (account != null) _players.Add(account.ChatId, account);
            }

        }
        catch (IOException ex)
        {
            message = $"Reading JSON file error: {ex.Message}";
        }
        catch (Exception ex)
        {
            message = ex.Message;
        }
    }

    public override bool Equals(object? obj)
    {
        var item = obj as PlayerHandler;
        if (item is null)
        {
            return false;
        }

        Player[] arr1 = item._players.Values.ToArray();
        Player[] arr2 = this._players.Values.ToArray();

        if (arr1.Length != arr2.Length) return false;
        for (int i = 0; i < item._players.Count; i++)
        {
            if (arr1[i] != arr2[i]) return false;
        }
        return true;
    }
}
