using System.Diagnostics;

// Reversing array with N length and N/2 length

const int WIDTH = 10000;

int[] array = new int[WIDTH];

for (int i = 0; i < WIDTH; i++)
{
    array[i] = i;
}

Stopwatch timer = new Stopwatch();


timer.Start();

int[] firstArray = new int[WIDTH];

for (int j = 0; j < WIDTH; j++)
{
    for (int i = 0; i < WIDTH; i++)
    {
        firstArray[i] = array[(WIDTH - 1) - i];
    }
}

timer.Stop();

Console.WriteLine("Elapsed Time (ms): " + timer.ElapsedMilliseconds);

Console.WriteLine("Control " + firstArray[0] + " " + firstArray[1]);


timer.Reset();


timer.Start();

int[] secondArray = new int[WIDTH];

for (int j = 0; j < WIDTH; j++)
{
    for (int i = 0; i < WIDTH / 2; i++)
    {
        secondArray[(WIDTH - 1) - i] = array[i];
        secondArray[i] = array[(WIDTH - 1) - i];
    }
}

timer.Stop();

Console.WriteLine("\nElapsed Time (ms): " + timer.ElapsedMilliseconds);

Console.WriteLine("Control " + secondArray[0] + " " + secondArray[1]);


Console.ReadLine();