using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Judge_Executer : MonoBehaviour
{
    [SerializeField] Process_StateMachine state;

    void OnEnable() {
        // 子関係にあるエネミー達に思考させる
        foreach (Transform w in transform) {
            var brain = w.GetComponent<Enemy_Brain>();

            brain.Judge();
        }

        state++;
    }
}
