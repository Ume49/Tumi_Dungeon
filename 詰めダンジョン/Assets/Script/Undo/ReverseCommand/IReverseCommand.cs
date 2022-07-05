using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IReverseCommand
{
    public enum ID{
        Move,
        Attack,
        Death,
        Pickup,
        Front
    }
    public ID id;
    public Transform target_chara;

    public IReverseCommand(ID iD, Transform target){
        this.id             = iD;
        this.target_chara   = target;
    }

    static public IReverseCommand Make_RCommand(IHistory history){
        // IDに対応したReverseCommandを作成して返す
        switch(history.id){
            case IHistory.ID.Move:
            {
                var move_history = (History_Move)history;

                return new Rcommand_Move(history.target_charactor, move_history.past_pos, move_history.destination_pos);
            }
            case IHistory.ID.Attack:
            {
                var attack_history = (History_Attack)history;

                return new Rcommand_Attack(history.target_charactor, attack_history.damage);
            }
            case IHistory.ID.Pickup:
            {
                // TODO pickupの履歴はコンストラクタが完全ではないので、Rcommand_Pickupが完成しだいこちらの内容も完全にすること
                var pickup_history = (History_Pickup)history;

                return new Rcommand_Pickup(history.target_charactor);
            }
            case IHistory.ID.Deth:
            {
                return new Rcommand_Death(history.target_charactor);
            }
            default:
                // 前caseですべての処理が終わるはずなのでここに到達する時点でエラー
                Debug.LogError("ReverseCommandを作成する上でのエラー：渡されたHistroyのIDが不正です");

                // 無害な0ダメージ履歴を返しておく
                return new Rcommand_Attack(null, 0);
        }
    }
}
