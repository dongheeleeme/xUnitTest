using System.Collections.Generic;
using Xunit;

namespace BaseballGame.UnitTest;

public class GuessResultTest
{
    [Theory]
    [MemberData(nameof(CheckCases), 3)]
    public void Check_Is_Complete(
        GuessResult guessResult,
        bool expected
    )
    {
        var actual = guessResult.IsCompleted();
        
        Assert.Equal(actual, expected);
    }
    
    public static IEnumerable<object[]> CheckCases =>
        new List<object[]>
        {
            new object[] {new GuessResult {BallCount = 0, StrikeCount = 3}, true},
            new object[] {new GuessResult {BallCount = 1, StrikeCount = 1}, false},
            new object[] {new GuessResult {BallCount = 2, StrikeCount = 1}, false},
            new object[] {new GuessResult {BallCount = 0, StrikeCount = 2}, false},
            new object[] {new GuessResult {BallCount = 3, StrikeCount = 0}, false},
            new object[] {new GuessResult {BallCount = 0, StrikeCount = 0}, false},
        };
}
