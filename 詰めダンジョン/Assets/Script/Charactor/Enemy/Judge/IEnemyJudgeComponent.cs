using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IEnemyJudgeComponent : MonoBehaviour , ISingletonAttach , IBroComponent_Attach
{
    [SerializeField] protected MAP map;
    [SerializeField] protected CurrentPosition_OnMap position_onMap;
    [SerializeField] protected Enemy_Action_Executer action_executer;

    /// <summary> 行動を決定できたならtrueを返す </summary>
    public abstract bool _judge();

    public void Singleton_Attach(){
        map             = Resources.FindObjectsOfTypeAll<MAP>()[0];
        action_executer = Resources.FindObjectsOfTypeAll<Enemy_Action_Executer>()[0];
    }

    public void Brother_Attach(){
        position_onMap = GetComponent<CurrentPosition_OnMap>();
    }
}
