using System;
using System.Collections;
using System.Collections.Generic;

public class MyList<T> : IEnumerable<T>
{
    private T[] array;

    // Получение общего количества элементов
    public int Count
    {
        get { return array.Length; }
    }

    // Конструктор без параметров создает пустой массив
    public MyList()
    {
        array = new T[0];
    } 

    // Конструктор с параметрами использует их для создания массива
    public MyList(params T[] items)
    {
        array = items;
    }

    // Индексатор для получения значения элемента по указанному индексу
    public T this[int index]
    {
        get
        {
            if (index >= 0 && index < array.Length)
            {
                return array[index];
            }
            else
            {
                throw new IndexOutOfRangeException();
            }
        }
    }

    // Метод добавления элемента в конец массива
    public void Add(T item)
    {
        Array.Resize(ref array, array.Length + 1);
        array[array.Length - 1] = item;
    }

    //  удаляет элемент по указанному индексу,
    //  создавая новый массив с уменьшенным размером и копируя в него все элементы, кроме удаляемого
    public void RemoveAt(int index)
    {
        if (index >= 0 && index < array.Length)
        {
            T[] newArray = new T[array.Length - 1];
            for (int i = 0, j = 0; i < array.Length; i++)
            {
                if (i != index)
                {
                    newArray[j] = array[i];
                    j++;
                }
            }
            array = newArray;
        }
        else
        {
            throw new IndexOutOfRangeException();
        }
    }

    // Очищает массив, создавая новый массив нулевого размера
    public void Clear()
    {
        array = new T[0];
    }

    // Реализация интерфейса IEnumerable<T> для поддержки использования foreach
    public IEnumerator<T> GetEnumerator()
    {
        foreach (T item in array)
        {
            yield return item;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        MyList<int> myList = new MyList<int>(1, 2, 3);

        //myList.Add(1);
       // myList.Add(2);
       // myList.Add(3);

        Console.WriteLine(myList[0]); // Выводит: 1
        Console.WriteLine(myList[1]); // Выводит: 2
        Console.WriteLine(myList[2]); // Выводит: 3

        Console.WriteLine("Количество элементов" + myList.Count); // Выводит: 3

        foreach (int item in myList)
        {
            Console.WriteLine(item);
        }
        // Выводит:
        // 1
        // 2
        // 3

        myList.Clear();
        Console.WriteLine(myList.Count); // выводит 0

        MyList<int> myList1 = new MyList<int> { 1, 2, 3, 4, 5 };
        foreach (var item in myList1)
        {
            Console.WriteLine($"Element: {item}");
        }
    }
}