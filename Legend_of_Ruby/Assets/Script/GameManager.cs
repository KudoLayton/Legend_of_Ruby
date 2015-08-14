using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int jarMax;
    public GameObject jar;
    // public Vector2[] startPosition;

	// Use this for initialization
	void Start () {
        Spawn();
    }

    void Spawn()
    {
        for (int i = 0; i < jarMax; i++)
        {
            transform.position = new Vector2(Random.Range(0, 5), Random.Range(0, 10));
            GameObject temp = (GameObject)Instantiate(jar, transform.position, Quaternion.identity);
            temp.name = "jar" + i;
            //Jar temp = (Jar)Instantiate(jar, transform.position, Quaternion.identity);
            //Instantiate(jar, startPosition[i], Quaternion.identity); 
            //temp.setID(i);
        }
    }
	
    // Update is called once per frame
	void Update () {
	
	}
}
