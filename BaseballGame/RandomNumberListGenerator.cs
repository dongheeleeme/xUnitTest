namespace BaseballGame;

public class RandomNumberListGenerator : IRandomNumberListGenerator
{
    public int[] Generate(int length)
    {
        int[] numbers = new int[length];
        var index = 0;

        while (index <= length - 1)
        {
            var randomNumber = GenerateRandomNumber();
            if (CheckExistingNumber(numbers, randomNumber))
            {
                continue;
            }

            numbers[index] = randomNumber;
            index++;
        }

        return numbers;
    }

    private static int GenerateRandomNumber() => Random.Shared.Next(0, 10);

    private static bool CheckExistingNumber(int[] numbers, int randomNumber) => numbers.Contains(randomNumber);
}