using System;

public class Height
{
    public int Feet;
    public double Inches;

    // Default constructor
    public Height()
    {
        Feet = 0;
        Inches = 0.0;
    }

    // Parameterized constructor
    public Height(int feet, double inches)
    {
        Feet = feet;
        Inches = inches;
    }

    // Add heights and return new Height
    public Height AddHeights(Height h2)
    {
        double totalInches = Inches + h2.Inches;
        int totalFeet = Feet + h2.Feet + (int)(totalInches / 12);
        double newInches = totalInches % 12;
        return new Height(totalFeet, newInches);
    }

    public override string ToString()
    {
        return $"Height - {Feet} feet {Inches:F1} inches";
    }
}

class Program
{
    static void Main()
    {
        Height p1 = new Height(5, 6.5);
        Height p2 = new Height(5, 7.5);
        
        Console.WriteLine(p1);
        Console.WriteLine(p2);
        Console.WriteLine(p1.AddHeights(p2));
    }
}
