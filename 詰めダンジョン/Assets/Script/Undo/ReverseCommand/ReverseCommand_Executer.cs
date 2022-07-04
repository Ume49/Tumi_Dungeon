using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReverseCommand_Executer : MonoBehaviour
{
    Stack<IReverseCommand> reverseCommands;

    public void Make_ReverseCommand_fromHistory(OneTurnHistory history){
        foreach(var history_element in history.history_stack){
            
        }
    }
}
