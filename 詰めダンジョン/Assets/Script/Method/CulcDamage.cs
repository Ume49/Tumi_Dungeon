using UnityEngine;

/// <summary>
/// ダメージを計算する関数
/// </summary>
public class CulcDamage 
{
    // ダメージ計算
    public static int Culc(Charactor_Paramater attack_chara, Charactor_Paramater deffence_chara){
        int damage = attack_chara.attak-deffence_chara.deffence;

        // ダメージがマイナスになってしまうことを回避
        if(damage <= 0) return 0;

        return damage;
    }
}
