using UnityEngine;
using System.Collections.Generic;

public class EnemyJudge_Move : IEnemyJudgeComponent {
    [SerializeField] Transform player;

    [SerializeField] Movable_Checker checker;
    [SerializeField] CurrentPosition_OnMap own_pos;

    public override bool _judge() {
        // プレイヤーへの向きを取得
        var to_player = Vector3to2.xz_plane(player.position - transform.position);

        // 向きから進むべき方向を作成
        List<Direction> move_candidate = new List<Direction>(); // 移動候補
        Vector2_to_Direction.Convert_AddList(to_player, move_candidate);

        // 移動候補のうち不良品を弾く
        Delete_canntMoveCandidate(move_candidate);

        // 移動できないなら次に任せる
        if(move_candidate.Count <= 0) return false;

        // もう１個しか移動候補が残ってないならそこに移動するコマンドを投げて終わり
        if(move_candidate.Count == 1){
            base.action_executer.AddCommandQueue(new Command_Move(move_candidate[0], transform));
            return true;
        }

        // 移動候補が２つあるなら一意に決定する
        {   // より直線距離を小さくできる方に動く（斜めっぽく動く）
            
        }
        {   // 等価な選択肢は適当に決定する

        }

        Debug.LogError("エネミーの移動アルゴリズムに足りていない部分があります！");

        // TODO: 移動先を考えて移動を決定、決定できた場合はtrueを返してできなかった場合はfalseを返す
        return false;
    }

    // 作成した移動方向に実際に動けるのかチェックして、ダメな奴は削除する
    void Delete_canntMoveCandidate(List<Direction> candidate){
        List<Direction> has_delete = new List<Direction>();

        foreach(var d in candidate){
            var current_pos = own_pos.value + Direciton_Table.Direction_To_Pos(d);

            if(checker.Check(current_pos) == false){
                // 削除すべき要素をメモ
                has_delete.Add(d);
            }
        }

        // メモした要素を削除 *わざわざこんなまどろっこしい処理をするのは、foreachの中でそのリストの要素の場所を変更するとぶっ壊れてしまうため
        foreach(var w in has_delete){
            candidate.Remove(w);
        }
    }
}
