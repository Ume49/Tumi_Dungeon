using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// マップのインデックスをワールド座標に変換する
public class IndexToPos : MonoBehaviour
{
    [SerializeField] MAP map;

    // 座標の計算
    public Vector3 Get(int x, int y)
    {
        return map.standerd_position + new Vector3(map.masume_distance * x, 0.0f, map.masume_distance * (-y));
    }
}
