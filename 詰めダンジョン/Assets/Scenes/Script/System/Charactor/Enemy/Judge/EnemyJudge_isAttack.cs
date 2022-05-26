using System.Collections;
using System.Collections.Generic;
using UnityEngine;

delegate Transform Map_Func(int x, int y);

public class EnemyJudge_isAttack : IEnemyJudge
{
    [SerializeField] EnemyAction_Operator enemyaction_operator;
    [SerializeField] Attack attack_script;
    [SerializeField] string player_name;
    public override void Judge()
    {
        // 隣接オブジェクトを取得するリスト
        List<Transform> neighbor = new List<Transform>();

        // 相対的な位置のマップ情報を取得するラムダ式
        Map_Func obj = (delta_x, delta_y) => map.dynamic_object_map[index_position.index.x + delta_x, index_position.index.y + delta_y];

        // ４方の隣接したオブジェクトを取得
        neighbor.Add(obj(-1, 0));
        neighbor.Add(obj(+1, 0));
        neighbor.Add(obj(0, -1));
        neighbor.Add(obj(0, +1));

        // 取得したオブジェクトからプレイヤーを探索
        // プレイヤーの判別方法はtransform.nameの一致
        foreach (var w in neighbor)
        {
            if (w.name == player_name)
            {
                // プレイヤーを見つけたなら攻撃予約

                return;
            }
        }
    }
}

