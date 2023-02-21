using System;

class UseOperator
{
    public struct Fraction
    {
        private int up;
        private int down;

        public Fraction(int up, int down = 1)
        {
            this.up = up;
            this.down = down;
        }

        //用户自定义运算符必须是public static
        public static Fraction operator +(Fraction x, Fraction y)
        {
            //Object initializer
            var ans = new Fraction
            {
                down = x.down * y.down,
                up = x.down * y.up + x.up * y.down
            };
            return ans;
        }

        public override string ToString()
        {
            return $"{up}/{down}";
        }
    }


    public static void TestOperator2()
    {
        Fraction x = new Fraction(3, 5);
        Fraction y = new Fraction(2);
        Console.WriteLine(x + y);
    }
}