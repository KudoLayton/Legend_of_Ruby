using UnityEngine;
using System.Collections;

public class BakkasShop : MonoBehaviour {
    public int bakkasPrice;
    public int bakkasEffect;

    public void BuyBakkas() {
        GameObject gameManager = GameObject.Find("GameManager");
        gameManager.GetComponent<GameManager>().money -= bakkasPrice;
        StartCoroutine(gameManager.GetComponent<GameManager>().MoenyChange());
        gameManager.GetComponent<GameManager>().mental += bakkasEffect;
        if (gameManager.GetComponent<GameManager>().mental > gameManager.GetComponent<GameManager>().totalMental)
            gameManager.GetComponent<GameManager>().mental = gameManager.GetComponent<GameManager>().totalMental;
        StartCoroutine(gameManager.GetComponent<GameManager>().MentalChange());
    }
}
