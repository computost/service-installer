using DotNet.Testcontainers.Builders;
using DotNet.Testcontainers.Containers;

namespace ServiceInstaller.Tests;

public class Tests
{
    private IContainer _container;

    [SetUp]
    public void Setup()
    {
        _container = new ContainerBuilder()
            // Set the image for the container to "testcontainers/helloworld:1.1.0".
            .WithImage("mcr.microsoft.com/windows/servercore/iis:windowsservercore-ltsc2016")
            // Bind port 8080 of the container to a random port on the host.
            //.WithPortBinding(8080, true)
            // Wait until the HTTP endpoint of the container is available.
            //.WithWaitStrategy(Wait.ForUnixContainer().UntilHttpRequestIsSucceeded(r => r.ForPort(8080)))
            // Build the container configuration.
            .Build();
    }

    [TearDown]
    public async Task TearDown()
    {
        await _container.DisposeAsync();
    }

    [Test]
    public void Test1()
    {
        Assert.Pass();
    }
}