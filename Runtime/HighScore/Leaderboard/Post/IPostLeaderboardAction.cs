
namespace RealbizGames.HighScore
{
    public interface IPostLeaderboardAction
    {
        void Post(string leaderboardId, long score);
    }

}
