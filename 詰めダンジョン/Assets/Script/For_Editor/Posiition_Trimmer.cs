using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 小数故にバラけている座標をResetで整形する
public class Posiition_Trimmer : MonoBehaviour
{
    private void Reset()
    {
        Trim();
    }

    public void Trim()
    {
        // アタッチされているオブジェクトの座標を整数にする
        Vector3 pos = gameObject.transform.position;

        // 整形処理
        Func<float, float> seikei = x => (float)Math.Round(x);

        gameObject.transform.position = new Vector3(seikei(pos.x), seikei(pos.y), seikei(pos.z));
    }
}
