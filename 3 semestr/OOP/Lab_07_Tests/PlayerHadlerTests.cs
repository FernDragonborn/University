using Lab_07;

namespace Lab_07_Tests;
[TestClass]
public class PlayerHadlerTests
{
    [TestMethod]
    public void AddPlayer()
    {
        PlayerHandler handler = new();
        handler.AddPlayer("name");

        Player p = handler.FindPlayer("name");

        Assert.IsNotNull(p);
    }

    [TestMethod]
    public void AddPlayerWithDay()
    {
        PlayerHandler handler = new();

        handler.AddPlayerWithDay("name", 10);
        Player p = handler.FindPlayer("name");

        Assert.AreEqual(10, p.Day);
        Assert.IsNotNull(p);
    }

    [TestMethod]
    public void TryParsePlayer()
    {
        PlayerHandler handler = new();
        string s = "Айді: 1 \nІм'я: name \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";

        bool result = handler.TryParsePlayer(s);

        Assert.IsTrue(result);
    }

    [TestMethod]
    public void FindPlayer()
    {
        PlayerHandler handler = new();
        handler.AddPlayer("name");

        Player p = handler.FindPlayer("name");

        Assert.IsNotNull(p);
    }

    [TestMethod]
    public void RemovePlayer()
    {
        PlayerHandler handler = new();
        handler.AddPlayer("name");
        Player p = handler.FindPlayer("name");

        handler.RemovePlayer(p.ChatId);
        Player actual = handler.FindPlayer("name");

        Assert.IsNull(actual);
    }

    [TestMethod]
    public void ClearCollection()
    {
        PlayerHandler handler = new();
        handler.AddPlayer("name");

        handler.ClearCollection();

        Assert.AreEqual(0, handler.count);
    }

