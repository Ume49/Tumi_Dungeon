using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_Checker : MonoBehaviour
{
    [SerializeField] MAP map;

    ///<summary>
    ///</summary>
    public bool Check(Vector2Int destination_index)
    {
        try
        {

            bool colide = map.collider_map[destination_index.x, destination_index.y];

            bool is_null = map.dynamic_object_map[destination_index.x, destination_index.y] == null;

            // 移動先に壁がなく、かつエネミーなどの競合オブジェクトがない場合のみtrue
            return colide && is_null;
        }
        catch (System.IndexOutOfRangeException)
        {
            // そもそも配列外参照をしようとしている場合はfalse
            return false;
        }
    }
}
