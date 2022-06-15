using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// １ターン分のコマンドの履歴
public class OneTurn_CommandHistory : MonoBehaviour
{
    Stack<ICommand> commands;

    void Awake()
    {
        // Unityがシリアライズしてくれないクソゴミエディタなのでわざわざ
        // ここで初期化
        commands = new Stack<ICommand>();
    }

    // コマンド登録
    public void Command_Push(ICommand new_command)
    {
        commands.Push(new_command);
    }

    // １個ずつコマンド取り出し
    public ICommand Command_Pop()
    {
        return commands.Pop();
    }
}
