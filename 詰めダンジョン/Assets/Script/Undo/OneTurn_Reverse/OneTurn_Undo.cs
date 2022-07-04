using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneTurn_Undo : MonoBehaviour
{
    [SerializeField] ReverseCommand_Executer executer;
    [SerializeField] History_Stocker history;

    public void Call(){
        // １ターン分のUndo処理をする上で必要な情報をセットする
        // 以降のUpdateからUndoが開始される

        // スタックから１ターン分の履歴を取得
        OneTurnHistory current_histories=history.Pop();

        // 逆再生コマンドを作成してセット
        executer.Make_ReverseCommand_fromHistory(current_histories);

        // これから１ターン分逆再生することを通知
    }
}
