using System.Reflection;
using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace ServiceInstaller.Tests;

public class Tests
{
    private IContainer _container;

    [SetUp]
    public async Task Setup()
    {
        _container = new ContainerBuilder()
            .WithImage("mcr.microsoft.com/windows/servercore/iis:windowsservercore-ltsc2016")
            .WithResourceMapping(new FileInfo("Service Installer.msi"), ".")
            // Bind port 8080 of the container to a random port on the host.
            //.WithPortBinding(8080, true)
            // Wait until the HTTP endpoint of the container is available.
            //.WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(8080)))
            // Build the container configuration.
            .Build();
        await _container.StartAsync();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _container.DisposeAsync();
    }

    [Test]
    public async Task InstallService()
    {
        var result = await _container.ExecAsync(new[] { "msiexec", "/i", "Service Installer.msi", "/quiet" });
    }
}