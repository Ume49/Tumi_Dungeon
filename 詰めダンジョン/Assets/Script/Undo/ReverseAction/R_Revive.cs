using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Revive : IReverseAction
{
    public override bool _update()
    {
        // 復活させる
        this.gameObject.SetActive(true);

        return true;
    }
}
