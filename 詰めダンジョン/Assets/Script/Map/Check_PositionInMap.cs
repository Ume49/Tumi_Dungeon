using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 配列外参照チェックをまとめたクラス
/// 配列外参照をしているようならtrue、大丈夫ならfalse
/// </summary>
// *普段とtrueとfalseの関係が逆なのは、
// if(CheckPositionInMap.DynamicObject_Map(position)) return;  // 範囲外参照ガード
// ↑のような実装を簡単にできるようにするため。!= trueとか追加で書くの面倒じゃん？
public class Check_PositionInMap : MonoBehaviour
{
    [SerializeField] MAP map;


    public bool DynamicObject_Map(Vector2Int pos){
        var map_size = new Vector2Int(map.dynamic_object_map.GetLength(0), map.dynamic_object_map.GetLength(1));

        if(pos.x >= map_size.x) return true;
        if(pos.x < 0)           return true;
        if(pos.y >= map_size.y) return true;
        if(pos.y < 0)           return true;

        return false;
    }

    public bool StaticObject_Map(Vector2Int pos){
        var map_size = new Vector2Int(map.static_object_map.GetLength(0), map.static_object_map.GetLength(1));

        if(pos.x >= map_size.x) return true;
        if(pos.x < 0)           return true;
        if(pos.y >= map_size.y) return true;
        if(pos.y < 0)           return true;

        return false;
    }

    public bool Collider_Map(Vector2Int pos){
        var map_size = new Vector2Int(map.collider_map.GetLength(0), map.collider_map.GetLength(1));

        if(pos.x >= map_size.x) return true;
        if(pos.x < 0)           return true;
        if(pos.y >= map_size.y) return true;
        if(pos.y < 0)           return true;

        return false;
    }

    void Reset()
    {
        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }
}
