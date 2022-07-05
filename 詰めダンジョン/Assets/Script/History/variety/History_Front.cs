using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 向きの履歴
public class History_Front : IHistory
{
    public Direction past_front; 

    public History_Front(Transform chara, Direction past_front) : base(ID.ChageFront, chara)
    {
        this.past_front = past_front;
    }
}
