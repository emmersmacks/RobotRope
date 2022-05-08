using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationSettingsCurve : MonoBehaviour
{
    [SerializeField] private AnimationCurve _fastenerCurve;

    public void GenerateDataUpdate(int currentDifficultly)
    {
        GenerationSettings.fastenerCount = (int)_fastenerCurve.Evaluate(currentDifficultly);
    }
}
