using System.Net.Http.Json;
using System.Text.Json;

namespace c5m._2d6Dungeon;

public class D6Service : ID6Service
{

#region == Sercice =====
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public D6Service(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    }
#endregion

#region == Adventurer =====
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

#endregion

#region == Dices =====

    

    #endregion


    #region == Turn =====

    private int DungeonLevel = 1;
    private int DungeonRoomCount = 1;

    public async Task StartNextTurn()
    {
        if(DungeonRoomCount < 1){
            throw new NotImplementedException();
        }
        else{
            DiceResult result = DiceResult.Roll2Dices();

        }
    }

    #endregion

}
