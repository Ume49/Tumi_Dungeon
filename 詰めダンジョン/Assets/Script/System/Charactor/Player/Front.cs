using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 向いている方向
public class Front : MonoBehaviour
{
    public Direction direction;
    // 向きの変更
    public void Change_Direction(Direction d) {
        direction = d;

        // アタッチされているオブジェクトのRotationも対応するものに変更する

    }
}
