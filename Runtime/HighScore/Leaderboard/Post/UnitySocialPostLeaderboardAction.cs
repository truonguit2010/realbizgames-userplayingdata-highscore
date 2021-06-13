

namespace RealbizGames.HighScore
{
    public class UnitySocialPostLeaderboardAction : IPostLeaderboardAction
    {
        public const string TAG = "UnitySocialPostLeaderboardAction";
        
        public void Post(string leaderboardId, long score)
        {
#if USING_HIGHSCORE_UNITY_SOCIAL
            UnityEngine.Social.ReportScore(score, leaderboardId, success => {
                Debug.LogFormat("{0} - Post score {1} to leaderboard {2} success = {3}", TAG, score, leaderboardId, success);
            });
#endif
        }
    }
}