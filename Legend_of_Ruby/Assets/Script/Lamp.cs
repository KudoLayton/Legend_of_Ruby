using UnityEngine;
using System.Collections;

public class Lamp : MonoBehaviour {
    ArrayList rayList;
    public float deltaT;
	// Use this for initialization
	void Start () {
        StartCoroutine(LifeTime());
        rayList = new ArrayList();
        int raynum = (int)(360 / deltaT);
        for (int i = 0; i < raynum; i++)
        {
            Ray2D ray = new Ray2D(gameObject.transform.position, new Vector2(DegSin(deltaT * i), DegCos(deltaT * i)));
            rayList.Add(ray);
        }
    }

    IEnumerator LifeTime() {
        yield return new WaitForSeconds(10f);
        Destroy(gameObject);
    }

    public void Search() {
        for (int i = 0; i < rayList.Count; i++) {
            RaycastHit2D[] hit = Physics2D.RaycastAll(((Ray2D)rayList[i]).origin,((Ray2D)rayList[i]).direction);
            //         Debug.Log("hit: "+ hit.Length);
            foreach (RaycastHit2D Hit in hit)
            {
                if (Hit.collider.tag == "obstacle")
                {
                    break;
                }
                else if (Hit.collider.tag == "Jar")
                {
                    Hit.collider.GetComponent<Jar>().update = true;
                    Hit.collider.GetComponent<Jar>().ForceUpdate();
                }
                else if (Hit.collider.name == "Hanning")
                {
                    Hit.collider.gameObject.GetComponent<Renderer>().enabled = true;
                }
            }
        }
    }


    float DegSin(float deg)
    {
        return Mathf.Sin(Mathf.PI * deg / 180);
    }

    float DegCos(float deg)
    {
        return Mathf.Cos(Mathf.PI * deg / 180);
    }
}
