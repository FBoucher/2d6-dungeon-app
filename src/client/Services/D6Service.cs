using System.Net.Http.Json;
using System.Text.Json;

namespace c5m._2d6Dungeon;

public class D6Service : ID6Service
{
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public D6Service(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }

    public async Task<Adventurer> GetAdventurer(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<AdventurerPreviewList>($"adventurer/id/{id.ToString()}");
        var adventurerPrev = result.value.First<AdventurerPreview>();
            
        return new Adventurer(adventurerPrev);    
    }

    public async Task<AdventurerPreviewList?> GetAdventurerPreviews()
    {
        return await _httpClient.GetFromJsonAsync<AdventurerPreviewList?>("adventurer?$select=id,name,xp,level");
    }
}
