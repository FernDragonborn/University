namespace Lab8.Figures;

internal interface IFigure
{
    internal Lab8.FigureEnum Type
    {
        get;
    }

    internal int CalculateP();
}