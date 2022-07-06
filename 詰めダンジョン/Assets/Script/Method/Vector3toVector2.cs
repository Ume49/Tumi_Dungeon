using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector3to2
{
    // Vector3をxz平面上での二次元ベクトルに変換
    // y=0にするだけ
    static public Vector2 xz_plane(Vector3 origin_vec){
        return new Vector2(origin_vec.x, origin_vec.z);
    }
}
