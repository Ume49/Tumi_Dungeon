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

    public Rcommand_Attack(Transform damaged_chara, int damaged_point){
        this.heal_chara = damaged_chara;
        this.heal_point = damaged_point;

        // IDを忘れずに設定
        base.id = IReverseCommand.ID.Attack;
    }
}
