
namespace Sorting;

public class SelectionSorter : ISorter 
{

    public int[] Sort(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            int minIndex = i;
            int minValue = numbers[i];

            for (int j = i + 1; j < numbers.Length; j++)
            {
                if (numbers[j] < minValue)
                {
                    minIndex = j;
                    minValue = numbers[j];
                }
            }

            if (minValue != numbers[i])
            {
                int temp = numbers[i];
                numbers[i] = minValue;
                numbers[minIndex] = temp;
            }
        }

        return numbers;
    }
}
