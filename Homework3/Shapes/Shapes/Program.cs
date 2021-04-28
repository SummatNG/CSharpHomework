using System;

namespace Shapes
{
    public abstract class Shape
    {

        public abstract double Area
        {
            get;
        }

    }



    public class Rectangle : Shape
    {
        double length;
        double width;

        public Rectangle(double length, double width)
        {
            this.length = length;
            this.width = width;
        }

        public void Judge()
        {
            if (length <= 0 || width <= 0)
            {
                Console.WriteLine("形状不合法");
            }
        }

        public override double Area
        {
            get
            {
                return length * width;
            }
        }
    }



    public class Square : Shape
    {
        double side;

        public Square(double side)
        {
            this.side = side;
        }

        public void Judge()
        {
            if (side <= 0)
            {
                Console.WriteLine("形状不合法");
            }
        }

        public override double Area
        {
            get
            {
                return side * side;
            }
        }

    }




    public class Triangle : Shape
    {
        double a;
        double b;
        double c;

        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public void Judge()
        {
            if (a <= 0 || b <= 0 || c <= 0 || a + b <= c || a + c <= b || b + c <= a)
            {
                Console.WriteLine("形状不合法");
            }
        }

        public override double Area
        {
            get
            {
                double p = (a + b + c) / 2;
                return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
            }
        }
    }

    public class Circle : Shape
    {
        double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public void Judge()
        {
            if (radius <= 0)
            {
                Console.WriteLine("形状不合法");
            }
        }
        public override double Area
        {
            get
            {
                return Math.PI * radius * radius;
            }
        }
    }

    public class Test
    {
        public Shape CreateShape()
        {
            Shape shape = null;
            Random number = new Random();
            int i = number.Next(4);
            if (i == 0)
            {
                double length, width;
                length = Convert.ToDouble(new Random());
                width = Convert.ToDouble(new Random());

                shape = new Rectangle(length, width);
            }

            else if (i == 1)
            {
                shape = new Square(Convert.ToDouble(new Random()));
            }

            else if (i == 2)
            {
                shape = new Circle(Convert.ToDouble(new Random()));
            }

            else if (i == 3)
            {
                double a, b, c;
                a = Convert.ToDouble(new Random());
                b = Convert.ToDouble(new Random());
                c = Convert.ToDouble(new Random());
                shape = new Triangle(a, b, c);
            }
            return shape;

        }



        public static void Main(string[] args)
        {
            Test test = new Test();
            Shape[] shapes = new Shape[10];
            double allarea;
            allarea = 0;
            for (int i = 0; i < 10; i++)
            {
                shapes[i] = test.CreateShape();
            }

            for (int i = 0; i < 10; i++)
            {
                Console.Write("第{0}个形状是：", i + 1);
                if (shapes[i].GetType() == typeof(Rectangle))
                {
                    Console.Write("矩形");
                }
                else if (shapes[i].GetType() == typeof(Square))
                {
                    Console.Write("正方形");
                }
                else if (shapes[i].GetType() == typeof(Circle))
                {
                    Console.Write("圆形");
                }
                else if (shapes[i].GetType() == typeof(Triangle))
                {
                    Console.Write("三角形");
                }
                Console.WriteLine("\t面积为：{0}", shapes[i].Area);
                allarea += shapes[i].Area;
            }
            Console.WriteLine("总面积为：{0}", allarea);

        }

    }


}
