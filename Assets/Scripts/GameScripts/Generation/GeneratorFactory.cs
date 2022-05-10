using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ropebot.Game.Level.Generation.Factory
{
    public class GeneratorFactory : MonoBehaviour
    {
        public static IGenerator ProduceGenerate(PrefabType type)
        {
            switch (type)
            {
                case PrefabType.Fastener: return new FastenersGenerator();
                case PrefabType.Money: return new MoneyGenerator();
                default: return null;
            }
        }

    }
}

