using System;

[Serializable]
class Triangle : Figure
{

    protected double b;
    protected double c;
    public Triangle(double a, double b, double c):base(a)
    {
        this.b = b;
        this.c = c;
    }

    public override double CalculateS()
    {
        double s = (a + b + c) / 2;
        return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
    }

    public override double CalculateP()
    {
        return a + b + c;
    }
    
    public override string ToString()
    {
        return $"Side a: {a}, Side b: {b}, Side c: {c}, S: {Math.Round(CalculateS(), 3)}, P: {CalculateP()}";
    }
}