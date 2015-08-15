using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public int numJar;
    public GameObject jar;
    public ArrayList jarList;
    
    // Use this for initialization
    void Start()
    {
        jarList = new ArrayList();
        for (int i = 0; i < numJar; i++)
        {
            GameObject newjar = (GameObject)Instantiate(jar, new Vector2(Random.Range(-15f, 15f), Random.Range(-8f, 8f)), Quaternion.identity);
            jarList.Add(newjar);
        }

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
    }
}
