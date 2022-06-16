using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Move : ICommand
{
    public Vector2Int destination_onMap;
    public Transform move_charactor;

    public Command_Move(Vector2Int destination, Transform move_chara){
        destination_onMap=destination;
        move_charactor=move_chara;
    }
}
