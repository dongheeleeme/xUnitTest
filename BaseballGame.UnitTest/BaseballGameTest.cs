using System.Collections.Generic;
using Moq;
using Xunit;

namespace BaseballGame.UnitTest;

public class BaseballGameTest
{
    private readonly Mock<IRandomNumberListGenerator> _randomNumberListGeneratorMock = new();

    [Theory]
    [MemberData(nameof(CheckCases), 3)]
    public void Check_Numbers_With_Valid_Input(
        int[] randomNumbers,
        string numberText,
        GuessResult expected
    )
    {
        _randomNumberListGeneratorMock
            .Setup(generator => generator.Generate(randomNumbers.Length))
            .Returns(randomNumbers);

        var baseballGameController = new BaseballGameController(_randomNumberListGeneratorMock.Object, new InputNumberTextValidator());

        var actual = baseballGameController.Check(numberText);

        Assert.Equal(expected, actual);
    }

    [Theory]
    [InlineData("1234")]
    [InlineData("1a3")]
    public void Check_Numbers_With_Invalid_Input(
        string numberText
    )
    {
        _randomNumberListGeneratorMock
            .Setup(generator => generator.Generate(3))
            .Returns(new[] {1, 2, 3});

        var baseballGameController = new BaseballGameController(_randomNumberListGeneratorMock.Object, new InputNumberTextValidator());

        Assert.Throws<BaseballGameException>(() => baseballGameController.Check(numberText));
    }

    public static IEnumerable<object[]> CheckCases =>
        new List<object[]>
        {
            new object[] {new[] {1, 2, 3}, "123", new GuessResult {BallCount = 0, StrikeCount = 3}},
            new object[] {new[] {1, 2, 3}, "136", new GuessResult {BallCount = 1, StrikeCount = 1}},
            new object[] {new[] {1, 2, 3}, "321", new GuessResult {BallCount = 2, StrikeCount = 1}},
            new object[] {new[] {1, 2, 3}, "126", new GuessResult {BallCount = 0, StrikeCount = 2}},
            new object[] {new[] {1, 2, 3}, "312", new GuessResult {BallCount = 3, StrikeCount = 0}},
            new object[] {new[] {1, 2, 3}, "456", new GuessResult {BallCount = 0, StrikeCount = 0}},
        };
}
