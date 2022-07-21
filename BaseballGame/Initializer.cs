namespace BaseballGame;

public class Initializer
{
    private readonly int[] _targetNumbers;
    private readonly InputNumberTextValidator _inputNumberTextValidator;

    public Initializer(
        IRandomNumberListGenerator randomNumberListGenerator,
        InputNumberTextValidator inputNumberTextValidator
    )
    {
        _inputNumberTextValidator = inputNumberTextValidator;
        _targetNumbers = randomNumberListGenerator.Generate(3);
    }

    public GuessResult Check(string numberText)
    {
        if (!_inputNumberTextValidator.validate(numberText))
        {
            throw new BaseballGameException("Failed to validate number text");
        }

        return GuessNumberTextChecker(_targetNumbers, numberText);
    }

    private GuessResult GuessNumberTextChecker(int[] targetNumbers, string numberText)
    {
        var ballCount = 0;
        var strikeCount = 0;

        for (var i = 0; i < numberText.Length; i++)
        {
            var num = int.Parse(numberText[i].ToString());

            for (var j = 0; j < targetNumbers.Length; j++)
            {
                if (targetNumbers[j].Equals(num))
                {
                    if (i.Equals(j)) strikeCount++;
                    else ballCount++;

                    break;
                }
            }
        }

        return new GuessResult
        {
            BallCount = ballCount,
            StrikeCount = strikeCount,
        };
    }
}