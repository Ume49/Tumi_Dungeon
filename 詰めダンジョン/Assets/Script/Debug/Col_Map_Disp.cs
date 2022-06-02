using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Col_Map_Disp : MonoBehaviour
{
    [SerializeField] Text box;
    [SerializeField] MAP field_Map;
    void Start()
    {
        box.text = "";

        for (int y = 0; y < field_Map.collider_map.GetLength(1); y++)
        {
            string result = "";

            for (int x = 0; x < field_Map.collider_map.GetLength(0); x++)
            {
                result += field_Map.collider_map[x, y] ? "1 " : "0 ";
            }
            result += "\n";
            box.text += result;
        }
    }
}
