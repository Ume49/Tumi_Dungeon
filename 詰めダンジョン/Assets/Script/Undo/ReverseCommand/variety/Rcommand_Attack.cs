using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 攻撃の逆->回復させる
public class Rcommand_Attack : IReverseCommand
{
    // 回復すべきキャラクター
    public Transform heal_chara;
    // 回復すべき量
    public int heal_point;

    public Rcommand_Attack(Transform damaged_chara, int damaged_point) : base(IReverseCommand.ID.Attack, damaged_chara)
    {
        this.heal_chara = base.target_chara;
        this.heal_point = damaged_point;
    }
}
