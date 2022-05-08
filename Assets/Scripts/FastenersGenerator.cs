using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastenersGenerator : IGenerator
{
    private int _firstFastenerCount = 5;
    private int _fastenerCoordRange = 10;

    public List<Vector2Int> Generate(List<Vector2Int> afforablePosition)
    {
        var positions = new List<Vector2Int>();

        if(afforablePosition == null)
        {
            positions.Add(new Vector2Int(0, 0));

            for(int i = 0; i < _firstFastenerCount; i++)
            {
                var maxValueY = positions[i].y + _fastenerCoordRange;
                var minValueY = positions[i].y - _fastenerCoordRange;
                var minValueX = positions[i].x + _fastenerCoordRange;
                var randomValueY = Random.Range(minValueY, maxValueY);
                var newPosition = new Vector2Int(minValueX, randomValueY);
                positions.Add(newPosition);
            }

            return positions;
        }

        return null;
    }
}
