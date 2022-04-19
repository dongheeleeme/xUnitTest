namespace BaseballGame;

public class InputNumberTextValidator
{
    public bool validate(string numberText)
    {
        var numbers = numberText.ToList();
        return numbers.ToHashSet().Count() == 3 && numbers.All(char.IsNumber);
    }
}