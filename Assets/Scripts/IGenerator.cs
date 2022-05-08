using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IGenerator
{
    public List<Vector2Int> Generate(List<Vector2Int> afforablePosition);
}


