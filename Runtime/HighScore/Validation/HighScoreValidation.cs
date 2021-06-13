using System.Collections.Generic;
using UnityEngine;
using ChainPattern;

namespace RealbizGames.Data
{
    public class HighScoreValidation : IAsynPieceExecutor
    {
        const string TAG = "HighScoreValidation";

        private IHighScoreService _service;

        private HighScoreValidationResult _response;

        public HighScoreValidation(IHighScoreService service)
        {
            _service = service;
        }

        public bool IsDone => _response != null;

        public IAsynPieceResult Result => _response;

        public void Execute(IAsynChainResult data)
        {
            #if UNITY_EDITOR
            Debug.LogFormat("{0} - Execute", TAG);

            List<HighScoreDTO> dtos = _service.GetAll();

            string msg = ToStringUtils.ToStringForList<HighScoreDTO>(dtos);

            Debug.LogFormat("{0} - {1}", TAG, msg);

            Debug.LogFormat("{0} - End", TAG);
            #endif

            _response = new HighScoreValidationResult(success: true);
        }
    }
}
