using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Move : IReverseAction
{
    // 内部情報移動関係
    [SerializeField] DynamicMap_Move map_mover;

    // ワールド座標移動関係
    [SerializeField] IndexToPos indexToPos;
    [SerializeField] float speed;
    Vector3 destination;

    public void SetDestination(Vector2Int pos){
        // 内部マップでの位置を変更
        
        // 現在の位置を取得
        var current_pos = GetComponent<CurrentPosition_OnMap>();

        // データ更新
        map_mover.Move(current_pos.value, pos);
        current_pos.value = pos;

        // ワールド座標での移動先を設定
        destination = indexToPos.Get(pos);
    }

    public override bool _update()
    {
        // 移動する
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // 目的地に到達したら処理終了
        if(transform.position == destination) return true;

        return false;
    }

    void Reset() {
        map_mover   = Resources.FindObjectsOfTypeAll<DynamicMap_Move>()[0];
        indexToPos  = Resources.FindObjectsOfTypeAll<IndexToPos>()[0];
    }
}
