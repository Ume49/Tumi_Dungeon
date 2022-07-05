using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IReverseAction : MonoBehaviour
{
    ///<summary> シーン上の動きを実装する処理、終了したらtrueを返す</summary>
    public abstract bool _update();

    static public IReverseAction Get_ReverseAction_fromReverseCommand(IReverseCommand r){
        // コマンドから適切なアクションクラスを取得して返す
        // あとアクションクラスに各種データを設定 *その都合でダウンキャストする
        switch(r.id){
            case IReverseCommand.ID.Move:
            {
                var r_move      = r.target_chara.GetComponent<R_Move>();
                var _command    = (Rcommand_Move)r;

                r_move.SetDestination(_command.end_pos);

                return r_move;
            }
            case IReverseCommand.ID.Attack:
            {
                var r_heal      = r.target_chara.GetComponent<R_Heal>();
                var _command    = (Rcommand_Attack)r;

                r_heal.heal_point = _command.heal_point;
                
                return r_heal;
            }
            case IReverseCommand.ID.Death:
            {
                var r_revive = r.target_chara.GetComponent<R_Revive>();
                
                // 特に設定する項目がないのでここは少ない
                return r_revive;
            }
            case IReverseCommand.ID.Pickup:
            {
                // TODO : PickUp関連作ったらここも作る
                
                Debug.LogError("未完成の部分を呼び出しています！");
                return null;
            }
            case IReverseCommand.ID.Front:
            {
                var r_front = r.target_chara.GetComponent<R_FrontChange>();

                r_front.has_chage_front_direction = ((Rcommand_Front)r).has_front;

                return r_front;
            }
            default:
                Debug.LogError("不正なReverseCommandが渡されています！");
            return null;
        }
    }
}
