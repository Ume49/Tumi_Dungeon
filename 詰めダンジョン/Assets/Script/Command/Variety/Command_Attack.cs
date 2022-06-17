using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Attack : ICommand
{
    public Transform attack_charactor;
    public Direction direction;

    public Command_Attack(Transform attack_charactor, Direction direction){
        this.attack_charactor = attack_charactor;
        this.direction        = direction;

        base.id=ID.Attack;
    }
}
