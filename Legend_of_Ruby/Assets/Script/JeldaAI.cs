using UnityEngine;
using System.Collections;

public class JeldaAI : MonoBehaviour {

    public GameObject manager;
    public GameObject target;
    public bool status;
    public int static1;
    public int static2;

	// Use this for initialization
	void Start () {
        static1 = 10;
        static2 = 2;	
	}
	
	// Update is called once per frame
	void Update () {
        if (status == true)
        {
            ArrayList jarList = manager.GetComponent<GameManager>().jarList;
            int[] priList = new int[10];
            int[] genList = new int[10];
            int last = 0;
            for(int i = 0; i < 10; i++)
            {
                priList[i] = 0;
                genList[i] = 0;
            }
            for (int i = 0; i < 10 && ((GameObject)jarList[i]); i++)
            {
                if (!((GameObject)jarList[i]).GetComponent<Jar>().update)
                {
                    priList[i] += static1;
                }
                priList[i] += Mathf.RoundToInt((18 - (((GameObject)jarList[i]).GetComponent<Transform>().position - transform.position).magnitude)/static2) + priLevel(((GameObject)jarList[i]));
                if(i == 0)
                {
                    genList[i] = priList[i];
                }
                else
                {
                    genList[i] = priList[i] + genList[i - 1];
                }
                last = genList[i];
            }
            int rand = Random.Range(1,last+1);
            int a = 0;
            while(true)
            {
                if(rand < genList[a])
                {
                    target = ((GameObject)jarList[a]);
                    break;
                }
                a++;
            }
        }

	
	}
    public int priLevel(GameObject jar)
    {
        switch (jar.GetComponent<Jar>().duration)
        {
            case 1:
                return 6;
            case 2:
                return 3;
            case 3:
                return 2;
            default:
                return 0;
        }
    }
}
