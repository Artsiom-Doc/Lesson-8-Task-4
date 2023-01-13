/*Задача 4*. Сформируйте двухмерный массив из 
неповторяющихся случайных двузначных чисел. 
Напишите программу, которая будет построчно 
выводить массив. Обратите внимание, 
что максимальный размер такого массива ограничен. 
Проверку эл-та на присутствие в массиве можно вынести 
в отдельную функцию.
Например,
11 22 78
12 47 96
25 87 88*/

Random rnd = new Random();
int row = rnd.Next(2, 10);
int column = rnd.Next(2, 10);
int[,] array = new int[row, column];

void FillArray(ref int[,] array) 
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = rnd.Next(10,99);
        }
    }
}

int CheckingUniqueness(int element_of_array, ref int[,] array) 
{
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (element_of_array == array[i, j])
            {
                count++;
            }
        }
    }
    return count;
}


void FillArrayUniq(ref int[,] array) 
{
    int count;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            count = CheckingUniqueness(array[i, j], ref array);
            if (count > 1)
            {
                array[i, j] = rnd.Next(10,99);
                j--;
            }
        }
        
    }
}

void PrintArray(ref int[,] array) 
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write(array[i, j] + " ");
        }
        Console.WriteLine();
    }
}

FillArray(ref array);
Console.WriteLine("Первоночальный массив: ");
PrintArray(ref array);
FillArrayUniq(ref array);
Console.WriteLine("Массив c уникальными элементами: ");
PrintArray(ref array);

