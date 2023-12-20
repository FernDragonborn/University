namespace Lab8.Figures
{
    public class Rectangle : FigureBase, IFigure
    {
        protected internal Rectangle() { }
        internal Rectangle(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

        Lab8.FigureEnum IFigure.Type => Lab8.FigureEnum.rectangle;

        public override string ToString()
        {
            return $"Прямокутник зі сторонами: {a}, {b}";
        }

        public int CalculateP()
        {
            return a + b;
        }
    }
}
