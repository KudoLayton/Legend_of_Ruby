using UnityEngine;
using System.Collections;

public class SunMoving : MonoBehaviour {

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("time: "+Time.timeSinceLevelLoad);
        if (Time.timeSinceLevelLoad < 30f)
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(-482f + (482f * 2 / 30f * Time.timeSinceLevelLoad), -249f, 0f);
        else
            gameObject.GetComponent<RectTransform>().localPosition = new Vector3(482f, -249f);
    }
}
