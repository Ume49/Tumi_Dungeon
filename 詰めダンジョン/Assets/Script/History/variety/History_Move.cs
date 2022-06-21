using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Move : IHistory
{
    public Vector2Int past_pos;
    public Vector2Int destination_pos;
    public Transform move_charactor;

    /// <summary>
    /// 座標はマップ上でのインデックス
    /// </summary>
    public History_Move(Transform move_charactor, Vector2Int past_position, Vector2Int destination){
        // 初期化入れる
        this.past_pos        = past_position;
        this.destination_pos = destination;
        this.move_charactor  = move_charactor;
    }
}
