using Xunit;

namespace BaseballGame.UnitTest;

public class InputNumberTextValidatorTest
{
    [Theory]
    [InlineData("123")]
    public void Validate_Valid_Input_Number_Text(
        string numberText
    )
    {
        var validator = new InputNumberTextValidator();
        var actual = validator.validate(numberText);

        Assert.True(actual);
    }

    [Theory]
    [InlineData("12")]
    [InlineData("1234")]
    [InlineData("112")]
    [InlineData("1a3")]
    public void Validate_Invalid_Input_Number_Text(
        string numberText
    )
    {
        var validator = new InputNumberTextValidator();
        var actual = validator.validate(numberText);

        Assert.False(actual);
    }
}