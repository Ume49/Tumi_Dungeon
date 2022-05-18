using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// シーンのオブジェクトからマップ情報を生成するクラス
public class MapGenereter : MonoBehaviour
{
    [SerializeField] MAP map_class;
    [SerializeField] IndexToPos index_to_pos;
    [SerializeField] PosToIndex pos_to_index;

    [Header("設定")]
    [SerializeField] string field_tag;
    [SerializeField] string dynamic_object_tag;
    [SerializeField] string static_object_tag;

    private void Awake()
    {
        // 子関係のオブジェクトを入れるリストを作成
        List<Transform> all_object = new List<Transform>();

        // 作成したリストに全て取得
        GetAllChildren.Get(transform, all_object);

        {   // 当たり判定マップを作成
            // 子オブジェクトから当たり判定に使用するものを抽出
            List<Transform> col_object = all_object.FindAll(x => x.CompareTag(field_tag));

            // 当たり判定用オブジェクトの座標から当たり判定マップを作成

            // マップを全て囲えるだけの矩形を作成
            (float min, float max) x, z;

            x.min = col_object.Min(x => x.position.x);
            x.max = col_object.Max(x => x.position.x);

            z.min = col_object.Min(x => x.position.z);
            z.max = col_object.Max(x => x.position.z);

            // マス目の単位を取得
            var distance = map_class.masume_distance;

            // マップ配列を初期化

            int height = (int)((z.max - z.min) / distance) + 1;
            int width = (int)((x.max - x.min) / distance) + 1;

            map_class.collider_map = new bool[width, height];

            // マップに基準点をセット
            map_class.standerd_position = new Vector3(x.min, 0.0f, z.max);

            // 中身をセット
            for (var ix = 0; ix < width; ix++)
            {
                for (var iy = 0; iy < height; iy++)
                {
                    // インデックスと対応する座標を取得
                    Vector3 current_pos = index_to_pos.Get(ix, iy);

                    // 対応する座標に床があるのか確認
                    bool result = col_object.Find(w =>
                    {
                        return
                            w.position.x == current_pos.x
                            &&
                            w.position.z == current_pos.z;
                    });

                    map_class.collider_map[ix, iy] = result;
                }

            }
        }

        // タグで抽出したオブジェクトを指定のマップの対応の位置に入れる関数 
        // *動的オブジェクトと静的オブジェクトでマップ生成処理がほぼ同じなので
        System.Action<string, Transform[,]> serch_and_assign = (string tag, Transform[,] map) =>
        {
            // 抽出
            List<Transform> current_object = all_object.FindAll(x => x.CompareTag(tag));

            // 当たり判定マップから大きさを引っ張ってきてマップを作成
            map = new Transform[map_class.collider_map.GetLength(0), map_class.collider_map.GetLength(1)];

            // 対応する位置に抽出したものを代入していく
            foreach (var w in current_object)
            {
                // 対応するインデックスを取得
                Vector2Int index = pos_to_index.Get(w.position);

                // 代入
                map[index.x, index.y] = w;

                // 現在位置をオブジェクトに覚えておいてもらう
                w.GetComponent<Now_Position_onMap>().index = index;
            }

        };

        // 動的オブジェクトマップを作成
        serch_and_assign(dynamic_object_tag, map_class.dynamic_object_map);

        // 静的オブジェクトマップを作成
        serch_and_assign(static_object_tag, map_class.static_object_map);
    }
}

