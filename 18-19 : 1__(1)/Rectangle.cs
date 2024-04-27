using System;

[Serializable]
class Rectangle : Figure
{
    protected double b;
    public Rectangle(double a, double b) : base(a)
    {
        this.b = b;
    }

    public override double CalculateS()
    {
        return a * b;
    }

    public override double CalculateP()
    {
        return 2 * (a + b);
    }

    public override string ToString()
    {
        return $"a: {a}, b: {b}, S: {CalculateS()}, P: {CalculateP()}";
    }
}