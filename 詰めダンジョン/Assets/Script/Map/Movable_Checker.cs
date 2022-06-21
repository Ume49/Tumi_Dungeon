using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movable_Checker : MonoBehaviour
{
    [SerializeField] MAP map;
    [SerializeField] Check_PositionInMap position_check;

    ///<summary>
    /// その場所に移動していいならtrue、ダメならfalse
    ///</summary>
    public bool Check(Vector2Int destination_index)
    {
        // そもそも配列外参照をしようとしている場合はfalse
        if(position_check.Collider_Map      (destination_index)) return false;
        if(position_check.DynamicObject_Map (destination_index)) return false;
        if(position_check.StaticObject_Map  (destination_index)) return false;

        // 移動先に壁があるならfalse
        if(map.collider_map      [destination_index.x, destination_index.y] != true) return false;

        // エネミーなどの競合オブジェクトが既にあるならfalse
        if(map.dynamic_object_map[destination_index.x, destination_index.y] != null) return false;
        
        // 残りはtrue
        return true;
    }
}
