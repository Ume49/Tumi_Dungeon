using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCommand_Executer : MonoBehaviour
{
    Stack<IReverseCommand> reverseCommands;

    void Awake() {
        reverseCommands = new Stack<IReverseCommand>();
    }

    public void Make_ReverseCommand_fromHistory(OneTurnHistory history){
        // historyからReverseCommandを作成して追加
        foreach(var history_element in history.history_stack){
            reverseCommands.Push(IReverseCommand.Make_RCommand(history_element));
        }
    }
}
