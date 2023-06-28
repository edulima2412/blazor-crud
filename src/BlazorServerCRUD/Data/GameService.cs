using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data
{
    public class GameService : IGameService
    {
        private readonly DataContext _context;
        private readonly NavigationManager _navigationManager;

        public GameService(DataContext context, NavigationManager navigationManager)
        {
            _context = context;
            _navigationManager = navigationManager;
            _context.Database.EnsureCreated();
        }

        public List<Game> Games { get; set; } = new List<Game>();

        public async Task CreateGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/");
        }

        public async Task DeleteGameAsync(int id)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame == null)
                throw new Exception("No game here.");

            _context.Games.Remove(dbGame);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/");
        }

        public async Task<Game> GetSingleGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
                throw new Exception("No game here.");

            return game;
        }

        public async Task LoadGamesAsync()
        {
            Games = await _context.Games.ToListAsync();
        }

        public async Task UpdateGameAsync(int id, Game game)
        {
            var dbGame = await _context.Games.FindAsync(id);
            if (dbGame == null)
                throw new Exception("No game here.");

            dbGame.Name = game.Name;
            dbGame.Developer = game.Developer;
            dbGame.Release = game.Release;

            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("/");
        }
    }
}
