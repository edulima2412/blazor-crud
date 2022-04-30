namespace BlazorServerCRUD.Data
{
    public interface IGameService
    {
        List<Game> Games { get; set; }
        Task LoadGamesAsync();
        Task<Game> GetSingleGameAsync(int id);
        Task CreateGameAsync(Game game);
        Task UpdateGameAsync(int id, Game game);
        Task DeleteGameAsync(int id);
    }
}
