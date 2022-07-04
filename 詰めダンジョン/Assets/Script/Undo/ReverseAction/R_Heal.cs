using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R_Heal : IReverseAction
{
    public int heal_point;
    public override bool _update(){
        #if UNITY_EDITOR
            if(heal_point <= 0){
                Debug.LogWarning("R_Heal.heal_pointに数値を設定し忘れていませんか？");
            }
        #endif

        // 回復して終了
        var chara_para = GetComponent<Charactor_Paramater>();

        chara_para.hp += heal_point;

        return true;
    }
}
