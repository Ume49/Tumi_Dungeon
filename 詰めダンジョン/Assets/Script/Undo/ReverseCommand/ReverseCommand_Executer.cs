using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCommand_Executer : MonoBehaviour
{
    Stack<IReverseCommand> reverseCommands;

    [SerializeField] Process_StateMachine state;

    IReverseAction current_action;

    [SerializeField] Turn_Counter turn_counter;

    void Awake() {
        reverseCommands = new Stack<IReverseCommand>();
    }

    public void Make_ReverseCommand_fromHistory(OneTurnHistory history){
        // historyからReverseCommandを作成して追加
        foreach(var history_element in history.history_stack){
            reverseCommands.Push(IReverseCommand.Make_RCommand(history_element));
        }
    }

    void OnEnable() {
        SetNextAction();
    }

    void Update() {
        bool is_action_end=false;

        is_action_end = current_action._update();

        // is_action_endが初期化されたままの値の時はスキップされる
        if(is_action_end){
            // 処理が終了したら次のコマンドを取り出す
            if(SetNextAction() == false) {
                // Undo処理が終了したら残りの手数も回復しておく
                turn_counter.turn_limit += 1;
            }
        }
    }

    
    // コマンドを取り出してそっから実際に処理するアクションクラスを取得、設定
    // スタックの残りがあって、正常に処理を続行できるようならtrueを返す、残ってないならfalseを返す
    bool SetNextAction(){
        // そもそも残りのコマンドが存在しない場合はUndoの終了通知をして終了
        if(reverseCommands.Count <= 0){
            // なぜか呼ばれている
            state.End_Undo();
            return false;
        }

        IReverseCommand current_command = this.reverseCommands.Pop();

        // コマンドからアクションクラスを取得
        current_action = IReverseAction.Get_ReverseAction_fromReverseCommand(current_command);

        return true;
    }    
}
