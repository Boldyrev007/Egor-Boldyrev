using System;
class MainClass
{
    public static void Main()
    {
        bool choice = Choice_Main_or_Auto();

        Console.WriteLine("One-Dimensional");
        Console.WriteLine("Ввидите длину массива: ");
        int length = int.Parse(Console.ReadLine());
        OnoDimensional array_onedimensional = new OnoDimensional(length, choice);
        array_onedimensional.PrintArray_One();
        array_onedimensional.Average_Value_one();
        array_onedimensional.over_one_hundred();
        array_onedimensional.without_repeats();

        Console.WriteLine();
        Console.WriteLine("Two-Dimensional");
        (int, int) twoInput = Input();
        TwoDimensional array_twodimensional = new TwoDimensional(twoInput.Item1, twoInput.Item2);
        array_twodimensional.Average_Value_two();
        array_twodimensional.matrixValue_two();
    }

    static bool Choice_Main_or_Auto()
    {
        Console.WriteLine("Массив будет вручную(0) или автоматически(1)? ");
        int a = int.Parse(Console.ReadLine());
        bool choice = true;
        if(a == 0)
        {
            choice = false;
        }
        else if(a == 1)
        {
            choice = true;
        }
        return choice;
    }

    static (int, int) Input()
    {
        Console.WriteLine("Введите число строчек в массиве: ");
        int rows = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число колоннок в массиве: ");
        int columns = int.Parse(Console.ReadLine());
        return(rows, columns);
    }

    
}


class OnoDimensional
{
    private int[] array;

    private void fill_RandomArray()
    {
        Random random = new Random();
        for (int i = 0; i < array.Length; i++)
        {
            int value = random.Next(-150, 150);
            array[i] = value;
        }
    }

    private int[] fillArray_by_User(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = int.Parse(Console.ReadLine());
        }
        return array;
    }

    public OnoDimensional(int length, bool choice)
    {
        array = new int[length];
        if (choice)
        {
            fill_RandomArray();
        }
        else
        {
            fillArray_by_User(array);
        }
    }

    public void Average_Value_one()
    {
        Console.WriteLine("\nЗадание 1");
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            counter += array[i];
        }
        Console.WriteLine(counter / array.Length);
    }

    public void PrintArray_One()
    {
        foreach(int item in array)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    public void over_one_hundred()
    {
        Console.WriteLine("\nЗадание 2");
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) < 100)
            {
                counter += 1;
            }
        }
        int[] new_Array = new int[counter];
        int x = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (Math.Abs(array[i]) < 100)
            {
                new_Array[x] = array[i];
                x++;
            }
        }
        foreach (var item in new_Array)
        {
            Console.WriteLine(item);
        }
    }

    public void without_repeats()
    {
        Console.WriteLine("\nЗадание 3");
        int newArrayLength = array.Length;
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = i; j < array.Length; j++)
            {
                if (array[i] == array[j] && i != j)
                {
                    newArrayLength--;
                    break;
                }
            }
        }
        int[] newArray = new int[newArrayLength];
        for (int i = 0; i < newArray.Length; i++)
        {
            newArray[i] = int.MinValue;
        }
        int counter = 0;
        for (int i = 0; i < array.Length; i++)
        {
            if (!Exists(array[i], newArray))
            {
                newArray[counter] = array[i];
                counter++;
            }
        }
        PrintArray(newArray);
    }

    private static bool Exists(int value, int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == value)
            {
                return true;
            }
        }
        return false;
    }

    private static void PrintArray(int[] array)
    {
        foreach (var element in array)
        {
            Console.Write(element + " ");
        }
        Console.WriteLine();
    }
}


class TwoDimensional
{
    private int rows, columns;
    private int[,] array;

    public TwoDimensional(int rows, int columns, bool choice = false)
    {
        array = new int[rows, columns];
        if (!choice)
        {
            array = GetTwoDimensionalArray(rows, columns);
        }
        else
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; i++)
                {
                    array[i, j] = int.Parse(Console.ReadLine());
                }
            }
        }
    }

    private int[,] GetTwoDimensionalArray(int rows, int columns)
    {
        Random random = new Random();
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                array[i, j] = random.Next(-150, 150);
            }
            Console.WriteLine();
        }
        return array;
    }

    public void Average_Value_two()
    {
        Console.WriteLine("\nЗадание 1");
        int counter = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                counter += array[i, j];
            }
        }
        Console.WriteLine(counter / array.Length);
    }

    public void matrixValue_two()
    {
        Console.WriteLine("\nЗадание 2.1");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                Console.Write(array[i, j] + " ");
            }
            Console.Write("\n");
        }

        Console.WriteLine("\nЗадание 2.2");
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                var element = i % 2 == 0
                    ? array[i, array.GetLength(1) - 1 - j]
                    : array[i, j];
                Console.Write($"{element} ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}

