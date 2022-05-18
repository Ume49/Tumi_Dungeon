using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_Checker : MonoBehaviour
{
    [SerializeField] MAP map;

    public bool Check(Vector2Int destination_index)
    {
        return map.collider_map[destination_index.x, destination_index.y];
    }
}
