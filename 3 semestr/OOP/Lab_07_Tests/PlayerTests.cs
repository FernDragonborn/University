using Lab_07;
using Lab_07.enums;
using static Lab_07.misc.Interactions;

namespace Lab_07_Tests;
[TestClass]
public class PlayerTests
{
    [TestMethod]
    public void ApplyInteraction()
    {
        //Arrange
        var actual = new Player("name", 1);

        //Act
        actual.ApplyInteraction(IntrWorkBarista);

        //Assert
        Assert.AreEqual(0, actual.Day);
        Assert.AreEqual(2, actual.Time);
        Assert.AreEqual(50, actual.Energy);
        Assert.AreEqual(73, actual.Happiness);
        Assert.AreEqual(75, actual.Health);
        Assert.AreEqual(120, actual.Money);
        Assert.AreEqual(Menus.Day, actual.State);
    }
    [TestMethod]
    public void ApplyCustomInteraction()
    {
        //Arrange
        var actual = new Player("name", 1);

        //Act
        actual.ApplyInteraction(-1, -10, 10, -10, 10);

        //Assert
        Assert.AreEqual(0, actual.Day);
        Assert.AreEqual(3, actual.Time);
        Assert.AreEqual(90, actual.Energy);
        Assert.AreEqual(70, actual.Happiness);
        Assert.AreEqual(90, actual.Health);
        Assert.AreEqual(90, actual.Money);
        Assert.AreEqual(Menus.Day, actual.State);
    }

    [TestMethod]
    public void ToStringTest()
    {
        Player actual = new("name", 1);
        string expected = "Айді: 1 \nІм'я: name \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";

        Assert.AreEqual(expected, actual.ToString());
    }

    [TestMethod]
    public void Parse()
    {
        string s = "Айді: 1 \nІм'я: name \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";
        Player expected = new("name", 1);

        var actual = Player.Parse(s);

        Assert.AreEqual(expected.Day, actual.Day);
        Assert.AreEqual(expected.Time, actual.Time);
        Assert.AreEqual(expected.Energy, actual.Energy);
        Assert.AreEqual(expected.Happiness, actual.Happiness);
        Assert.AreEqual(expected.Health, actual.Health);
        Assert.AreEqual(expected.Money, actual.Money);
        Assert.AreEqual(expected.State, actual.State);
    }

    [TestMethod]
    public void TryParse()
    {
        string s = "Айді: 1 \nІм'я: name \nЧас: 4 \nГроші: 100 \nЕнергія: 80 \nЗдоров'я: 80 \nЩастя: 80 \nДень: 0 \nОчки: 340";
        Player p = null;

        Assert.IsTrue(Player.TryParse(s, out p));
    }

    [TestMethod]
    public void Score()
    {
        Player p = new("name", 1);

        Assert.AreEqual(340, p.Score);
    }

    [TestMethod]
    public void operatorEqual()
    {
        Player p1 = new("name", 1);
        Player p2 = new("name", 1);

        Assert.IsTrue(p1 == p2);
    }
}
