using System;

namespace Abstraction
{
    public abstract class Figure
    {
        public Figure()
        {
        }

        public Figure(double radius)
        {
            this.Radius = radius;
        }

        public Figure(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public virtual double Width
        {
            get
            {
                return this.Width;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("width can't be zero or negative number");
                }

                this.Width = value;
            }
        }

        public virtual double Height
        {
            get
            {
                return this.Height;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("height can't be zero or negative number");
                }

                this.Height = value;
            }
        }

        public virtual double Radius
        {
            get
            {
                return this.Radius;
            }

            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("radius can't be zero or negative number");
                }

                this.Radius = value;
            }
        }
    }
}
