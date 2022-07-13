using UnityEngine;
using System.Collections.Generic;

public class EnemyJudge_Move : IEnemyJudgeComponent {
    [SerializeField] Transform player;

    [SerializeField] Movable_Checker checker;

    public override bool _judge() {
        // TODO なぜか左下側へ移動しようとしないので、その辺修正する

        // プレイヤーへのベクトルを取得
        var to_player = Vector3to2.xz_plane(player.position - transform.position);

        // 向きから進むべき方向を作成（先頭のものほど優先度が高い）
        List<Direction> move_candidate = Convert_Directioin_fromVector_witPriority(to_player);

        foreach(var w in move_candidate){
            // 先頭からチェックして移動できるやつを投げて終了
            
            // 仮に移動するとしたらこの座標
            Vector2Int current_dest = base.position_onMap.value + Direciton_Table.Direction_To_Pos(w);

            if(checker.Check(current_dest) == false) continue;  // 移動できないならこの移動候補はスキップ

            base.action_executer.AddCommandQueue(new Command_Move(w, transform));
            return true;
        }

        // たどり着いた=移動できない のでfalse投げて終わり
        return false;
    }

    // 目的地へのベクトルを方向に変換、おまけで優先度もつける
    // 優先度はより目的地に近づけるものほど低くなるように設定
    // {優先度高いやつ, 優先度低い奴}   * 前はタプルで優先度をintで付与していたが、格納順で表現できるじゃんってことで消した
    List<Direction> Convert_Directioin_fromVector_witPriority(Vector2 destinatino_vec){
        // 返却用のリスト
        List<Direction> result = new List<Direction>();
        
        // ベクトルのx成分とy成分を比較
        // 大きい方を優先度高いようにして作る
        // 成分の大きさが0ならそもそも追加しない
        if(destinatino_vec.x >= destinatino_vec.y){
            // x軸先
            if(destinatino_vec.x != 0.0f) result.Add(JudgePlusORMinus(destinatino_vec.x, Direction.RIGHT, Direction.LEFT));
            if(destinatino_vec.y != 0.0f) result.Add(JudgePlusORMinus(destinatino_vec.y, Direction.UP, Direction.DOWN));
        }
        else{
            // y軸先
            if(destinatino_vec.y != 0.0f) result.Add(JudgePlusORMinus(destinatino_vec.y, Direction.UP, Direction.DOWN));
            if(destinatino_vec.x != 0.0f) result.Add(JudgePlusORMinus(destinatino_vec.x, Direction.RIGHT, Direction.LEFT));
        }

        return result;
    }

    // 渡された値が正ならplus_resultを、負ならminus_resultを返す
    Direction JudgePlusORMinus(float judge_param, Direction plus_result, Direction minus_result){
        #if UNITY_EDITOR
            if(judge_param==0){
                Debug.Log("正か負か判定する関数に0を渡さないでください！");
            }
        #endif
        
        if (judge_param >= 0){
            return plus_result;
        }else{
            return minus_result;
        }
    }
}
