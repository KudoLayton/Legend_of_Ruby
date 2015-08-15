using UnityEngine;
using System.Collections;

public class BulbShop : MonoBehaviour {

    public int bulbPrice;

    public void buyBulb() {
        GameObject[] lampPos = GameObject.Find("Player").GetComponent<Player>().lampPos;
        for (int i = 0; i < lampPos.Length; i++)
        {
            lampPos[i].SetActive(true);
            GameObject.Find("GameManager").GetComponent<GameManager>().money -= bulbPrice;
            GameObject.Find("GameManager").GetComponent<GameManager>().MoenyChange();
        }
    }
}
