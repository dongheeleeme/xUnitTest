namespace Sorting;

public class BubbleSorter : ISorter 
{

    public int[] Sort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            for (int j = 0; j < numbers.Length - (i + 1); j++)
            {
                if (numbers[j] > numbers[j + 1])
                {
                    int temp = numbers[j + 1];
                    numbers[j + 1] = numbers[j];
                    numbers[j] = temp;
                }
            }
        }
        return numbers;
    }
}
