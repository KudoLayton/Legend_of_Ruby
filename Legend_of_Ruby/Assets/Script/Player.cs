using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public Light light;
    public float deltaT;
    public float range;
    public float rotationSpeed;
    
    public bool addlamp;
    public GameObject lamp;
    public Texture2D lampImg;

    ArrayList rayList;
    ArrayList lampList;

    
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

        lampList = new ArrayList();
        addlamp = false;
	}

    public void AddLamp()
    {
        Cursor.SetCursor(lampImg, Vector2.zero, CursorMode.Auto);
        addlamp = true;

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

        for (int i = 0; i < lampList.Count; i++)
        {
            Collider2D[] hit = Physics2D.OverlapCircleAll(((GameObject)lampList[i]).GetComponent<Transform>().position, ((GameObject)lampList[i]).GetComponent<Light>().range);
            foreach (Collider2D Hit in hit)
            {
                if (Hit.tag == "obstacle")
                    break;
                Hit.GetComponent<Jar>().update = true;
            }
        }
        if (addlamp)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject newlamp = (GameObject)Instantiate(lamp, new Vector3(hit.point.x, hit.point.y, -((float)2 / 10)), Quaternion.identity);
                    lampList.Add(newlamp);
                    Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
                    addlamp = false;
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
}
