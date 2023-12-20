using static Lab5.misc.Interactions;

namespace Lab5.misc
{
    internal static class Messages
    {
        internal static readonly string MessageWork = "Доступні роботи:" +
                                             $"\n\n1: {IntrWorkBarista.Name}\nЧас: {IntrWorkBarista.Time}\nГроші: {IntrWorkBarista.Money}\nЕнергія:  {IntrWorkBarista.Energy}\nЩастя: {IntrWorkBarista.Happiness}\nЗдоров'я: {IntrWorkBarista.Health}" +
                                             $"\n\n2: {IntrWorkTutor.Name}\nЧас: {IntrWorkTutor.Time}\nГроші: {IntrWorkTutor.Money}\nЕнергія:  {IntrWorkTutor.Energy}\nЩастя: {IntrWorkTutor.Happiness}\nЗдоров'я: {IntrWorkTutor.Health}" +
                                             $"\n\n3: {IntrWorkFreelance.Name} \nЧас: {IntrWorkFreelance.Time}\nГроші: {IntrWorkFreelance.Money}\nЕнергія:  {IntrWorkFreelance.Energy}\nЩастя: {IntrWorkFreelance.Happiness}\nЗдоров'я: {IntrWorkFreelance.Health}";

        internal static readonly string MessageLeisure = "Доступний відпочинок:" +
                                                         $"\n\n4: {IntrLeisureLake.Name} \nЧас: {IntrLeisureLake.Time}\nГроші: {IntrLeisureLake.Money}\nЕнергія:  {IntrLeisureLake.Energy}\nЩастя: {IntrLeisureLake.Happiness}\nЗдоров'я: {IntrLeisureLake.Health}" +
                                                         $"\n\n5: {IntrLeisureGym.Name}\nЧас: {IntrLeisureGym.Time}\nГроші: {IntrLeisureGym.Money}\nЕнергія:  {IntrLeisureGym.Energy}\nЩастя: {IntrLeisureGym.Happiness}\nЗдоров'я: {IntrLeisureGym.Health}" +
                                                         $"\n\n6: {IntrLeisureFriend.Name}\nЧас: {IntrLeisureFriend.Time}\nГроші: {IntrLeisureFriend.Money}\nЕнергія:  {IntrLeisureFriend.Energy}\nЩастя: {IntrLeisureFriend.Happiness}\nЗдоров'я: {IntrLeisureFriend.Health}";
    }
}