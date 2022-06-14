using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 向いている方向
public class Front : MonoBehaviour
{
    public Direction direction;

    [SerializeField] Vector3 up_rotation;
    [SerializeField] Vector3 down_rotation;
    [SerializeField] Vector3 right_rotation;
    [SerializeField] Vector3 left_rotation;
    // 向きの変更
    public void Change_Direction(Direction d) {
        direction = d;

        // アタッチされているオブジェクトのRotationも対応するものに変更する
        Quaternion rotate=new Quaternion();

        switch(d){
            case Direction.UP:
                rotate=Quaternion.Euler(up_rotation);
                break;
            case Direction.DOWN:
                rotate=Quaternion.Euler(down_rotation);
                break;
            case Direction.RIGHT:
                rotate=Quaternion.Euler(right_rotation);
                break;    
            case Direction.LEFT:
                rotate=Quaternion.Euler(left_rotation);
                break;
        }

        transform.rotation=rotate;
    }
}
