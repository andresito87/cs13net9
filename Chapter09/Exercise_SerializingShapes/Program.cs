using System.Xml.Serialization;

string filePath = "shapes.xml";

// Create a list of Shapes to serialize.
List<Shape> listOfShapes = new()
{
  new Circle { Colour = "Red", Radius = 2.5 },
  new Rectangle { Colour = "Blue", Height = 20.0, Width = 10.0 },
  new Circle { Colour = "Green", Radius = 8.0 },
  new Circle { Colour = "Purple", Radius = 12.3 },
  new Rectangle { Colour = "Blue", Height = 45.0, Width = 18.0 }
};

// Guardar en XML (serializar)
XmlSerializer serializerXml = new(typeof(List<Shape>), new Type[] { typeof(Circle), typeof(Rectangle) });
using (FileStream stream = File.Create(filePath))
{
    serializerXml.Serialize(stream, listOfShapes);
}

// Cargar desde XML (deserializar)
WriteLine("Loading shapes from XML:");

FileStream fileXml = File.OpenRead(filePath);
List<Shape>? loadedShapesXml =
  serializerXml.Deserialize(fileXml) as List<Shape>;
foreach (Shape item in loadedShapesXml!)
{
    WriteLine("{0} is {1} and has an area of {2:N2}",
      item.GetType().Name, item.Colour, item.Area);
}


