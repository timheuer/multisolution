using System.Net.Http.Json;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using weatherapi;

public class WeatherTests
{
    [Fact]
    public async Task GetForecast()
    {
        await using var application = new WeatherApplication();

        var client = application.CreateClient();
        var temps = await client.GetFromJsonAsync<List<WeatherForecast>>("/weatherforecast");

        Assert.NotEmpty(temps);
    }
}

class WeatherApplication : WebApplicationFactory<weatherapi.Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }
}