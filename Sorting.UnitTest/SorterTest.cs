using Xunit;

namespace Sorting.UnitTest;

public class SorterTest
{
    [Fact]
    public void Bubble_Sorting()
    {
        int[] numbers = new[] { 3, 2, 4, 1, 8 };
        ISorter sorter = new BubbleSorter();
        int[] actual = sorter.Sort(numbers);

        Assert.Equal(new[] { 1, 2, 3, 4, 8 }, actual);
    }

    [Fact]
    public void Selection_Sorting()
    {
        int[] numbers = new[] { 3, 2, 4, 1, 8 };
        ISorter sorter = new SelectionSorter();
        int[] actual = sorter.Sort(numbers);

        Assert.Equal(new[] { 1, 2, 3, 4, 8 }, actual);
    }
}
