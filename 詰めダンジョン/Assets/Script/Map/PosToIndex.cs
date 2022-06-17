using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ワールド座標からマップに対応するインデックスを計算して返すクラス
public class PosToIndex : MonoBehaviour
{
    [SerializeField] MAP map;

    public Vector2Int Get(Vector3 position)
    {
        // 基準点を取得
        Vector3 standerd_pos = map.standerd_position;

        // 変位ベクトルを計算
        Vector3 delta = position - standerd_pos;

        // 1マスの長さを取得
        float distance = map.masume_distance;

        // x,z成分を基準の長さで除算してインデックスを計算
        int x = (int)(delta.x / distance);
        int y = (int)(delta.z / distance);

        return new Vector2Int(x, y);
    }
}