    private const string pathCsv = @"test.csv";
    private const string pathJson = @"test.json";
    [TestMethod]
    public void SaveToFileCsv()
    {
        PlayerHandler handler = new();
        handler.AddPlayerWithChatId("nameA", 1000000002);
        handler.AddPlayerWithChatId("nameB", 1000000003);
        handler.AddPlayerWithChatId("nameC", 1000000004);
        const string expected =
            "Айді: 1000000002 \nІм'я: nameA \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340," +
            "\nАйді: 1000000003 \nІм'я: nameB \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340," +
            "\nАйді: 1000000004 \nІм'я: nameC \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";
        handler.SaveToFileCSV(pathCsv, out string message);
        string actual = File.ReadAllText(pathCsv);
        File.Delete(pathCsv);

        bool isSuccess = expected == actual && !File.Exists(pathCsv);
        Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void ReadFromFileCsv()
    {
        //Arrange
        PlayerHandler expectedHandler = new();
        expectedHandler.AddPlayerWithChatId("fern", 1000000001);
        expectedHandler.AddPlayerWithChatId("nameA", 1000000002);
        expectedHandler.AddPlayerWithChatId("nameB", 1000000003);
        expectedHandler.AddPlayerWithChatId("nameC", 1000000004);

        PlayerHandler actualHandler = new();
        actualHandler.AddPlayerWithChatId("fern", 1000000001);

        const string textToWrite =
            "Айді: 1000000002 \nІм'я: nameA \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340," +
            "\nАйді: 1000000003 \nІм'я: nameB \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340," +
            "\nАйді: 1000000004 \nІм'я: nameC \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";

        File.WriteAllText(pathCsv, textToWrite);
        actualHandler.ReadFromFileCsv(pathCsv, out string message);
        File.Delete(pathCsv);

        //Assert
        bool isSuccess = expectedHandler.Equals(actualHandler)
                         && !File.Exists(pathCsv)
                         && message.Length > 0;
        Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void SaveToFileJson()
    {
        PlayerHandler handler = new();
        handler.AddPlayerWithChatId("nameA", 1000000002);
        handler.AddPlayerWithChatId("nameB", 1000000003);
        handler.AddPlayerWithChatId("nameC", 1000000004);

        var nameA = handler.FindPlayer("nameA");
        var nameB = handler.FindPlayer("nameB");
        var nameC = handler.FindPlayer("nameC");
        string expected =
            $"{{\"Id\":\"{nameA.Id}\",\"ChatId\":1000000002,\"InGameName\":\"nameA\"," +
            $"\"State\":0,\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}}\n" +
            $"{{\"Id\":\"{nameB.Id}\",\"ChatId\":1000000003,\"InGameName\":\"nameB\"," +
            $"\"State\":0,\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}}\n" +
            $"{{\"Id\":\"{nameC.Id}\",\"ChatId\":1000000004,\"InGameName\":\"nameC\",\"State\":0," +
            $"\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}}\n";
        handler.SaveToFileJson(pathJson, out string a);
        string actual = File.ReadAllText(pathJson);
        File.Delete(pathJson);

        bool isSuccess = expected == actual && !File.Exists(pathJson);
        Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void ReadFromFileJson()
    {
        //Arrange
        PlayerHandler expectedHandler = new();
        expectedHandler.AddPlayerWithChatId("fern", 1000000001);
        expectedHandler.AddPlayerWithChatId("nameA", 1000000002);
        expectedHandler.AddPlayerWithChatId("nameB", 1000000003);
        expectedHandler.AddPlayerWithChatId("nameC", 1000000004);

        PlayerHandler actualHandler = new();
        actualHandler.AddPlayerWithChatId("fern", 1000000001);

        const string textToWrite =
            "{\"Id\":\"b94abe98-4a73-4222-8dd2-49d29b0f2e75\",\"ChatId\":1000000002,\"InGameName\":\"nameA\",\"State\":0,\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}\n{\"Id\":\"7259d968-02f1-4175-81c6-5b98a2e13918\",\"ChatId\":1000000003,\"InGameName\":\"nameB\",\"State\":0,\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}\n{\"Id\":\"004e504c-9cd4-40cb-a16f-c20e79db3880\",\"ChatId\":1000000004,\"InGameName\":\"nameC\",\"State\":0,\"Day\":0,\"Time\":4,\"Energy\":80,\"Health\":80,\"Happiness\":80,\"Money\":100,\"Score\":340}\n";

        File.WriteAllText(pathJson, textToWrite);
        actualHandler.ReadFromFileJson(pathJson, out string message);
        File.Delete(pathJson);

        //Assert
        bool isSuccess = expectedHandler.Equals(actualHandler)
                         && !File.Exists(pathJson)
                         && message.Length > 0;
        Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void ReadFromFileJson_EmptyFile()
    {
        //Arrange
        PlayerHandler expectedHandler = new();
        expectedHandler.AddPlayerWithChatId("fern", 1000000001);


        PlayerHandler actualHandler = new();
        actualHandler.AddPlayerWithChatId("fern", 1000000001);

        const string textToWrite = "";

        File.WriteAllText(pathJson, textToWrite);
        actualHandler.ReadFromFileJson(pathJson, out string a);
        File.Delete(pathJson);

        //Assert
        bool isSuccess = expectedHandler.Equals(actualHandler) && !File.Exists(pathJson);
        Assert.IsTrue(isSuccess);
    }

    [TestMethod]
    public void ReadFromFileCsv_EmptyFile()
    {
        //Arrange
        PlayerHandler expectedHandler = new();
        expectedHandler.AddPlayerWithChatId("fern", 1000000001);

        PlayerHandler actualHandler = new();
        actualHandler.AddPlayerWithChatId("fern", 1000000001);

        const string textToWrite = "";

        File.WriteAllText(pathCsv, textToWrite);
        actualHandler.ReadFromFileCsv(pathCsv, out string a);
        File.Delete(pathCsv);

        //Assert
        bool isSuccess = expectedHandler.Equals(actualHandler) && !File.Exists(pathJson);
        Assert.IsTrue(isSuccess);
    }
}

