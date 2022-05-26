using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action_Controller : MonoBehaviour
{
    [SerializeField] List<Transform> enemies;

    private void OnEnable()
    {
        enemies = new List<Transform>();

        // 1段下の子要素を全て取得
        // *ターン経過ごとにエネミーの状況が変わっているので毎回取得し直す
        foreach (Transform w in transform)
        {
            enemies.Add(w);
        }
    }

    void Update()
    {

    }
}
