using BaseballGame;

var baseballGame = new BaseballGame.Initializer(new RandomNumberListGenerator(), new InputNumberTextValidator());

Console.WriteLine("Please input 3 digit number");

var isCompleted = false;
while (!isCompleted)
{
    var numberText = Console.ReadLine();
    if (numberText == null) continue;

    var checkResult = baseballGame.Check(numberText);
    Console.WriteLine($"{checkResult.StrikeCount} strike / {checkResult.BallCount} ball");
    isCompleted = checkResult.IsCompleted();
}
