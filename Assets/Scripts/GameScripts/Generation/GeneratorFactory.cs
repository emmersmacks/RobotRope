using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFactory : MonoBehaviour
{
    public static IGenerator ProduceGenerate(PrefabType type)
    {
        switch (type)
        {
            case PrefabType.Fastener: return new FastenersGenerator();
            default: return null;
        }
    }

}
