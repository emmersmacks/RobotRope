using Ropebot.Game.Level.Generation;
using UnityEngine;

namespace Ropebot.Game
{
    public class PrefabInform : MonoBehaviour
    {
        public PrefabType prefabType;
    }

    public enum PrefabType
    {
        Fastener,
        Money,
    }
}


