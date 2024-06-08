using Nuke.Common;
using Nuke.Common.IO;
using Nuke.Common.Tooling;
using ReactiveUI.Web;
using Nuke.Common.Tools.MSBuild;
using System.IO;
using System;

class Build : NukeBuild
{
    public static int Main() => Execute<Build>(x => x.CreateContent);

    [Parameter("Configuration to build - Default is 'Debug' (local) or 'Release' (server)")]
    readonly Configuration Configuration = IsLocalBuild ? Configuration.Debug : Configuration.Release;

    private static readonly string DynamicData = nameof(DynamicData);
    private static readonly string reactivemarbles = nameof(reactivemarbles);
    private static readonly string external = nameof(external);

    private AbsolutePath ContentDirectory => RootDirectory / DynamicData;
    private AbsolutePath RxMAPIDirectory => ContentDirectory / "api" / reactivemarbles;
    private AbsolutePath SiteDirectory => ContentDirectory / "_site";
    private AbsolutePath DDSourceDirectory => RxMAPIDirectory / external / DynamicData / "DynamicData-main";

    Target Clean => _ => _
        .Before(Restore)
        .Executes(() =>
        {
            RxMAPIDirectory.DeleteDirectory();
            SiteDirectory.DeleteDirectory();
            // Install docfx
            ProcessTasks.StartShell("dotnet tool update -g docfx").AssertZeroExitCode();
        });

    Target Restore => _ => _
        .DependsOn(Clean)
        .Executes(() =>
        {
            // Restore Reactive Marbles Projects
            RxMAPIDirectory.GetSources(RootDirectory, reactivemarbles, DynamicData);
        });

    Target Compile => _ => _
        .DependsOn(Restore)
        .Executes(() =>
        {
            try
            {
                var dirDd = RxMAPIDirectory / "external" / DynamicData / $"{DynamicData}-main" / "src";
                File.Copy(RootDirectory / "global.json", dirDd / "global.json", true);
                MSBuildTasks.MSBuild(s => s
                    .SetProjectFile(dirDd / $"{DynamicData}.sln")
                    .SetConfiguration(Configuration)
                    .SetRestore(true));
                SourceFetcher.LogInfo($"{DynamicData} build complete");
            }
            catch (Exception ex)
            {
                SourceFetcher.LogRepositoryError(reactivemarbles, DynamicData, ex.ToString());
            }
        });

    Target CreateContent => _ => _
        .DependsOn(Compile)
        .Executes(() =>
        {
            // TODO: Extract the source code from the DynamicData repository and create md files from the source code where necessary
            var dirDd = DDSourceDirectory;

            // A simple example of extracting the source code from the DynamicData repository and placing it in a content directory
            var readme = dirDd / "Readme.md";
            File.Copy(readme, ContentDirectory / "docs" / "roadmap" / "index.md", true);

            // This is the directory where the source code is located
            var dirDdSrc = dirDd / "src";
            SourceFetcher.LogInfo("Extraction complete");
        });

    Target BuildWebsite => _ => _
    .Produces(SiteDirectory)
    .Executes(() =>
    {
        try
        {
            ProcessTasks.StartShell("docfx DynamicData/docfx.json").AssertZeroExitCode();
            SourceFetcher.LogInfo("Web Site build complete");
        }
        catch (Exception ex)
        {
            SourceFetcher.LogError(ex.ToString());
        }
    });
}
