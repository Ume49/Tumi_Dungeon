using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Direciton_Table
{
    static Dictionary<Direction, Vector2Int> table = new Dictionary<Direction, Vector2Int>()
    {
        {Direction.UP,      new Vector2Int(0,-1)},
        {Direction.RIGHT,   new Vector2Int(1,0)},
        {Direction.DOWN,    new Vector2Int(0,1)},
        {Direction.LEFT,    new Vector2Int(-1,0)}
    };

    public static Vector2Int Direction_To_Table(Direction direction)
    {
        return table[direction];
    }
}
