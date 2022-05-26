using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAction_Controller : MonoBehaviour
{
    [SerializeField] List<IEnemyJudge> enemies;

    private void OnEnable()
    {
        enemies = new List<IEnemyJudge>();

        // 1段下�?�子要�?を�?�て取�?
        // *ターン経過ごとにエネミーの状況が変わって�?る�?�で毎回取得し直�?
        foreach (Transform w in transform)
        {

        }
    }

    void Update()
    {

    }
}
