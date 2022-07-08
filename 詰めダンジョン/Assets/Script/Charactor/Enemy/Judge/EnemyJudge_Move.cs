using UnityEngine;
using System.Collections.Generic;

public class EnemyJudge_Move : IEnemyJudgeComponent {
    [SerializeField] Transform player;

    [SerializeField] Movable_Checker checker;

    public override bool _judge() {
        // プレイヤーへの向きを取得
        var to_player = Vector3to2.xz_plane(player.position - transform.position);

        // 向きから進むべき方向を作成（先頭のものほど優先度が高い）
        List<Direction> move_candidate = Convert_Directioin_fromVector_witPriority(to_player);
        
        // 移動候補のうち不良品を弾く
        Delete_canntMoveCandidate(move_candidate);

        // 移動できないなら次に任せる
        if(move_candidate.Count <= 0) return false;

        // 移動候補のうち、先頭のものを投げて終わり
        base.action_executer.AddCommandQueue(new Command_Move(move_candidate[0], transform));

        return true;
    }

    // 作成した移動方向に実際に動けるのかチェックして、ダメな奴は削除する
    void Delete_canntMoveCandidate(List<Direction> candidate){
        List<Direction> has_delete = new List<Direction>();

        foreach(var d in candidate){
            var current_pos = base.position_onMap.value + Direciton_Table.Direction_To_Pos(d);

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

    // 目的地へのベクトルを方向に変換、おまけで優先度もつける
    // 優先度はより目的地に近づけるものほど低くなるように設定
    // {優先度高いやつ, 優先度低い奴}   * 前はタプルで優先度をintで付与していたが、格納順で表現できるじゃんってことで消した
    List<Direction> Convert_Directioin_fromVector_witPriority(Vector2 destinatino_vec){
        // 返却用のキュー
        List<Direction> result = new List<Direction>();
        
        // とりあえず渡されたベクトルを分解する
        // あと進行方向の大きさ(１)にそろえる
        Vector2 vec_x = new Vector2(destinatino_vec.x, 0).normalized;
        Vector2 vec_y = new Vector2(0, destinatino_vec.y).normalized;

        // その方向に移動した場合の目的地までの距離を求める 大きさの比較するだけなので平方根は使わない
        float x_mag = (destinatino_vec - vec_x).magnitude;
        float y_mag = (destinatino_vec - vec_y).magnitude;

        // x軸方向の方がより近づける場合 x,yの順番
        // 等価の場合はこっちにしておく（特に理由はない）
        if(x_mag >= y_mag){
            if(vec_x.x > 0) result.Add(Vec_to_Direction(vec_x.x, Axis.X));
            if(vec_y.y > 0) result.Add(Vec_to_Direction(vec_y.y, Axis.Y));
        }
        else{
            // y軸方向の方がより近づける場合は、y,xの順番
            if(vec_y.y > 0) result.Add(Vec_to_Direction(vec_y.y, Axis.Y));
            if(vec_x.x > 0) result.Add(Vec_to_Direction(vec_x.x, Axis.X));
        }

        return result;
    }

    private enum Axis{
        X,Y
    }

    // 方向ベクトルを方向に変換する
    // xまたはy軸に平行なベクトル前提で、X軸並行かY軸平行かと、ベクトルの大きさで表現
    private Direction Vec_to_Direction(float sqrtedmagnitude, Axis axis){
        #if UNITY_EDITOR
            if(sqrtedmagnitude == 0.0f) Debug.LogError("Vec_to_Directionに大きさ0を渡さないでください！");
        #endif

        switch(axis){
            case Axis.X:
                if(sqrtedmagnitude > 0){
                    return Direction.RIGHT;
                }
                else{
                    return Direction.LEFT;
                }
            case Axis.Y:
                if(sqrtedmagnitude > 0){
                    return Direction.UP;
                }
                else{
                    return Direction.DOWN;
                }
            default:
                #if UNITY_EDITOR
                    Debug.LogError("X軸でもY軸でもない値が渡されています!");
                #endif
                return Direction.UP;
        }
    }
}
