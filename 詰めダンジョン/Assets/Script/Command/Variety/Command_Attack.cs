using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command_Attack : ICommand
{
    public Direction direction;
    public Transform attack_charactor;
}
