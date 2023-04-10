using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.InteropServices;

class Dice
{
    private int[] surfaces = { 0, 1, 2, 3, 4, 5, 6 };

    public Dice(int[] surfaces)
    {
        this.surfaces = surfaces;
    }

    public void up()
    {
        surfaces[0] = surfaces[1];

        surfaces[1] = surfaces[2];
        surfaces[2] = surfaces[6];
        surfaces[6] = surfaces[5];
        surfaces[5] = surfaces[0];
    }

    public void down()
    {
        surfaces[0] = surfaces[1];

        surfaces[1] = surfaces[5];
        surfaces[5] = surfaces[6];
        surfaces[6] = surfaces[2];
        surfaces[2] = surfaces[0];
    }

    public void left()
    {
        surfaces[0] = surfaces[1];

        surfaces[1] = surfaces[3];
        surfaces[3] = surfaces[6];
        surfaces[6] = surfaces[4];
        surfaces[4] = surfaces[0];
    }

    public void right()
    {
        surfaces[0] = surfaces[1];

        surfaces[1] = surfaces[4];
        surfaces[4] = surfaces[6];
        surfaces[6] = surfaces[3];
        surfaces[3] = surfaces[0];
    }

    public void rrotate()
    {
        surfaces[0] = surfaces[2];

        surfaces[2] = surfaces[4];
        surfaces[4] = surfaces[5];
        surfaces[5] = surfaces[3];
        surfaces[3] = surfaces[0];
    }

    public void lrotate()
    {
        surfaces[0] = surfaces[2];

        surfaces[2] = surfaces[3];
        surfaces[3] = surfaces[5];
        surfaces[5] = surfaces[4];
        surfaces[4] = surfaces[0];
    }

    public int getNum(int num)
    {
        return surfaces[num];
    }
}
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int[,] line = new int[n, 7];

        for(int i = 0; i < n; i++)
        {
            string[] Input = Console.ReadLine().Split(' ');
            line[i, 0] = 0;
            for (int j = 1; j < 7; j++)
            {
                line[i, j] = int.Parse(Input[j - 1]);
            }
        }

        for(int m = 0; m < n - 1; m++)
        {
            var xx = new int[7];
            var yy = new int[7];
            for (int i = 0; i < 7; i++)
            {
                xx[i] = line[m, i];
            }

            for(int i = m + 1; i < n; i++)
            {
                for(int j= 0; j < 7; j++)
                {
                    yy[j] = line[i, j];
                }
                Judge dice = new Judge(xx, yy);
                if (dice.Test(xx, yy) == true)
                {
                    Console.WriteLine("No");
                    goto end;
                }
            }
        }
        Console.WriteLine("Yes");
    end:;
    }
}

class Judge
{
    readonly int[] dice1;
    readonly int[] dice2;

    public Judge(int[] dice1, int[] dice2)
    {
        this.dice1 = dice1;
        this.dice2 = dice2;
    }

    public bool Test(int[] x, int[] y)
    {
        Dice dice1 = new Dice(x);
        Dice dice2 = new Dice(y);
        bool ans;
        for (int i = 1; i < 7; i++)
        {
            switch (i)
            {
                case 1:
                    break;
                case 2:
                    dice1.up();
                    break;
                case 3:
                    dice1.left();
                    break;
                case 4:
                    dice1.up();
                    dice1.up();
                    break;
                case 5:
                    dice1.left();
                    break;
                case 6:
                    dice1.down();
                    break;

            }
            for (int j = 0; j < 4; j++)
            {
                dice1.rrotate();
                if (dice2.getNum(2) == dice1.getNum(2))
                {
                    if (dice2.getNum(3) == dice1.getNum(3))
                    {
                        if (dice2.getNum(5) == dice1.getNum(5))
                        {
                            if (dice2.getNum(4) == dice1.getNum(4))
                            {
                                if (dice2.getNum(6) == dice1.getNum(6))
                                {
                                    if (dice2.getNum(1) == dice1.getNum(1))
                                    {
                                        ans = true;
                                        goto readend;
                                    }
                                }

                            }
                        }
                    }
                }
            }
        }
        ans = false;
    readend:;
        return (ans);
    }
}