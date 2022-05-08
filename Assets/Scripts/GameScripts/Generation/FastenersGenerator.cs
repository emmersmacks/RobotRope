using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastenersGenerator : IGenerator
{
    public List<Vector2Int> Generate(List<Vector2Int> afforablePosition = null)
    {
        var positions = new List<Vector2Int>();

        if (afforablePosition == null)
        {
            positions.Add(new Vector2Int(0, 0));
            positions = GeneratePositions(positions, GenerationSettings.firstGenerationFastenersCount);
            return positions;
        }
        else
        {
            positions.Add(afforablePosition[afforablePosition.Count - 1]);
            positions = GeneratePositions(positions, GenerationSettings.uploadFastenersCount);
            positions.Remove(positions[0]);
            return positions;
        }
    }

    private List<Vector2Int> GeneratePositions(List<Vector2Int> positions, int fastenerNumber)
    {
        for (int i = 0; i < fastenerNumber; i++)
        {
            var maxValueY = positions[i].y + GenerationSettings.fastenerCoordRange;
            var minValueY = positions[i].y - GenerationSettings.fastenerCoordRange;
            var minValueX = positions[i].x + GenerationSettings.fastenerCoordRange;
            int randomValueY = Random.Range(minValueY, maxValueY);

            while (randomValueY < GenerationSettings.availableGenerationCoordMin && randomValueY > GenerationSettings.availableGenerationCoordMax)
            {
                randomValueY = Random.Range(minValueY, maxValueY);
            }

            var newPosition = new Vector2Int(minValueX, randomValueY);
            positions.Add(newPosition);
        }
        
        return positions;
    }
}
