using UnityEngine;

[System.Serializable]
public class HighScoreDTO
{
    [SerializeField]
    private int _highScore;

    [SerializeField]
    private string _leaderboardName;

    public int HighScore { get => _highScore; set => _highScore = value; }
    public string LeaderboardName { get => _leaderboardName; set => _leaderboardName = value; }

    public override string ToString()
    {
        return ToStringUtils.ToStringFor(this);
    }
}
