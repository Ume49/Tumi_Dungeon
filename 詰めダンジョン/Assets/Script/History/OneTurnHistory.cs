using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// 敵と自分の1ターン分の行動履歴
public class OneTurnHistory
{
    Stack<IHistory> history_stack;

    ///<summary>1ターン分の履歴閲覧オブジェクト</summary>
    public IHistory[] oneturn_view {
        get{
            // history_stack.ToArray()だとスタックの構造上逆順にして返してしまうっぽいので、1回逆順にした上でToArrayを返す
            return history_stack.Reverse().ToArray();
        }
    }

    public void Add(IHistory new_histroy) {
        history_stack.Push(new_histroy);
    }

    public OneTurnHistory() {
        history_stack=new Stack<IHistory>();
    }
}
