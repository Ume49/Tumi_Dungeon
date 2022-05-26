using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemyJudge : MonoBehaviour
{
    [SerializeField] protected MAP map;
    [SerializeField] protected Now_Position_onMap index_position;
    virtual public void Judge() { }

    private void Reset()
    {
        index_position = GetComponent<Now_Position_onMap>();

        // MAPは全オブジェクトから検索して代入
        var objects = Resources.FindObjectsOfTypeAll<GameObject>();

        // 取得した奴らから全検索
        foreach (var w in objects)
        {
            if (w.transform.TryGetComponent<MAP>(out map)) break;
        }
    }
}
