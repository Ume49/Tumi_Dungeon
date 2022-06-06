using UnityEngine;

public class HP_Disp : MonoBehaviour {
    [SerializeField] private UnityEngine.UI.Text textbox;
    [SerializeField] Charactor_Paramater param;

    private void Update() {
        textbox.text = param.hp.ToString();
    }

    private void Reset() {
        textbox = GetComponent<UnityEngine.UI.Text>();
    }
}