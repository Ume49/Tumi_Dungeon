using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History_Attack : IHistory
{
    public Transform attack_charactor;
    public Transform deffence_charactor;
    public int damage;

    public History_Attack(Command_Attack command, Transform attack_target_charactor, int damage){
        attack_charactor=command.attack_charactor;
        deffence_charactor=attack_target_charactor;
        damage=this.damage;
    }
}
