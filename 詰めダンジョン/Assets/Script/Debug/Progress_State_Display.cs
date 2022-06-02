using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Progress_State_Display : MonoBehaviour
{
    [SerializeField] Process_StateMachine target;
    [SerializeField] UnityEngine.UI.Text textbox;

    private void Reset()
    {
        textbox = GetComponent<UnityEngine.UI.Text>();
    }
    void Update()
    {
        textbox.text = target.state.ToString();
    }
}
