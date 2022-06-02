using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAllChildren
{
    // 子・孫…関係にあるTransformを全て取得する
    public static void Get(Transform parent, List<Transform> output_list)
    {
        // 脱出条件
        if (parent.childCount == 0) return;

        foreach (Transform w in parent)
        {
            output_list.Add(w);
            Get(w, output_list);
        }
    }
}
