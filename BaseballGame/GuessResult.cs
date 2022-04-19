namespace BaseballGame;

public struct GuessResult
{
    public int BallCount { get; set; }
    public int StrikeCount { get; set; }

    public bool IsCompleted()
    {
        return StrikeCount == 3 && BallCount == 0;
    }
}