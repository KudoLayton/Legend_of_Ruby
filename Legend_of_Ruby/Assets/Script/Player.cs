using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Light light;
    public float deltaT;
    public float range;
    public float rotationSpeed;
    ArrayList rayList;

    ArrayList circleList;

    public GameObject lamp;
    ArrayList lampList;
    public GameObject[] lampPos;

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
        circleList = new ArrayList();
        lampList = new ArrayList();
        lampPos = GameObject.FindGameObjectsWithTag("position");
        for (int i = 0; i < lampPos.Length; i++)
        {
            lampPos[i].SetActive(false);
        }
	}
	
	// Update is called once per frame
	void Update () {
        GameObject.Find("GameManager").GetComponent<GameManager>().JarReset();
        GameObject.Find("Hanning").GetComponent<Renderer>().enabled = false;

        //Lamb
        /*
        for (int i = 0; i < circleList.Count; i++)
        {
            RaycastHit2D[] hit = Physics2D.RaycastAll(((Ray2D)circleList[i]).origin, AddAngle(((Ray2D)circleList[i]).direction, gameObject.transform.rotation.eulerAngles.z));
            foreach (RaycastHit2D Hit in hit)
            {
                if (Hit.collider.tag == "obstacle")
                    break;
                if (Hit.collider.tag == "Jar")
                {
                    Hit.collider.gameObject.GetComponent<Jar>().update = true;
                    Hit.collider.GetComponent<Jar>().ForceUpdate();
                }
                else if (Hit.collider.name == "Hanning")
                {
                    Hit.collider.gameObject.GetComponent<Renderer>().enabled = false;
                }
            }
        }*/
        for(int i =0;i<lampList.Count;i++)
        {
            ((GameObject)lampList[i]).GetComponent<Lamp>().Search();
        }
        //     Debug.Log("ray count: " + rayList.Count);
        for (int i = 0; i < rayList.Count; i++) {
            RaycastHit2D[] hit = Physics2D.RaycastAll(((Ray2D)rayList[i]).origin, AddAngle(((Ray2D)rayList[i]).direction, gameObject.transform.rotation.eulerAngles.z));
   //         Debug.Log("hit: "+ hit.Length);
            foreach (RaycastHit2D Hit in hit) {
                if (Hit.collider.tag == "obstacle")
                {
                    break;
                }
                else if (Hit.collider.tag == "Jar")
                {
                    if (Hit.collider.gameObject != null)
                    {
                        Hit.collider.GetComponent<Jar>().update = true;
                        //Hit.collider.GetComponent<Jar>().ForceUpdate();
                    }
                }
                else if (Hit.collider.name == "Hanning") {
                    Hit.collider.gameObject.GetComponent<Renderer>().enabled = true;
                }
                    
            }
        }
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.Rotate(new Vector3(0f, 0f, -rotationSpeed));
        else if (Input.GetKey(KeyCode.A))
            gameObject.transform.Rotate(new Vector3(0f, 0f, rotationSpeed));

        OnLight();
    }

    public void OnLight()
    {
        GameObject[] lampPos = (GameObject[])GameObject.FindGameObjectsWithTag("position").Clone();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null)
            {
                for (int i = 0; i < lampPos.Length; i++)
                    if (hit.collider.gameObject == lampPos[i])
                    {
                        GameObject newlamp = (GameObject)Instantiate(lamp, new Vector3(lampPos[i].transform.position.x, lampPos[i].transform.position.y, -((float)2 / 10)), Quaternion.identity);
                        lampList.Add(newlamp);
                        for (int j = 0; j < lampPos.Length; j++)
                        {
                            lampPos[i].SetActive(false);
                        }

                        break;
                    }
            }
        }
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

    public void AddLamp()
    {
        GameObject[] lampPos = GameObject.FindGameObjectsWithTag("position");
        for (int i = 0; i < lampPos.Length;i++ )
        {
            lampPos[i].SetActive(true);
        }
    }
}
