
public class HighScorePlayerPrefRepository : GenericPlayerPrefDictionaryRepository<HighScoreEntity>
{
    public const string KEY_IN_PLAYER_PREF = "HighScoreTable";

    public HighScorePlayerPrefRepository() : base(KEY_IN_PLAYER_PREF) {

    }
}
