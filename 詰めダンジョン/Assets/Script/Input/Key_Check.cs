using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key_Check : MonoBehaviour
{
    [System.Serializable]
    public class Key_Event{
        public KeyCode key;
        public UnityEvent event_onkeypush;
    }

    [SerializeField] List<Key_Event> events;

    void Update()
    {
        // 関数呼び出しチェック
        foreach(var list_element in events) {
            if(Input.GetKeyDown(list_element.key)) {
                list_element.event_onkeypush.Invoke();
            }
        }
    }
}
