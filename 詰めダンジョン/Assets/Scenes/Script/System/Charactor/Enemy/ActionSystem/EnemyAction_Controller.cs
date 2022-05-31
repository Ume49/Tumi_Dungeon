using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction_Controller : MonoBehaviour
{
    [SerializeField] Process_StateMachine state;

    private void OnEnable()
    {
        // 1段下の子要素からエネミーの情報を全部取得
        // 1ターンごとにエネミーの状況が変わっているため毎回取得し直す
        foreach (Transform w in transform)
        {
            var judge = w.GetComponent<IEnemyJudge>();

            judge.Judge();
        }

        state.Set_NextState();
    }
}
