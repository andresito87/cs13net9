using System.Drawing;

namespace Packt.Shared;

public class Rectangle : Shape
{
    public override double? Area
    {
        get
        {
            return base.Height * base.Width;
        }
    }

    public Rectangle(double height, double width)
    {
        base.Height = height;
        base.Width = width;
    }

}
