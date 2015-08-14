using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Light light;
    public float deltaT;
    public float range;
    public float rotationSpeed;
    ArrayList rayList;
	// Use this for initialization
	void Start () {
        rayList = new ArrayList();
        light = gameObject.GetComponentInChildren<Light>();
        {
            int raynum = (int)(light.spotAngle / 2 / deltaT);
            for (int i = 0; i < raynum+1; i++)
            {
                Ray2D ray_0 = new Ray2D(gameObject.transform.position, new Vector2(-DegSin(deltaT*i), DegCos(deltaT*i)));
                rayList.Add(ray_0);
                if (i == 0)
                    continue;
                Ray2D ray_1 = new Ray2D(gameObject.transform.position, new Vector2(DegSin(deltaT * i), DegCos(deltaT * i)));
                rayList.Add(ray_1);
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("GameManager").GetComponent<GameManager>().JarReset();
        Debug.Log("ray count: " + rayList.Count);
        for (int i = 0; i < rayList.Count; i++) {
            RaycastHit2D[] hit = Physics2D.RaycastAll(((Ray2D)rayList[i]).origin, AddAngle(((Ray2D)rayList[i]).direction, gameObject.transform.rotation.eulerAngles.z));
            Debug.Log("hit: "+ hit.Length);
            foreach (RaycastHit2D Hit in hit) {
                if (Hit.collider.tag == "obstacle")
                {
                    break;
                }
                Hit.collider.GetComponent<Jar>().update = true;
            }
        }
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
        else if (Input.GetKey(KeyCode.D))
            gameObject.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));
    }

    Vector2 AddAngle(Vector2 original, float angle) {
        return new Vector2(original.x*DegCos(angle)-original.y*DegSin(angle), original.x*DegSin(angle)+original.y*DegCos(angle));
    }

    float DegSin(float deg) {
        return Mathf.Sin(Mathf.PI * deg / 180);
    }

    float DegCos(float deg) {
        return Mathf.Cos(Mathf.PI * deg / 180);
    }
}
