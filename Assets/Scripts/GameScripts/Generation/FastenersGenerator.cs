using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation.Factory
{
    public class FastenersGenerator : IGenerator
    {
        public List<Vector2> Generate(List<Vector2> afforablePosition = null)
        {
            var positions = new List<Vector2>();

            if (afforablePosition == null)
            {
                positions.Add(new Vector2(0, 0));
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

        private List<Vector2> GeneratePositions(List<Vector2> positions, int fastenerNumber)
        {
            for (int i = 0; i < fastenerNumber; i++)
            {
                var maxValueY = positions[i].y + GenerationSettings.availableGenerationCoordMax;
                var minValueY = positions[i].y - GenerationSettings.availableGenerationCoordMin;
                if (maxValueY > 20f)
                    maxValueY = 20f;
                else if(minValueY < -20)
                    minValueY = -20;
                float randomValueY = Random.Range(minValueY, maxValueY);
                var ValueX = positions[i].x + GenerationSettings.fastenerCoordXRange - (randomValueY - positions[0].y) * 0.2f;
                var newPosition = new Vector2(ValueX, randomValueY);
                positions.Add(newPosition);
            }

            return positions;
        }
    }
}

