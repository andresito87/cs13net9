namespace Packt.Shared;

public class Square : Shape
{
    public override double? Area
    {
        get
        {
            return base.Height * base.Width;
        }
    }

    public Square(double side)
    {
        base.Width = side;
        base.Height = side;
    }

}