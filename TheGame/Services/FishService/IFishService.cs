namespace Game.Services;

public interface IFishService
{
    public List<Dictionary<string, string>> ReadFishFromCsv();
}
