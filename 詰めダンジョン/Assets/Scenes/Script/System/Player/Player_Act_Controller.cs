using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Act_Controller : MonoBehaviour
{
    public enum Act
    {
        Move,
        Attack
    }

    [SerializeField] List<Act> next_action;
    public Vector2Int destination;
    public void Set_NextAction(Act actiton)
    {
        next_action.Add(actiton);
    }
}
