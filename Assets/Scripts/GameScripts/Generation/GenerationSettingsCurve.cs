using UnityEngine;

namespace Ropebot.Game.Level.Generation
{
    public class GenerationSettingsCurve : MonoBehaviour
    {
        [SerializeField] private AnimationCurve _fastenerCurve;

        public void GenerateDataUpdate(int currentDifficultly)
        {
            //GenerationSettings.fastenerCount = (int)_fastenerCurve.Evaluate(currentDifficultly);
        }
    }
}

