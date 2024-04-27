using System;

[Serializable]
class Circle : Figure
{
    public Circle(double a):base(a)
    {
    }

    public override double CalculateS()
    {
        return Math.PI * a * a;
    }

    public override double CalculateP()
    {
        return 2 * Math.PI * a;
    }

    public override string ToString()
    {
        return $"Radius: {a}, S: {Math.Round(CalculateS(), 3)}, P: {Math.Round(CalculateP(), 3)}";
    }
}