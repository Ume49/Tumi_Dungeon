using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 動けないときの処理
public class CannoutMove : IAction
{

    public override bool _update()
    {
        Debug.Log("その先は壁だ");

        // 入力待機させる
        return true;
    }
}
