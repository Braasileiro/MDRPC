using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.InteropServices;
using MDRPC;
using MelonLoader;
using BuildInfo = MDRPC.BuildInfo;

// Info
[assembly: AssemblyTitle(BuildInfo.Description)]
[assembly: AssemblyDescription(BuildInfo.Description)]
[assembly: AssemblyCompany(BuildInfo.Company)]
[assembly: AssemblyProduct(BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + BuildInfo.Author)]
[assembly: AssemblyTrademark(BuildInfo.Company)]

// GUID
[assembly: Guid("c3121db3-33ae-4cc2-a3a4-740d945bd33c")]

// Version
[assembly: AssemblyVersion(BuildInfo.Version)]
[assembly: AssemblyFileVersion(BuildInfo.Version)]

// MelonMod
[assembly: MelonInfo(typeof(Mod), BuildInfo.Name, BuildInfo.Version, BuildInfo.Author, BuildInfo.DownloadLink)]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]

// Suppress
[assembly:
    SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>",
        Scope = "namespaceanddescendants", Target = "~N:MDRPC.Patches")]
[assembly:
    SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>",
        Scope = "namespaceanddescendants", Target = "~N:MDRPC.Patches")]