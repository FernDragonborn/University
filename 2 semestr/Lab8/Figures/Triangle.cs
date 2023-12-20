namespace Lab8.Figures
{
    internal class Triangle : FigureBase, IFigure
    {
        internal Triangle(int a, int b, int c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }
        internal int c { get; set; }
        Lab8.FigureEnum IFigure.Type => Lab8.FigureEnum.triangle;

        public override string ToString()
        {
            return $"Трикутник зі сторонами: {a}, {b}, {c}";
        }

        public int CalculateP()
        {
            return a + b + c;
        }
    }
}