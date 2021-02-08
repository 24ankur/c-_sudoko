using System;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var arr = new int[n, n];

            for (var i = 0; i <n; i++)
            {
                var numList = new string[n];
                numList = Console.ReadLine().Split();
                for (var j = 0; j < n; j++)
                {
                    arr[i, j] = Convert.ToInt32(numList[j]);
                }
            }
            sudoko(0, 0, arr, arr.GetLength(0) - 1, arr.GetLength(1) - 1);
            Console.ReadLine();
        }
        static void sudoko(int ir, int ic, int[,] arr, int fr, int fc)
        {
           

            if (ic > fc)
            {
                sudoko( ir + 1, 0, arr, fr, fc);
                return;
            }
            if (ir > fr)
            {
                Display(arr);
                return;
            }

            if (arr[ir, ic] != 0)

            {
                sudoko(ir, ic + 1, arr, fr, fc);
                return;

            }
            for (int i = 1; i <= 9; i++)
            {
                if (IsItSafe(arr, ir, ic, i))
                {
                    arr[ir, ic] = i;
                    sudoko( ir, ic + 1, arr, fr, fc);
                    arr[ir, ic] = 0;
                    
                }
            }
        }
        static bool IsItSafe(int[,] arr,int row,int col,int value)
        {
            for(int j=0;j<arr.GetLength(0);j++)
            {
                if (arr[row,j]==value) //row
                {
                    return false;
                }
            }
            for (int j=0;j<arr.GetLength(1);j++)
            {
                if (arr[j,col]==value)
                {
                    return false;
                }
            }
            int sr = row - row % 3;
            int sc = col - col % 3;
            for(int r=sr;r<sr+3;r++)
            {
                for(int c=sc;c<sc+3;c++)
                {
                    if (arr[r,c]==value)
                    {
                        return false;
                    }
                }

            }
            return true;

        }
        static void Display(int[,] arr)
            {
            for(int i=0;i<9;i++)
            {
                
                for (int j=0;j<9;j++)
                {
                    
                    Console.Write(arr[i, j] + " ");


                }
                Console.WriteLine();
            }
            

            }

        
        }
    

