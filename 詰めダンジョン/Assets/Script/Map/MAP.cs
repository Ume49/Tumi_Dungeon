using UnityEngine;

// マップ情報
public class MAP : MonoBehaviour {

    // マス目の距離
    public float masume_distance;

    // 0,0のオブジェクトの座標
    // 全てのマップの座標の基準
    public Vector3 standerd_position;

    // 当たり判定マップ
    // [ x , y ]
    // 行ける  ->true
    // 行けない->false
    public bool[,] collider_map;

    // マップ上に存在するオブジェクトのマップ
    // Transformを直接保持
    // [ x , y ]
    public Transform[,] dynamic_object_map;

    // 動かないオブジェクトのマップ
    // Transformを直接保持
    // [ x, y ]
    public Transform[,] static_object_map;
}