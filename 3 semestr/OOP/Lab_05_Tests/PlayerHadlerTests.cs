using Lab_05;

namespace Lab_05_Tests;
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
}
