using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Move : ICommand
{
    public Direction direction;
    public Transform move_charactor;

    public Command_Move(Direction d, Transform move_chara){
        direction      = d;
        move_charactor = move_chara;

        base.id=ID.Move;
    }
}
