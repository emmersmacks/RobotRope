using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation.Factory
{
    public interface IGenerator
    {
        public List<Vector2> Generate(List<Vector2> afforablePosition);
    }
}



