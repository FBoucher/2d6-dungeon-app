using System.Net.Http.Json;
using System.Text.Json;
using c5m._2d6Dungeon;
using c5m._2d6Dungeon.Game;

namespace c5m._2d6Dungeon;

public class D6Service : ID6Service
{

    #region == Sercice =====
    private readonly HttpClient _httpClient;
    private readonly JsonSerializerOptions _options;
    public D6Service(HttpClient httpClient)
    {
        _options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        _httpClient = httpClient;
 
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

    public async Task<bool> AdventurerCreate(Adventurer player)
    {
        var dbPlayer = new AdventurerPreview(player);

        var response = await _httpClient.PostAsJsonAsync<AdventurerPreview>($"adventurer", dbPlayer);
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


    #region == WeaponManoeuvre =====

    public async Task<WeaponList> GetWeapons()
    {
        var result = await _httpClient.GetFromJsonAsync<WeaponList>("weapon", _options);
        // var weapons = result.value.GroupBy(w => new {w.weapon})
        //                 .Select(w => w.First().weapon)
        //                 .ToList();
        // return weapons;
        return result ?? new WeaponList();
    }


    public async Task<WeaponManoeuvreList?> GetWeaponManoeuvreList(int weaponId, int level)
    {
        var q = $"weapon_manoeuvre?$filter=level eq {level} and weapon_id eq {weaponId}";
        return await _httpClient.GetFromJsonAsync<WeaponManoeuvreList>(q, _options);
    }

    #endregion



    #region == ArmourPiece =====

    public async Task<ArmourPieceList> GetArmourPieces()
    {
        var result = await _httpClient.GetFromJsonAsync<ArmourPieceList>("armour_piece", _options);
        return result ?? new ArmourPieceList();
    }

    #endregion


    #region == MagicScroll =====

    public async Task<MagicScrollList> GetMagicScrolls()
    {
        var result = await _httpClient.GetFromJsonAsync<MagicScrollList>("magic_scroll", _options);
        return result ?? new MagicScrollList();
    }

    #endregion


    #region == MagicPotion =====


    public async Task<MagicPotion> GetInitialMagicPotion()
    {
        var q = $"magic_potion?$filter=potion_type eq 'HEALING'";
        var result = await _httpClient.GetFromJsonAsync<MagicPotionlList>(q);
        return result.value.First<MagicPotion>();
    }

    #endregion
}
