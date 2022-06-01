using UnityEngine;

public abstract class IEnemyJudge : MonoBehaviour {
    [SerializeField] protected MAP map;
    [SerializeField] protected Now_Position_onMap index_position;

    public abstract void Judge();

    private void Reset() {
        index_position = GetComponent<Now_Position_onMap>();

        map = Resources.FindObjectsOfTypeAll<MAP>()[0];
    }
}