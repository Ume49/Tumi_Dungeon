using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// マップ配列上での移動処理を補助するクラス
public class DynamicMap_Move : MonoBehaviour
{
    [SerializeField] MAP map;
    public void Move(Vector2Int old_index, Vector2Int new_index)
    {
        var t = map.dynamic_object_map[old_index.x, old_index.y];

        map.dynamic_object_map[old_index.x, old_index.y] = null;

        map.dynamic_object_map[new_index.x, new_index.y] = t;
    }
}
