using Xunit;

namespace BaseballGame.UnitTest;

public class RandomNumbersGeneratorTest
{
    [Theory]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    public void Generate_TargetNumbers(
        int length,
        int expected
    )
    {
        var generator = new RandomNumberListGenerator();

        var actual = generator.Generate(length);

        Assert.Equal(expected, actual.Length);
    }
}