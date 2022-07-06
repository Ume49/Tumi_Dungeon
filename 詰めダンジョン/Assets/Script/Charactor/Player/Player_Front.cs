using UnityEngine;
using System.Collections.Generic;

public class Player_Front : Front
{
    [SerializeField] History_Stocker history;
    History_Front front_history;

    public override void Change_Direction(Direction d){
        if(d != base.direction){
            // 向きを変更する前に直前の向きの履歴を作っておく
            // QueueやStackでの保存も考えたが、結局最後の部分だけ残っていればよいのでこの形式にした
            front_history = new History_Front(transform, base.direction);
        }

        base.Change_Direction(d);
    }

    public void Throw_History(){
        if(front_history == null) return; 

        history.Add(front_history);
        front_history = null;
    }
}