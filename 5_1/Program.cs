using System;

class MyMatrix
{
    private double[,] matrix;
    private int M; // строка m
    private int N;
    public int minValue, maxValue;

    // конструктор, заполняющий матрицу случайными числами
    public MyMatrix(int rows, int cols, int min, int max)
    {
        this.M = rows;
        this.N = cols;
        this.minValue = min;
        this.maxValue = max;
        matrix = new double[rows, cols];
        Fill(min, max);
    }

    public void Fill(int min, int max)
    {
        Random random = new Random();
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                matrix[i, j] = random.Next(min, max);
            }
        }
    }

    public void ChangeSize(int newRows, int newColumns)
    {
        double[,] newMatrix = new double[newRows, newColumns];

        // Заполнение старыми значениями (в зависимости от размеров матриц)
        for (int i = 0; i < Math.Min(M, newRows); i++)
        {
            for (int j = 0; j < Math.Min(N, newColumns); j++)
            {
                newMatrix[i, j] = matrix[i, j];
            }
        }

        // Заполнение пустых элементов
        if (newRows > M || newColumns > N)
        {
            Random random = new Random();
            for (int i = 0; i < newRows; i++)
            {
                for (int j = 0; j < newColumns; j++)
                {
                    if (i >= M || j >= N)
                    {
                        newMatrix[i, j] = random.Next(minValue, maxValue);
                    }
                }
            }
        }

        this.M = newRows;
        this.N = newColumns;
        matrix = newMatrix;
    }

    public void ShowPartialy(int startRow, int endRow, int startColumn, int endColumn)
    {
        for (int i = startRow; i <= endRow; i++)
        {
            for (int j = startColumn; j <= endColumn; j++)
            {
                Console.Write(matrix[i-1, j-1] + " ");
            }
            Console.WriteLine();
        }
    }

    public void Show()
    {
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public double this[int index1, int index2]
    {
        get 
        {
            if (index1 >= 0 && index1 <= M && index2 >= 0 && index2 <= N) // 0<=...<=
            {
                return matrix[index1, index2];
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
        }
        set 
        {
            if (index1 >= 0 && index1 <= M && index2 >= 0 && index2 <= N) // 0<=...<=
            {
                matrix[index1, index2] = value;
            }
            else
            {
                throw new IndexOutOfRangeException("Index out of range");
            }
             
        } 
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyMatrix matrix = new MyMatrix(3, 3, 1, 10);
        matrix.Show();

        Console.WriteLine();

        matrix.ChangeSize(5, 5);
        matrix.Show();

        Console.WriteLine();

        matrix.ShowPartialy(1, 5, 1, 2);

        Console.WriteLine();

        Console.WriteLine(matrix[1, 4]);
        matrix[0, 0] = 99;
        Console.WriteLine(matrix[0, 0]);
    }
}
