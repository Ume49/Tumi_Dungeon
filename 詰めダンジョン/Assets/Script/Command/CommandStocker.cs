using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandStocker : MonoBehaviour
{
    [SerializeField]
    Stack<ICommand> commands;

    void Awake()
    {
        commands = new Stack<ICommand>();
    }

    public void Stack_Push(ICommand new_command)
    {
        commands.Push(new_command);
    }

    public ICommand Stack_Pop()
    {
        return commands.Pop();
    }
}
