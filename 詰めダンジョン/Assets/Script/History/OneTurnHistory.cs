using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 敵と自分の1ターン分の行動履歴
public class OneTurnHistory
{
    Stack<IHistory> history_stack;

    public void Add(IHistory new_histroy)
    {
        history_stack.Push(new_histroy);
    }

    public OneTurnHistory(){
        history_stack=new Stack<IHistory>();
    }
}
