﻿using System.Net.Http.Json;
using System.Text.Json;
using DeserializeAsyncApp.Models;

namespace DeserializeAsyncApp.Classes;

internal class JsonHelpers
{
    public static async Task<T> FromStreamAsync<T>(string filePath)
    {
        await using FileStream stream = File.OpenRead(filePath);
        return await JsonSerializer.DeserializeAsync<T>(stream);
    }
    public static async Task<List<T>> ReadJson1Async<T>(string filePath)
        => await FromStreamAsync<List<T>>(filePath);

    public static async Task<List<T>> ReadJsonWithTimeOutAsync<T>(string url, double timeOut = 2)
    {
        using HttpClient httpClient = new() { Timeout = TimeSpan.FromSeconds(timeOut) };
        return JsonSerializer.Deserialize<List<T>>(await httpClient.GetStringAsync(url));
    }
    public static async Task<List<T>> ReadJsonAsync<T>(string url, CancellationToken cancellationToken = default)
    {
        using HttpClient client = new();
        return await client.GetFromJsonAsync<List<T>>(new Uri(url), Options, cancellationToken);
    }
    public static async Task<T> ReadJson_Async<T>(string url, CancellationToken cancellationToken = default) where T : IBaseEntity
    {
        using HttpClient client = new();
        var customers = await client.GetFromJsonAsync<List<T>>(new Uri(url), Options, cancellationToken);
        return customers.FirstOrDefault(x => x.Id == 1);
    }

    private static readonly JsonSerializerOptions Options = new(JsonSerializerDefaults.Web);
    
}





