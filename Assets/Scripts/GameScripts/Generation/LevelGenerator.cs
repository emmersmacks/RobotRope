using Ropebot.Game.Level.Generation.Factory;
using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation
{
    public class LevelGenerator
    {
        private PrefabSpawner _spawner;

        public LevelGenerator(PrefabSpawner spawner)
        {
            _spawner = spawner;
        }

        public List<Vector2> Generate(List<Vector2> afforablePositions)
        {
            var fastenerPositions = GeneratorFactory.ProduceGenerate(PrefabType.Fastener).Generate(afforablePositions);

            var moneyPositions = GeneratorFactory.ProduceGenerate(PrefabType.Money).Generate(fastenerPositions);
            var prefabDict = new Dictionary<Vector2, PrefabType>();
            prefabDict = AddPrefabPairToDictonary(fastenerPositions, PrefabType.Fastener, prefabDict);
            prefabDict = AddPrefabPairToDictonary(moneyPositions, PrefabType.Money, prefabDict);
            _spawner.PrefabSpawn(prefabDict);
            return fastenerPositions;
        }

        private Dictionary<Vector2, PrefabType> AddPrefabPairToDictonary(List<Vector2> list, PrefabType type, Dictionary<Vector2, PrefabType> dictonary)
        {
            foreach (var prefab in list)
            {
                dictonary.Add(prefab, type);
            }

            return dictonary;
        }
    }
}

