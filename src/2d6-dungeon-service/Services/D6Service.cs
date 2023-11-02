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

    #region == Adventure =====

    public async Task<int> GetSaveGameCount()
    {
        //todo: implement a save game in the database. 
        return await Task.FromResult<int>(1);
    }

    public async Task<AdventurePreviewList?> GetAdventurePreviews()
    {
        return await _httpClient.GetFromJsonAsync<AdventurePreviewList?>("adventure?$select=id,adventurer_name,level,last_saved_datetime");
    }

    public async Task<Adventure> GetAdventure(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<AdventurePreviewList>($"adventure/id/{id.ToString()}");
        var adventurePrev = result.value.First<AdventurePreview>();

        return new Adventure(adventurePrev);
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

        if (status.IsSuccessStatusCode)
            return true;
        return false;
    }

    #endregion


    #region == Adventurer Options =====

    //public async Task<List<Weapon>> GetWeapons(){}


    #endregion


    #region == Rooms =====

    public async Task<Room> GetRoom(int id)
    {
        var result = await _httpClient.GetFromJsonAsync<RoomList>($"room/id/{id.ToString()}");
        var room = result.value.First<Room>();

        return room;
    }

    public async Task<Room> RollRoom(int roll, string size)
    {
        // ex: http://localhost:5000/api/room/?$filter=roll eq 2 and size eq 'small'
        var result = await _httpClient.GetFromJsonAsync<RoomList>($"room/?$filter=roll eq {roll.ToString()} and size eq '{size}'");
        var room = result.value.First<Room>();

        return room;
    }

    #endregion

}
