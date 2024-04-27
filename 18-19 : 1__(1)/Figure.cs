using System;

[Serializable]
abstract class Figure : IComparable<Figure>
{
    protected double a;
    public Figure(double a)
    {
        this.a = a;
    }


    public abstract double CalculateS();
    public abstract double CalculateP();
    public abstract override string ToString();
    public int CompareTo(Figure other)
    {
        // Сравниваем текущую фигуру с другой по площади
        double thisArea = CalculateS();
        double otherArea = other.CalculateS();

        if (thisArea < otherArea)
            return -1; // отрицательное число, если текущий объект меньше параметра;
        else if (thisArea > otherArea)
            return 1; // положительное число, если текущий объект больше параметра. 
        else
            return 0; // 0 – если текущий объект и параметр равны;
    }
}


//base 