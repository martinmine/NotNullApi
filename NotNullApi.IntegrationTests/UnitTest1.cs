using Microsoft.AspNetCore.Mvc.Testing;
using NotNullApi.Controllers;
using System.Net;
using System.Net.Http.Json;

namespace NotNullApi.IntegrationTests;

public class Tests
{
    private readonly WebApplicationFactory<Program> _factory = new();

    [Test]
    public async Task CanCallEndpoint()
    {
        using var client = _factory.CreateClient();
        var requestObj = new RequestDtoObject
        {
            Names = ["foo"],
            Name = "asd"
        };

        var response = await client.PostAsJsonAsync("echo", requestObj);
        var responseBody = await response.Content.ReadFromJsonAsync<RequestDtoObject>();

        Assert.IsNotNull(responseBody);
        CollectionAssert.Contains(responseBody.Names, "foo");
    }

    [Test]
    public async Task CannotCallEndpointWithNullInList()
    {
        using var client = _factory.CreateClient();
        var requestObj = new RequestDtoObject
        {
            Names = ["foo", null!],
            Name = "asd"
        };

        var response = await client.PostAsJsonAsync("echo", requestObj);

        Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.BadRequest));
    }
}