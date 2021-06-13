using System.Collections.Generic;
using RealbizGames.HighScore;

public class HighScoreServiceImpl : IHighScoreService
{
    public const string TAG = "HighScoreServiceImpl";

    public const string DEFAULT_GLOBAL_LEADERBOARD_NAME = "TopPlayers";
    
    private static readonly HighScorePlayerPrefRepository repository = new HighScorePlayerPrefRepository();
    private IPlayerPrefDictionaryRepository<HighScoreEntity> _playerPrefRepository = repository;

    private List<RealbizGames.HighScore.IPostLeaderboardAction> postActions;

    private RealbizGames.HighScore.ILeaderBoardUIAction showLeaderboardAction;

    public HighScoreServiceImpl() {
        postActions = new List<RealbizGames.HighScore.IPostLeaderboardAction>();
        postActions.Add(new RealbizGames.HighScore.UnitySocialPostLeaderboardAction());

        showLeaderboardAction = new RealbizGames.HighScore.UnitySocialLeaderBoardAction();
    }

    public void AddCustomPostScoreAction(IPostLeaderboardAction action)
    {
        postActions.Add(action);
    }

    public int Get()
    {
        HighScoreEntity entity = repository.Get(DEFAULT_GLOBAL_LEADERBOARD_NAME);
        if (entity == null) {
            return 0;
        } else {
            return entity.highScore;
        }
    }

    public HighScoreDTO Get(string leaderboardName)
    {
        HighScoreEntity entity = repository.Get(leaderboardName);
        if (entity == null) {
            HighScoreDTO dto = new HighScoreDTO();
            dto.LeaderboardName = leaderboardName;
            dto.HighScore = 0;
            return dto;
        } else {
            HighScoreDTO dto = HighScoreDTOConvertor.From(entity);
            return dto;
        }
    }

    public List<HighScoreDTO> GetAll()
    {
        List<HighScoreEntity> entities = repository.GetAll();
        List<HighScoreDTO> dtos = HighScoreDTOConvertor.From(entities: entities);
        return dtos;
    }

    public void init()
    {
        repository.init();
    }

    public void lazyInit()
    {
        repository.lazyInit();
    }

    public void refresh()
    {
        repository.refresh();
    }

    public void Set(int highScore)
    {
        HighScoreDTO dto = new HighScoreDTO();
        dto.HighScore = highScore;
        dto.LeaderboardName = DEFAULT_GLOBAL_LEADERBOARD_NAME;
        Set(dto);
    }

    public void Set(HighScoreDTO dto)
    {
        HighScoreEntity oldOne = repository.Get(dto.LeaderboardName);

        HighScoreEntity entity = HighScoreEntityConvertor.From(dto);

        if (oldOne == null || oldOne.highScore < entity.highScore) {
            #if UNITY_EDITOR
            UnityEngine.Debug.LogFormat("{0} - Save high score: {1}", TAG, dto);
            #endif
            repository.Save(entity.name, entity);
        } else {
            #if UNITY_EDITOR
            UnityEngine.Debug.LogFormat("{0} - Ignore lower score ", TAG);
            #endif
        }

        foreach (RealbizGames.HighScore.IPostLeaderboardAction action in postActions) {
            action.Post(dto.LeaderboardName, dto.HighScore);
        }
    }

    public void SetCustomShowLeaderboardUI(ILeaderBoardUIAction action)
    {
        showLeaderboardAction = action;
    }

    public void ShowLeaderBoardUI(string leaderboardName)
    {
        if (showLeaderboardAction != null) {
            showLeaderboardAction.open(leadlerboardId: leaderboardName);
        }
    }
}
