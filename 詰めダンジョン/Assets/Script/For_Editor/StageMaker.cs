using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

// 自分が置かれている場所を0,0としていい感じにマップを生成する
public class StageMaker : MonoBehaviour
{
    [SerializeField] MAP map;
    [SerializeField] GameObject field_prefab;
    [SerializeField] Transform field_parent;
    [Header("setting")]
    [SerializeField] int width;
    [SerializeField] int height;
    [Range(0.0f, 1.0f)]
    [SerializeField] float make_rate;

    public void DestoryFieldChildren()
    {   // フィールドオブジェクトを全削除
        List<Transform> old_field = new List<Transform>();
        GetAllChildren.Get(field_parent, old_field);

        old_field.FindAll(x => x.childCount > 0).ForEach(x => DestroyImmediate(x.gameObject));
    }

    public void Make()
    {
        // リセット
        DestoryFieldChildren();

        // マスを配置する上での基準点を決定
        // マップで言うところの[0,0]に相当する場所
        Vector3 standerd_pos=transform.position;

        // とりあえず配置するマス目を生成
        foreach (var x in Enumerable.Range(0, width))
        {
            foreach (var y in Enumerable.Range(0, height))
            {
                // 設定した確率に従ってスキップ
                if (Random.Range(0.0f, 1.0f) >= make_rate) continue;

                // 座標を示す相対ベクトルを生成
                Vector3 current_pos = new Vector3(x * map.masume_distance, 0.0f, y * map.masume_distance);

                // 基準の座標ベクトルと合成してワールド座標にする
                current_pos += standerd_pos;

                // 生成
                GameObject instance = UnityEditor.PrefabUtility.InstantiatePrefab(field_prefab, field_parent) as GameObject;

                // 座標を設定
                instance.transform.position = current_pos;
            }
        }
    }
}
