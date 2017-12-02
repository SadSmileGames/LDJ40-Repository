public struct ControllerState2D
{
    public bool IsCollidingRight { get; set; }
    public bool IsCollidingLeft { get; set; }
    public bool IsCollidingAbove { get; set; }
    public bool IsCollidingBelow { get; set; }
    public bool IsColliding
    {
        get
        {
            return IsCollidingLeft || IsCollidingRight || IsCollidingBelow || IsCollidingAbove;
        }
    }

    public void Reset()
    {
        IsCollidingLeft =
        IsCollidingRight =
        IsCollidingAbove =
        IsCollidingBelow = false;
    }
}
