namespace Atata.MSTest.IntegrationTests;

[TestClass]
public static class GlobalFixture
{
    [AssemblyInitialize]
    public static void SetUpAssembly(TestContext testContext)
    {
        AtataContext.BaseConfiguration.LogConsumers.AddNLogFile();

        MSTestGlobalAtataContextSetup.SetUp(typeof(GlobalFixture), testContext);
    }

    [AssemblyCleanup]
    public static void TearDownAssembly(TestContext testContext) =>
        MSTestGlobalAtataContextSetup.TearDown(testContext);
}
