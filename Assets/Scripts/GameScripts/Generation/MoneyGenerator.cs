using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation.Factory
{
    public class MoneyGenerator : IGenerator
    {
        List<Vector2> IGenerator.Generate(List<Vector2> afforablePosition)
        {
            var moneyPositions = new List<Vector2>();
            foreach (var position in afforablePosition)
            {
                var isSpawnChance = 2;

                if (Random.Range(1, isSpawnChance + 1) != 2)
                {
                    var angle = Random.Range(0.1f, 1f);
                    var radius = Random.Range(GenerationSettings.generationMoneyRadiusMin, GenerationSettings.generationMoneyRadiusMax);
                    for (int i = 0; i < GenerationSettings.moneyCount; i++)
                    {

                        var x = Mathf.Cos(angle) * radius + position.x;
                        var y = Mathf.Sin(angle) * radius + position.y;
                        moneyPositions.Add(new Vector2(x, y));
                        angle += 0.5f;
                    }
                }
            }
            return moneyPositions;
        }
    }
}

