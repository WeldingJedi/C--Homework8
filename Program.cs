void Task54()
{
    //Задача 54: Задайте двумерный массив. Напишите программу, которая
    //упорядочит по убыванию элементы каждой строки двумерного массива.

    Random random = new Random();
    int rows = random.Next(3, 6);
    int columns = random.Next(3, 6);
    int[,] array = new int[rows, columns];
    FillArray(array);
    PrintArray(array);
    SortArrayRows(array);
    Console.WriteLine("\nSorted array rows:");
    PrintArray(array);
}

void Task56()
{
    //Задача 56: Задайте прямоугольный двумерный массив. Напишите
    //программу, которая будет находить строку с наименьшей суммой элементов.

    Random random = new Random();
    int rows = random.Next(3, 5);
    int columns = random.Next(5, 7);
    //if (rows == columns) rows += 2; // можно, например, поступить таким образом, если границы рандома задать одинаковыми для строк и столбцов
    int[,] array = new int[rows, columns];
    FillArray(array);
    PrintArray(array);
    SmallestRowAmount(array);
}

void Task58()
{
    //Задача 58: Заполните спирально массив 4 на 4 числами
    //от 1 до 16.

    Random random = new Random();
    int rows = random.Next(4, 7); // можно просто цифры, конечно, задать, но так интереснее
    int columns = random.Next(4, 7);
    int[,] array = new int[rows, columns];
    FillSpiralArray(array);
    Console.WriteLine($"Array {rows} x {columns} filled in a spiral from 1 to {rows * columns}: ");
    PrintArray(array);
}

void addTask61()
{
    //Доп.Задача 61: Задайте две матрицы. Напишите
    //программу, которая будет находить произведение
    //двух матриц.

    Random random = new Random();
    int rowsA = random.Next(3, 6);
    int columnsA = random.Next(3, 5); // поправил границы, чтобы не так часто выпадали не пермножаемые матрицы
    int rowsB = random.Next(3, 5);
    int columnsB = random.Next(3, 6);
    int[,] matrixA = new int[rowsA, columnsA];
    int[,] matrixB = new int[rowsB, columnsB];
    int[,] matrixC = new int[rowsA, columnsB];
    FillArray(matrixA);
    FillArray(matrixB);
    Console.WriteLine("Matrix 'A': ");
    PrintArray(matrixA);
    Console.WriteLine("Matrix 'B': ");
    PrintArray(matrixB);

    if (columnsA == rowsB)
    {
        Console.WriteLine("Multiplying of matrices is: ");
        MatricesMultiply(matrixC, matrixA, matrixB);
        PrintArray(matrixC);
    }
    else Console.WriteLine("Such kind of matrices couldn't be multiplied");
}

//Task54();
//Task56();
//Task58();
//addTask61();

void FillArray(int[,] array)
{
    Random random = new Random();
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            array[i, j] = random.Next(-9, 10);
        }
    }
}

void PrintArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            Console.Write($"[{array[i, j]}]\t");
        }
        Console.WriteLine();
    }
}

void SortArrayRows(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            int minPos = j;
            for (int k = j + 1; k < columns; k++)
            {
                if (array[i, k] < array[i, minPos]) minPos = k;
            }
            int temp = array[i, j];
            array[i, j] = array[i, minPos];
            array[i, minPos] = temp;
        }
    }
}

void SmallestRowAmount(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int[] counter = new int[rows];
    int sum = 0;
    Console.Write("Row amounts are: ");

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            sum += array[i, j];
        }
        counter[i] = sum;
        Console.Write($"[{counter[i]}] ");
        sum = 0;
    }
    Console.WriteLine();
    int minInd = 0;
    int pointer = 0;

    while (pointer < counter.Length)
    {
        if (counter[pointer] < counter[minInd]) minInd = pointer;
        pointer++;
    }
    Console.Write($"Minimal amount located on row {minInd} is {counter[minInd]}");
}

void FillSpiralArray(int[,] array)
{
    int rows = array.GetLength(0);
    int columns = array.GetLength(1);
    int row = 0;
    int column = 0;
    int directionX = 0;
    int directionY = 1;
    int directionChange = 0;
    int matrixEnter = columns;
    int temp;

    for (int i = 0; i < array.Length; i++)
    {
        array[row, column] = i + 1;

        if (--matrixEnter == 0)
        {
            matrixEnter = columns * (directionChange % 2) + rows * ((directionChange + 1) % 2) - (directionChange / 2 - 1) - 2;
            temp = directionY;
            directionY = -directionX;
            directionX = temp;
            directionChange++;
        }
        row += directionX;
        column += directionY;
    }
}

void MatricesMultiply(int[,] matrixC, int[,] matrixA, int[,] matrixB)
{
    for (int i = 0; i < matrixA.GetLength(0); i++)
    {
        for (int j = 0; j < matrixB.GetLength(1); j++)
        {
            for (int k = 0; k < matrixB.GetLength(0); k++)
            {
                matrixC[i, j] += matrixA[i, k] * matrixB[k, j];
            }
        }
    }
}