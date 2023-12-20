namespace PR1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string stra_a = "-1", string str_b = "1", str_c = "0";
            try
            {
                double a = double.Parse(stra_a),
                b
str c =
b = double.c = double.
if (c
0) throw new DivideByZeroException("3");
                if (a < 0) throw new
                double f = (Math.Sqrt(a) + b) / c; Console.Write(f);
catch (OverflowException)
Console.Write ) ;
catch (DivideByZeroException)
Console.Write("2");
            }
        }