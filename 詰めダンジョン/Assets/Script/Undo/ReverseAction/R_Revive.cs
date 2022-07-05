using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Revive : IReverseAction
{
    [SerializeField] MAP map;

    public override bool _update()
    {
        // 復活させる
        this.gameObject.SetActive(true);

        // マップ上でも復活させる
        var pos = GetComponent<CurrentPosition_OnMap>().value;
        map.dynamic_object_map[pos.x, pos.y] = transform;

        return true;
    }
}
