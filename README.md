# Atata.MSTest

[![Atata Templates](https://img.shields.io/badge/get-Atata_Templates-green.svg?color=4BC21F)](https://marketplace.visualstudio.com/items?itemName=YevgeniyShunevych.AtataTemplates)\
[![Slack](https://img.shields.io/badge/join-Slack-green.svg?colorB=4EB898)](https://join.slack.com/t/atata-framework/shared_invite/zt-5j3lyln7-WD1ZtMDzXBhPm0yXLDBzbA)
[![Atata docs](https://img.shields.io/badge/docs-Atata_Framework-orange.svg)](https://atata.io)
[![X](https://img.shields.io/badge/follow-@AtataFramework-blue.svg)](https://x.com/AtataFramework)

**Atata.MSTest** is a C#/.NET library that integrates [Atata](https://github.com/atata-framework/atata) with MSTest.

*The package targets .NET 8.0 and .NET Framework 4.6.2.*

## Features

Atata.MSTest provides seamless integration between Atata Framework and MSTest testing framework, offering:

- **Test suite and fixture base classes**. `AtataTestSuite`, `MSTestGlobalAtataContextSetup` for different testing scopes`.
- **MSTest-aware context configuration**. Automatic integration of MSTest test names, suite names, categories, and properties.
- **Logging**. Integration with MSTest's test output for Atata logs.
- **Error handling**. Built-in Atata error handling (screenshots, page snapshots, etc.) on test failures and attaching artifacts to test results.
- **Parallel test support**. Full support for MSTest's parallel execution capabilities.

## Installation

Install the package via .NET CLI:

```bash
dotnet add package Atata.MSTest
```

Or using Package Manager:

```powershell
Install-Package Atata.MSTest
```

## Usage

### Global fixture

For global setup across all test suites, create a static class in a project root like below, which calls methods of `MSTestGlobalAtataContextSetup`:

```cs
[TestClass]
public static class GlobalFixture
{
    [AssemblyInitialize]
    public static void SetUpAssembly(TestContext testContext)
    {
        ConfigureAtataContextBaseConfiguration(AtataContext.BaseConfiguration);

        MSTestGlobalAtataContextSetup.SetUp(typeof(GlobalFixture), testContext, ConfigureGlobalAtataContext);
    }

    [AssemblyCleanup]
    public static void TearDownAssembly(TestContext testContext) =>
        MSTestGlobalAtataContextSetup.TearDown(testContext);

    private static void ConfigureAtataContextBaseConfiguration(AtataContextBuilder builder)
    {
        // Configure base AtataContext configuration
    }

    private static void ConfigureGlobalAtataContext(AtataContextBuilder builder)
    {
        // Configure global AtataContext
    }
}
```

### Test suite class

Create a test class that inherits from `AtataTestSuite`:

```cs
[TestClass]
public sealed class SampleTests : AtataTestSuite
{
    [TestMethod]
    public void SampleTest()
    {
        // Test method implementation
    }

    [ConfiguresSuiteAtataContext]
    public static void ConfigureSuiteAtataContext(AtataContextBuilder builder)
    {
        // Optional test suite-specific configuration
    }

    protected override void ConfigureTestAtataContext(AtataContextBuilder builder)
    {
        // Optional test method-specific configuration
    }
}
```

Please notice and follow the signature of `ConfigureSuiteAtataContext` method,
which can have different name, but should be static, have `AtataContextBuilder` parameter,
and be marked with `[ConfiguresSuiteAtataContext]` attribute.

## Examples

Check out example project: [Atata Samples / Using MSTest](https://github.com/atata-framework/atata-samples/tree/main/MSTest)

## Community

- Slack: [https://atata-framework.slack.com](https://join.slack.com/t/atata-framework/shared_invite/zt-5j3lyln7-WD1ZtMDzXBhPm0yXLDBzbA)
- X: https://x.com/AtataFramework
- Stack Overflow: https://stackoverflow.com/questions/tagged/atata

## Feedback

Any feedback, issues and feature requests are welcome.

If you faced an issue please report it to [Atata.MSTest Issues](https://github.com/atata-framework/atata-mstest/issues),
[ask a question on Stack Overflow](https://stackoverflow.com/questions/ask?tags=atata+csharp) using [atata](https://stackoverflow.com/questions/tagged/atata) tag
or use another [Atata Contact](https://atata.io/contact/) way.

## Contact author

Contact me if you need a help in test automation using Atata Framework, or if you are looking for a quality test automation implementation for your project.

- LinkedIn: https://www.linkedin.com/in/yevgeniy-shunevych
- Email: yevgeniy.shunevych@gmail.com
- Consulting: https://atata.io/consulting/

## Contributing

Check out [Contributing Guidelines](CONTRIBUTING.md) for details.

## SemVer

Atata Framework follows [Semantic Versioning 2.0](https://semver.org/).
Thus backward compatibility is followed and updates within the same major version
(e.g. from 2.1 to 2.2) should not require code changes.

## License

Atata is an open source software, licensed under the Apache License 2.0.
See [LICENSE](LICENSE) for details.
