namespace Atata.MSTest;

/// <summary>
/// Handles the addition of artifact files to the MSTest <see cref="TestContext"/>
/// upon the completion of <see cref="AtataContext"/> deinitialization.
/// </summary>
public sealed class AddArtifactsToMSTestContextEventHandler : ProcessFilesOnAtataContextDeInitCompletedEventHandlerBase
{
    private readonly TestContext _testContext;

    public AddArtifactsToMSTestContextEventHandler(TestContext testContext)
    {
        Guard.ThrowIfNull(testContext);

        _testContext = testContext;
    }

    protected override string GetDirectoryPath(AtataContext context) =>
        context.ArtifactsPath;

    protected override void Process(FileInfo file) =>
        _testContext.AddResultFile(file.FullName);
}
