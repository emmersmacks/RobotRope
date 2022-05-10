using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation
{
    public class PrefabSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] _chunks;

        public List<GameObject> PrefabSpawn(Dictionary<Vector2, PrefabType> chunks)
        {
            List<GameObject> spawnedPrefabs = new List<GameObject>();

            foreach (var chunk in chunks)
            {
                var prefab = GetPrefabByType(chunk.Value);
                if (prefab != null)
                {
                    var spawnedPrefab = Instantiate(prefab, (Vector3)chunk.Key, Quaternion.identity);
                    spawnedPrefabs.Add(spawnedPrefab);
                }
            }

            return spawnedPrefabs;
        }

        private GameObject GetPrefabByType(PrefabType type)
        {
            foreach (var chunk in _chunks)
            {
                var chunkInform = chunk.GetComponent<PrefabInform>().prefabType;
                if (chunkInform == type)
                    return chunk;
            }

            return null;
        }
    }
}

