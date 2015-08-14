using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {
    public int duration;
    public bool update;
    public Sprite shrimp;
    public Sprite poka;
    public Sprite fruit;

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
}
