using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] PrefabSpawner spawner;

    private void Start()
    {
        LevelGenerator generator = new LevelGenerator(spawner, player);
        generator.FirstGenerate();
    }
}
