using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 攻撃履歴。実際には誰がダメージを受けたか、だけ保存する
/// </summary>
public class History_Attack : IHistory
{
    public Transform damaged_charactor;
    public int damage;

    public History_Attack(Transform damaged_charactor, int damage){
        this.damaged_charactor = damaged_charactor;
        this.damage            = damage;

        base.id                = IHistory.ID.Attack;
    }
}
