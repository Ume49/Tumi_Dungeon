using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Transformを渡すとCurrentPosition_OnMapからインデックスを取得して返してくれる
public class GetIndexPos
{
    public static Vector2Int Get(Transform target)
    {
        return target.GetComponent<CurrentPosition_OnMap>().index;
    }
}
