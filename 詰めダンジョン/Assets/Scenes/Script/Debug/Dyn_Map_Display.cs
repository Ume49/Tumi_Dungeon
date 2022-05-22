using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Dyn_Map_Display : MonoBehaviour
{
    [SerializeField] MAP map;
    [SerializeField] Text textbox;


    void Update()
    {
        textbox.text = "";

        foreach (var y in Enumerable.Range(0, map.dynamic_object_map.GetLength(1)))
        {
            foreach (var x in Enumerable.Range(0, map.dynamic_object_map.GetLength(0)))
            {
                // Nullが4文字なので名前も4文字だけ取り出す
                string t = (map.dynamic_object_map[x, y] == null) ? "Null" : map.dynamic_object_map[x, y].name.Substring(0, 4);

                textbox.text += t + " ";
            }
            textbox.text += "\n";
        }
    }
}
