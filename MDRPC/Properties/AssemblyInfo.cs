using MelonLoader;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Diagnostics.CodeAnalysis;

// Info
[assembly: AssemblyTitle(MDRPC.BuildInfo.Description)]
[assembly: AssemblyDescription(MDRPC.BuildInfo.Description)]
[assembly: AssemblyCompany(MDRPC.BuildInfo.Company)]
[assembly: AssemblyProduct(MDRPC.BuildInfo.Name)]
[assembly: AssemblyCopyright("Created by " + MDRPC.BuildInfo.Author)]
[assembly: AssemblyTrademark(MDRPC.BuildInfo.Company)]

// GUID
[assembly: Guid("c3121db3-33ae-4cc2-a3a4-740d945bd33c")]

// Version
[assembly: AssemblyVersion(MDRPC.BuildInfo.Version)]
[assembly: AssemblyFileVersion(MDRPC.BuildInfo.Version)]

// MelonMod
[assembly: MelonInfo(typeof(MDRPC.Main), MDRPC.BuildInfo.Name, MDRPC.BuildInfo.Version, MDRPC.BuildInfo.Author, MDRPC.BuildInfo.DownloadLink)]
[assembly: MelonGame("PeroPeroGames", "MuseDash")]

// Suppress
[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:MDRPC.Patches")]
[assembly: SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "<Pending>", Scope = "namespaceanddescendants", Target = "~N:MDRPC.Patches")]
