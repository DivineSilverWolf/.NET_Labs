namespace Lab6_Gods;

public static class ReadyPlayerControl
{
    internal static int CountReady { get; set; }
    internal static readonly object LockObject = new object();
}