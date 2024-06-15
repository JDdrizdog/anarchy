using System;
using System.Management;
using System.Text.RegularExpressions;

namespace Anarchy.Helpers;

public static class PlatformHelper
{
    public static string FullName { get; }

    public static string Name { get; }

    public static bool Is64Bit { get; }

    public static bool RunningOnMono { get; }

    public static bool Win32NT { get; }

    public static bool XpOrHigher { get; }

    public static bool VistaOrHigher { get; }

    public static bool SevenOrHigher { get; }

    public static bool EightOrHigher { get; }

    public static bool EightPointOneOrHigher { get; }

    public static bool TenOrHigher { get; }

    static PlatformHelper()
    {
        PlatformHelper.Win32NT = Environment.OSVersion.Platform == PlatformID.Win32NT;
        PlatformHelper.XpOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 5;
        PlatformHelper.VistaOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version.Major >= 6;
        PlatformHelper.SevenOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 1);
        PlatformHelper.EightOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 2, 9200);
        PlatformHelper.EightPointOneOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(6, 3);
        PlatformHelper.TenOrHigher = PlatformHelper.Win32NT && Environment.OSVersion.Version >= new Version(10, 0);
        PlatformHelper.RunningOnMono = Type.GetType("Mono.Runtime") != null;
        PlatformHelper.Name = "Unknown OS";
        using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT Caption FROM Win32_OperatingSystem"))
        {
            using ManagementObjectCollection.ManagementObjectEnumerator managementObjectEnumerator = managementObjectSearcher.Get().GetEnumerator();
            if (managementObjectEnumerator.MoveNext())
            {
                PlatformHelper.Name = managementObjectEnumerator.Current["Caption"].ToString();
            }
        }
        PlatformHelper.Name = Regex.Replace(PlatformHelper.Name, "^.*(?=Windows)", "").TrimEnd().TrimStart();
        PlatformHelper.Is64Bit = Environment.Is64BitOperatingSystem;
        PlatformHelper.FullName = $"{PlatformHelper.Name} {(PlatformHelper.Is64Bit ? 64 : 32)} Bit";
    }
}