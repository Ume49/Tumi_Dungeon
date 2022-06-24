using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 優先度付きでエネミーの行動決定処理を呼ぶクラス
// リストの上から呼び出す
public class Enemy_Brain : MonoBehaviour {
    [SerializeField] List<IEnemyJudgeComponent> judge_components;
    public void Judge() {
        foreach(var component in judge_components){
            bool judge_finished = component._judge();

            // 行動は１ターンに１個しか行わないので、１つ決まったらそれで終了
            if(judge_finished) return;
        }
    }
}
