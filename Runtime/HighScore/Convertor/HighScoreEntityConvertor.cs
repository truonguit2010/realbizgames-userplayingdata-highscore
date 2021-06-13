
public class HighScoreEntityConvertor
{
    public static HighScoreEntity From(HighScoreDTO dto) {
        HighScoreEntity entity = new HighScoreEntity();

        entity.highScore = dto.HighScore;
        entity.name = dto.LeaderboardName;

        return entity;
    }
}
