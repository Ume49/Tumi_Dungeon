using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Move : IHistory
{
    // Todo:どこからどこへ移動したかの情報に変える
    public Direction direction;
    Transform move_charactor;

    public History_Move(Command_Move command){
        // 初期化入れる
    }
}
