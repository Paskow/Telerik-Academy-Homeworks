using System;

public class Size
{
    private double width;
    private double height;

    public Size(double width, double height)
    {
        this.width = width;
        this.height = height;
    }

    public double Width
    {
        get
        {
            return this.width;
        }
    }

    public double Height
    {
        get
        {
            return this.height;
        }
    }

    public static Size GetRotatedSize(
        Size size, double angleToBeRotaed)
    {
        double cosinus = Math.Cos(angleToBeRotaed);
        double sinus = Math.Sin(angleToBeRotaed);
        double width = (cosinus * size.Width) + (sinus * size.Height);
        double height = (sinus * size.Width) + (cosinus * size.Height);

        return new Size(width, height);
    }
}