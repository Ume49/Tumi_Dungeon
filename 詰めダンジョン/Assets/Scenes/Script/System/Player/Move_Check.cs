using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Check : MonoBehaviour
{
    [SerializeField] Transform player_chara;
    void Start()
    {

    }

    void Update()
    {
        var input_result = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        // 何もないなら以降の処理はスキップ
        if (input_result.x == 0.0f && input_result.y == 0.0f) return;

        // 目的地を計算

        // 移動ベクトルを取得

    }
}
