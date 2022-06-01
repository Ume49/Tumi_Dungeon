using UnityEngine;

public class T_Count_Display : MonoBehaviour {
    [SerializeField] private Turn_Counter counter_ref;
    [SerializeField] private UnityEngine.UI.Text text;

    // Update is called once per frame
    private void Update() {
        text.text = counter_ref.turn_limit.ToString();
    }
}