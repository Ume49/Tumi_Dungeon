using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyJudge_isAttack : IEnemyJudgeComponent
{
    [SerializeField] string player_name;
    
    public override bool _judge()
    {
        // 隣接オブジェクトを取得するリスト
        List<(Transform t, Direction direction)> neighbor = new List<(Transform, Direction)>();

        // 方向から隣接オブジェクトを取得・追加するラムダ式
        System.Action<Direction> neighbor_add = (d)=>{
            Vector2Int delta = Direciton_Table.Direction_To_Table(d);
            
            int x = position_onMap.value.x + delta.x;
            int y = position_onMap.value.y + delta.y;

            Transform obj = map.dynamic_object_map[x,y];

            neighbor.Add((obj, d));
        };

        // ４方の隣接したオブジェクトを取得
        neighbor_add(Direction.UP);
        neighbor_add(Direction.RIGHT);
        neighbor_add(Direction.DOWN);
        neighbor_add(Direction.LEFT);

        // 取得したオブジェクトからプレイヤーを探索
        // プレイヤーの判別方法はtransform.nameの一致
        foreach (var w in neighbor)
        {
            // ヌル参照ガード
            if(w.t == null) continue;
            
            if (w.t.name == player_name)
            {      
                // プレイヤーを見つけたなら攻撃予約
                base.action_executer.AddCommandQueue(new Command_Attack(transform, w.direction));

                return true;
            }
        }

        // ここに到達できたら攻撃できないということなので、次の判断クラスに任せる
        return false;
    }
}

