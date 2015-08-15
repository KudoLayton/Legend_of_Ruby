using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int numJar;
    public Texture2D lampImg;
    public bool addlamp;
    public GameObject jar;
    public GameObject lamp;
    public ArrayList jarList;
    public ArrayList lampList;

    // Use this for initialization
    void Start()
    {
        jarList = new ArrayList();
        lampList = new ArrayList();
        addlamp = false;
        for (int i = 0; i < numJar; i++)
        {
            GameObject newjar = (GameObject)Instantiate(jar, new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f)), Quaternion.identity);
            jarList.Add(newjar);
        }
    }

    public void AddLamp()
    {
        Cursor.SetCursor(lampImg, Vector2.zero, CursorMode.Auto);
        addlamp = true;

    }

    public void JarReset()
    {
        for (int i = 0; i < jarList.Count; i++)
        {
            if (jarList[i] == null)
            {
                jarList.Remove(i);
            }
            try
            {
                ((GameObject)jarList[i]).GetComponent<Jar>().update = false;
            }
            catch (MissingReferenceException e)
            {

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
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
}
