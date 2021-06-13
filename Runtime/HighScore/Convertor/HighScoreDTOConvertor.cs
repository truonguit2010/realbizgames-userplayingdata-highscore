using System.Collections.Generic;

public class HighScoreDTOConvertor
{
    public static HighScoreDTO From(HighScoreEntity entity) {
        HighScoreDTO dto = new HighScoreDTO();

        dto.HighScore = entity.highScore;
        dto.LeaderboardName = entity.name;

        return dto;
    }

    public static List<HighScoreDTO> From(List<HighScoreEntity> entities) {
        List<HighScoreDTO> dtos = new List<HighScoreDTO>();
        
        foreach(HighScoreEntity entity in entities) {
            dtos.Add(From(entity));
        }

        return dtos;
    }
}
