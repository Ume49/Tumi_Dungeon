using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Col_Map_Disp : MonoBehaviour
{
    [SerializeField] Text box;
    [SerializeField] MAP field_Map;
    void Update()
    {
        box.text = "";

        int map_height = field_Map.collider_map.GetLength(1);
        int map_width  = field_Map.collider_map.GetLength(0);
        
        
        // y軸は上から（添え字の大きい方から）見ていきたいので、降順で探索
        // 末尾の添え字は個数-1
        for (int y=map_height-1; y>=0; y-- )
        {
            string result = "";
        // x軸は右から（添え字の小さい方から）見ていきたいので、昇順で探索
            foreach (var x in Enumerable.Range(0, map_width))
            {
                result += field_Map.collider_map[x, y] ? "1 " : "0 ";
            }
            result += "\n";
            box.text += result;
        }
    }
}
