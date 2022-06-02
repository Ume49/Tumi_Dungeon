using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Transformを渡すとNow_Position_onMapからインデックスを取得して返してくれる
public class GetIndexPos
{
    public static Vector2Int Get(Transform target)
    {
        return target.GetComponent<Now_Position_onMap>().index;
    }
}
