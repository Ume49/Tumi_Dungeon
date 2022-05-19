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
    [SerializeField] Process_StateMachine stateMachine;
    [SerializeField] IndexToPos indexToPos;
    [SerializeField] MAP map;
    [SerializeField] float speed;
    [SerializeField] Vector3 destination;

    public void SetDestination(Vector2Int destination_index)
    {
        // 実際の移動に使う座標を決定
        destination = indexToPos.Get(destination_index);

        // キャラクターが持っているインデックス座標を変更 
        GetComponent<Now_Position_onMap>().index = destination_index;

        // マップ上での位置を変更

    }

    public override void _update()
    {
        transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);

        if (transform.position == destination)
        {
            // とりあえず戻す
            stateMachine.state = Process_StateMachine.State.Input_Check;
        }
    }
}
