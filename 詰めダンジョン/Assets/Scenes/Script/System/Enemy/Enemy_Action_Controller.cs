using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Action_Controller : MonoBehaviour
{
    [SerializeField] List<Transform> enemies;

    private void Awake()
    {
        // enable=falseの時でも呼ばれるっぽい

        // 1段下の子要素を全て取得
        foreach (Transform w in transform)
        {
            enemies.Add(w);
        }
    }
    void Start()
    {

    }

    private void OnEnable()
    {

    }

    void Update()
    {

    }
}
