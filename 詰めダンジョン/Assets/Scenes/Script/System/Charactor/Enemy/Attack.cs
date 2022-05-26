using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EnemyJudge
{
    delegate Transform Map_Func(int x, int y);

    public class Attack : IEnemyJudge
    {
        [SerializeField] string player_name;
        public override void Judge()
        {
            // プレイヤーが隣接しているなら攻撃
            List<Transform> neighbor = new List<Transform>();

            // 相対的なオブジェクトを参照するラムダ式
            Map_Func obj = (delta_x, delta_y) => map.dynamic_object_map[index_position.index.x + delta_x, index_position.index.y + delta_y];

            // とりあえず隣接している動的オブジェクトを取得
            neighbor.Add(obj(-1, 0));
            neighbor.Add(obj(+1, 0));
            neighbor.Add(obj(0, -1));
            neighbor.Add(obj(0, +1));

            // 攻撃したい奴が近くにいるか
            bool is_on_target = false;

            // プレイヤーがいるか検索して、いたら追加処理
            // 判定方法はtransform.nameの一致
            foreach (var w in neighbor)
            {
                if (w.name == player_name)
                {
                    // 攻撃対象確定したので攻撃処理予約

                    // 攻撃するのでtrue代入
                    is_on_target = true;
                }
            }

            if (is_on_target == false)
            {
                // 攻撃したいやつがいないので待機処理予約
            }
        }
    }
}
