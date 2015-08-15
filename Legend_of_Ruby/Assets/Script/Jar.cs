using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {
    public int duration;
    public bool update;
    public Sprite shrimp;
    public Sprite poka;
    public Sprite fruit;
    public float level_1;
    public float level_2;
    public float level_3;

	// Use this for initialization
	void Start () {
        update = false;

	}
	
	// Update is called once per frame
	void Update () {
        if (update) {
            switch (duration) {
                case 3:
                    gameObject.GetComponent<SpriteRenderer>().sprite = shrimp;
                    break;
                case 2:
                    gameObject.GetComponent<SpriteRenderer>().sprite = poka;
                    break;
                case 1:
                    gameObject.GetComponent<SpriteRenderer>().sprite = fruit;
                    break;
                default:
                    Destroy(gameObject);
                    break;
            }
        }
	}

    public IEnumerator Hold(GameObject link) {
        switch (duration) {
            case 3:
                yield return new WaitForSeconds(level_1);
                if (!link.GetComponent<JeldaAI>().freeze)
                {
                    duration--;
                    link.GetComponent<JeldaAI>().status = true;
                }   
                break;
            case 2:
                yield return new WaitForSeconds(level_2);
                if (!link.GetComponent<JeldaAI>().freeze) {
                    duration--;
                    link.GetComponent<JeldaAI>().status = true;
                }
                break;
            case 1:
                yield return new WaitForSeconds(level_3);
                if (!link.GetComponent<JeldaAI>().freeze)
                {
                    duration--;
                    GameObject.Find("GameManager").GetComponent<GameManager>().MentalDeal();
                    GameObject.Find("GameManager").GetComponent<GameManager>().MoneyDeal();
                    Destroy(gameObject);
                    link.GetComponent<JeldaAI>().status = true;
                }
                break;
            default:
                break;
        }
    }
}
