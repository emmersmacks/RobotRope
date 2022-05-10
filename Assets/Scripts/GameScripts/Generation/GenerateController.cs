using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation
{
    public class GenerateController : MonoBehaviour
    {
        [SerializeField] Transform player;
        [SerializeField] PrefabSpawner spawner;

        private List<Vector2> _generatePositions;
        private LevelGenerator _generator;

        private void Start()
        {
            _generator = new LevelGenerator(spawner);
            _generatePositions = _generator.Generate(null);
        }

        private void Update()
        {
            if (_generatePositions != null && _generatePositions.Count > 0)
            {
                if (Vector2.Distance(player.position, _generatePositions[_generatePositions.Count - 1]) < 50)
                {
                    _generatePositions = _generator.Generate(_generatePositions);
                }
            }
        }
    }
}

