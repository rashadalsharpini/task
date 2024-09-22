public abstract class GeoShape
{
    public double Dim1 { get; set; }
    public double Dim2 { get; set; }
    public abstract double CalcArea();
}

public class Circle : GeoShape
{
    public Circle(double radius)
    {
        Dim1 = radius;
    }

    public override double CalcArea()
    {
        return Math.PI * Dim1 * Dim1;
    }
}

public class Triangle : GeoShape
{
    public Triangle(int lengthBase, int Height)
    {
        Dim1 = lengthBase;
        Dim2 = Height;
    }

    public override double CalcArea()
    {
        return Dim1 * Dim2 * 0.5;
    }
}

public class Rectangle : GeoShape
{
    public Rectangle(int width, int height)
    {
        Dim1 = width;
        Dim2 = height;
    }

    public override double CalcArea()
    {
        return Dim1 * Dim2;
    }
}

class program
{
    static void Main()
    {
        GeoShape[] shapes = new GeoShape[]
        {
            new Circle(5),
            new Triangle(3, 4),
            new Rectangle(3, 4)
        };
        foreach (GeoShape shape in shapes)
        {
            Console.WriteLine($"The area of the {shape.GetType().Name} is {shape.CalcArea()}");
        }
    }
}