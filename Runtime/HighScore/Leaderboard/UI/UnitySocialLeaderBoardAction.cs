
namespace RealbizGames.HighScore
{
    public class UnitySocialLeaderBoardAction : ILeaderBoardUIAction
    {
        public void open(string leadlerboardId)
        {

#if USING_HIGHSCORE_UNITY_SOCIAL
#if UNITY_IOS
            UnityEngine.SocialPlatforms.GameCenter.GameCenterPlatform.ShowLeaderboardUI(leaderboardId, UnityEngine.SocialPlatforms.TimeScope.AllTime);
#else
            UnityEngine.Social.ShowLeaderboardUI();
#endif
#endif
        }
    }
}