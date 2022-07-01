using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IReverseCommand
{
    public enum ID{
        Move,
        Attack,
        Death,
        Pickup
    }
    public ID id;
    public Transform target_chara;

    public IReverseCommand(ID iD, Transform target){
        this.id             = iD;
        this.target_chara   = target;
    }

    static public IReverseCommand Make_RCommand(IHistory history){
        switch(history.id){
            case IHistory.ID.Move:
            {
                return new Rcommand_Move();
            }
            case IHistory.ID.Attack:
            {
                return new Rcommand_Attack(history.target_charactor);
            }
            case IHistory.ID.Pickup:
            {
                return new Rcommand_Pickup();
            }
            case IHistory.ID.Deth:
            {
                return new Rcommand_Death();
            }
            default:
                // 前caseですべての処理が終わるはずなのでここに到達する時点でエラー
                Debug.LogError("ReverseCommandを作成する上でのエラー：渡されたHistroyのIDが不正です");

                // 無害な0ダメージ履歴を返しておく
                return new Rcommand_Attack(null, 0);
        }
    }
}
