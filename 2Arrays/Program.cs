internal class Program
{
    /*
    Напишите приложение для одновременного выполнения двух задач в потоках.
    Нужно подсчитать сумму элементов каждого из массивов а потом сложить
    эти суммы полученные после выполнения каждого из потоков и вывести результат на экран
    */
    static int[] arr1 = { 1, 2, 3 };
    static int[] arr2 = { 4, 5, 6 };

    static int summ1, summ2;
    public static void getSumm1()
    {
        summ1 = 0;
        for (int i = 0; i < arr1.Length; i++)
        {
            summ1 += arr1[i];
        }
    }
    public static void getSumm2()
    {
        summ2 = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            summ2 += arr2[i];
        }
    }

    private static void Main(string[] args)
    {
        Thread tr1 = new Thread(getSumm1);
        tr1.Start();
        tr1.Join();
        Console.WriteLine(summ1);

        Thread tr2 = new Thread(getSumm2);
        tr2.Start();
        tr2.Join();
        Console.WriteLine(summ2);

        Console.WriteLine(summ1 + summ2);
    }
}