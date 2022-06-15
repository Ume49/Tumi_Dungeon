using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Map_Changer : MonoBehaviour
{
    public enum Map_Kind
    {
        Field,
        Static,
        Dynamic
    }

    [SerializeField] GameObject field_map_gameobject;
    [SerializeField] GameObject static_map_gameobject;
    [SerializeField] GameObject dynamic_map_gameobject;

    [SerializeField] UnityEvent startup;

    void Start()
    {
        startup.Invoke();
    }

    void All_Off()
    {
        field_map_gameobject.SetActive(false);
        static_map_gameobject.SetActive(false);
        dynamic_map_gameobject.SetActive(false);
    }

    public void Field_On()
    {
        All_Off();

        field_map_gameobject.SetActive(true);
    }

    public void Stc_Map_On()
    {
        All_Off();

        static_map_gameobject.SetActive(true);
    }

    public void Dym_Map_On()
    {
        All_Off();

        dynamic_map_gameobject.SetActive(true);
    }
}
