using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Static_Map_Displayer : MonoBehaviour
{
    [SerializeField] Text textbox;
    [SerializeField] MAP map;
    void Update()
    {
        textbox.text = "";

        // Col_Map_Dispと同じ実装
        for (var y = map.static_object_map.GetLength(1)-1; y>=0; y--)
        {
            foreach (var x in Enumerable.Range(0, map.static_object_map.GetLength(0)))
            {
                // Nullが4文字なので名前も4文字だけ取り出す
                string t = (map.static_object_map[x, y] == null) ? "Null" : map.static_object_map[x, y].name.Substring(0, 4);

                textbox.text += t + " ";
            }
            textbox.text += "\n";
        }
    }
}
