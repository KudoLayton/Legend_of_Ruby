using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int jarMax;
    public GameObject jar;
    public Transform[] startPosition;

	// Use this for initialization
	void Start () {
        jarSpawn();
    }

    void jarSpawn()
    {
        for (int i = 0; i < jarMax; i++)
        {
            Instantiate(jar, startPosition[i].position, Quaternion.identity);
            //Jar temp = (Jar)Instantiate(jar, transform.position, Quaternion.identity);
            //temp.setID(i);
        }
    }
	
    // Update is called once per frame
	void Update () {
	
	}
}
