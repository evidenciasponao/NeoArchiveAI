using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using Microsoft.Extensions.Options;
using NeoArchiveAI.Infrastructure.AI.Models.OpenAI;
using NeoArchiveAI.Infrastructure.Configuration;

namespace NeoArchiveAI.Infrastructure.AI.Clients;

public sealed class OpenAiClient : IOpenAiClient
{
    private readonly HttpClient _httpClient;
    private readonly AiOptions _options;

    public OpenAiClient(
        HttpClient httpClient,
        IOptions<AiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;

        _httpClient.BaseAddress = new Uri(_options.BaseUrl);

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", _options.ApiKey);

        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<ChatResponse> SendAsync(
        ChatRequest request,
        CancellationToken cancellationToken = default)
    {
        using var response = await _httpClient.PostAsJsonAsync(
            "chat/completions",
            request,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync(cancellationToken);

            throw new HttpRequestException(
                $"OpenAI request failed ({(int)response.StatusCode} - {response.ReasonPhrase}){Environment.NewLine}{error}");
        }

        var result =
            await response.Content.ReadFromJsonAsync<ChatResponse>(
                cancellationToken: cancellationToken);

        return result
            ?? throw new InvalidOperationException(
                "OpenAI returned an empty response.");
    }
}
