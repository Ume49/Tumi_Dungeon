using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 親クラスの回転を引き継がないようにするクラス
/// </summary>
// * 厳密には、親の回転と真反対の回転をさせることで影響を相殺する
public class Non_RelativeRotate : MonoBehaviour
{
    // 変更検知用の、過去の親の値
    Quaternion parent_past_rotation;

    void Start() {
        parent_past_rotation=transform.parent.rotation;
    }

    // 回転とかの挙動はUpdateで呼ばれることが想定されるので、すぐ消せるようにLateUpdate
    void LateUpdate() {
        // 親のRotationの変更を検知したら反対方向の回転を計算・代入する
        if(transform.parent.rotation==parent_past_rotation) return;

        // 変更を検知したので更新
        parent_past_rotation=transform.parent.rotation;

        // 反対方向の回転を計算
        var parent_rotation = transform.parent.rotation.eulerAngles;
        var current_rotation = parent_rotation*(-1.0f);

        Debug.Log(current_rotation);

        transform.localRotation=Quaternion.Euler(current_rotation);
    }
}
