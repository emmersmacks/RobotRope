using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratorFactory : MonoBehaviour
{
    public static IGenerator ProduceGenerate(ChunkType type)
    {
        switch (type)
        {
            case ChunkType.Fastener: return new FastenersGenerator();
            default: return null;
        }
    }

}
