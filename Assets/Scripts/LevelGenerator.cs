using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator
{
    private Transform _player;
    private PrefabSpawner _spawner;

    private List<GameObject> _list;

    public LevelGenerator(PrefabSpawner spawner, Transform player)
    {
        _player = player;
        _spawner = spawner;
    }

    public void FirstGenerate()
    {
        var fastenerPositions = GeneratorFactory.ProduceGenerate(ChunkType.Fastener).Generate(null);
        var chunksDict = new Dictionary<Vector2Int,ChunkType>();
        foreach (var chunk in fastenerPositions)
        {
            chunksDict.Add(chunk, ChunkType.Fastener);
        }
        _spawner.PrefabSpawn(chunksDict);
    }
}

public enum ChunkType
{
    Fastener,
}