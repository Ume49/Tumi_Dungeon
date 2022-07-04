using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCommand_Executer : MonoBehaviour
{
    Stack<IReverseCommand> reverseCommands;

    [SerializeField] Process_StateMachine state;

    void Awake() {
        reverseCommands = new Stack<IReverseCommand>();
    }

    public void Make_ReverseCommand_fromHistory(OneTurnHistory history){
        // historyからReverseCommandを作成して追加
        foreach(var history_element in history.history_stack){
            reverseCommands.Push(IReverseCommand.Make_RCommand(history_element));
        }
    }

    
    // コマンドを取り出してそっから実際に処理するアクションクラスを取得、設定
    void SetNextAction(){
        // そもそも残りのコマンドが存在しない場合はUndoの終了通知をして終了
        if(reverseCommands.Count <= 0){
            state.End_Undo();
            return;
        }

        IReverseCommand current_command = this.reverseCommands.Pop();

        // コマンドからアクションクラスを取得

    }

    void OnEnable() {
        SetNextAction();
    }

    void Update() {
        bool is_action_end=false;


        // is_action_endが初期化されたままの値の時はスキップされる
        if(is_action_end){
            // 処理が終了したら次のコマンドを取り出す
            SetNextAction();
        }
    }
}
