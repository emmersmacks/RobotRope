using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private PrefabSpawner _spawner;

    public LevelGenerator(PrefabSpawner spawner)
    {
        _spawner = spawner;
    }

    public List<Vector2Int> FirstGenerate()
    {
        var fastenerPositions = GeneratorFactory.ProduceGenerate(PrefabType.Fastener).Generate(null);
        var prefabDict = new Dictionary<Vector2Int,PrefabType>();
        AddPrefabPairToDictonary(fastenerPositions, PrefabType.Fastener, prefabDict);
        _spawner.PrefabSpawn(prefabDict);
        return fastenerPositions;
    }

    public List<Vector2Int> UploadPrefabs(List<Vector2Int> afforablePositions)
    {
        var fastenerPositions = GeneratorFactory.ProduceGenerate(PrefabType.Fastener).Generate(afforablePositions);
        var prefabDict = new Dictionary<Vector2Int, PrefabType>();
        AddPrefabPairToDictonary(fastenerPositions, PrefabType.Fastener, prefabDict);
        _spawner.PrefabSpawn(prefabDict);
        return fastenerPositions;
    }

    private Dictionary<Vector2Int, PrefabType> AddPrefabPairToDictonary(List<Vector2Int> list, PrefabType type, Dictionary<Vector2Int, PrefabType> dictonary)
    {
        foreach (var prefab in list)
        {
            dictonary.Add(prefab, type);
        }

        return dictonary;
    }
}

public enum PrefabType
{
    Fastener,
    Money,
}