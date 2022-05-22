using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*

実際の座標上で動かす
マップ上で動かす
キャラクターが持っている座標データを動かす

*/
public class Move : IAction
{
    [SerializeField] IndexToPos indexToPos;
    [SerializeField] DynamicMap_Move map_mover;
    [SerializeField] Now_Position_onMap player_index_pos;
    [SerializeField] float speed;
    [SerializeField] Vector3 destination;

    public void SetDestination(Vector2Int destination_index)
    {
        // 実際の移動に使う座標を決定
        destination = indexToPos.Get(destination_index);

        // マップ上での位置を変更
        map_mover.Move(player_index_pos.index, destination_index);

        // キャラクターが持っているインデックス座標を変更 
        player_index_pos.index = destination_index;
    }

    public override bool _update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        // 現在座標が目的地と一致しているなら処理を終了
        return transform.position == destination;
    }
}
