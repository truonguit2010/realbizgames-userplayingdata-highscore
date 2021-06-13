using System.Collections.Generic;
using UnityEngine;

public interface IHighScoreService : IService
{
    int Get();

    void Set(int highScore);

    void Set(HighScoreDTO dto);

    HighScoreDTO Get(string leaderboardName);

    List<HighScoreDTO> GetAll();

    void ShowLeaderBoardUI(string leaderboardName);

    void SetCustomShowLeaderboardUI(RealbizGames.HighScore.ILeaderBoardUIAction action);

    void AddCustomPostScoreAction(RealbizGames.HighScore.IPostLeaderboardAction action);
}
