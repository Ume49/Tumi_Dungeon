using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTurn_Undo : MonoBehaviour
{
    [SerializeField] ReverseCommand_Executer executer;
    [SerializeField] History_Stocker history;

    public void Call(){
        // １ターン分のUndo処理を開始する

        // スタックから１ターン分の履歴を取得
        
    }
}
