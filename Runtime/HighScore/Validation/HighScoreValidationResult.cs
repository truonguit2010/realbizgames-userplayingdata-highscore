using ChainPattern;

namespace RealbizGames.Data
{
    public class HighScoreValidationResult : IAsynPieceResult
    {
        public const string PUBLIC_KEY = "HighScoreValidationResult";

        private bool _success;

        public HighScoreValidationResult(bool success)
        {
            _success = success;
        }

        public bool Success { get => _success; set => _success = value; }

        public string GetKey()
        {
            return PUBLIC_KEY;
        }
    }
}

