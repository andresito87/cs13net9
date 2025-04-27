namespace Packt.Shared;

public class Shape
{
    #region Properties
    public double? Height { get; set; }
    public double? Width { get; set; }
    public virtual double? Area { get { return null; } }


    #endregion

}