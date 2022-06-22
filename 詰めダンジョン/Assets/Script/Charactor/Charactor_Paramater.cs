using UnityEngine;

// エネミーやプレイヤーが共通して持つ値、HPなど
public class Charactor_Paramater : MonoBehaviour {
    public int hp;
    public int deffence;
    public int attak;

    public void Damage(int damage) {
        hp -= damage;
    }
}