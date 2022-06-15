using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Move : IHistory
{
    public Direction direction;
    Transform move_charactor;

    public History_Move(Command_Move command){
        direction=command.direction;
    }
}
