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

    public async Task<bool> SaveAdventurer(Adventurer player)
    {
        var dbPlayer = new AdventurerPreview(player);

        var response = await _httpClient.PutAsJsonAsync<AdventurerPreview>($"adventurer/id/{player.Id.ToString()}", dbPlayer);
        var status = response.EnsureSuccessStatusCode();

        if(status.IsSuccessStatusCode)
            return true;
        return false;
    }

    private List<int> RollDices(int diceCount)
    {
        var die = new List<int> { 1,2,3,4,5,6 };
        var shuffled = die.OrderBy(x => Guid.NewGuid()).Take(diceCount).ToList<int>(); 
        return shuffled;
    }
    public List<int> Roll2Dices()
    {
        return RollDices(2);
    }

    public int Roll1Dice()
    {
        return RollDices(1).First();
    }
}
