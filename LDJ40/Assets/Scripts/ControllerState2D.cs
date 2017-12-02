public struct ControllerState2D
{
    public bool IsCollidingRight { get; set; }
    public bool IsCollidingLeft { get; set; }
    public bool IsCollidingAbove { get; set; }
    public bool IsCollidingBelow { get; set; }

    public void Reset()
    {
        IsCollidingLeft =
        IsCollidingRight =
        IsCollidingAbove =
        IsCollidingBelow = false;
    }
}
