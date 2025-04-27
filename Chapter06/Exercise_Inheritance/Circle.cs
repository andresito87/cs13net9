namespace Packt.Shared;

public class Circle : Shape
{
    public double Radius { get; set; }
    public override double? Area
    {
        get
        {
            return Math.PI * Math.Pow(Radius, 2);
        }
    }

    public Circle(double radius)
    {
        Radius = radius;
    }

}