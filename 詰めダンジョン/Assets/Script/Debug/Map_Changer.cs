using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map_Changer : MonoBehaviour
{
    public enum Map_Kind
    {
        Field,
        Static,
        Dynamic
    }

    GameObject field_map_gameobject;
    GameObject static_map_gameobject;
    GameObject dynamic_map_gameobject;

    public void Map_Change(Map_Kind kind)
    {
        field_map_gameobject.SetActive(false);
        static_map_gameobject.SetActive(false);
        dynamic_map_gameobject.SetActive(false);

        switch (kind)
        {
            case Map_Kind.Field:
                field_map_gameobject.SetActive(true);
                break;
            case Map_Kind.Static:
                static_map_gameobject.SetActive(true);
                break;
            case Map_Kind.Dynamic:
                dynamic_map_gameobject.SetActive(true);
                break;
        }
    }
}
