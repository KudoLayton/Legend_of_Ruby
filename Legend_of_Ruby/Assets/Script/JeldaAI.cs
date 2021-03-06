﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class JeldaAI : MonoBehaviour {

    public GameObject manager;
    public GameObject target;
    public Sprite normalSprite;
    public Sprite freezeSprite;
    public bool status;
    public int static1;
    public int static2;
    public bool freeze;
    public bool freezeState;
    public float freezeTime;
    public int zeldaPrize;
    float z;

	// Use this for initialization
	void Start () {
        static1 = 10;
        static2 = 2;
        status = true;
        freeze = false;
        z = gameObject.transform.position.z;
    }
	
	// Update is called once per frame
	void Update () {
        manager.GetComponent<GameManager>().JarReset();
        if ((status && !freeze) || (freeze && freezeState))
        {
            freeze = false;
            freezeState = false;
            gameObject.GetComponent<SpriteRenderer>().sprite = normalSprite;
            ArrayList jarList = manager.GetComponent<GameManager>().jarList;
            int[] priList = new int[10];
            int[] genList = new int[10];
            int last = 0;
            for(int i = 0; i < 10; i++)
            {
                priList[i] = 0;
                genList[i] = 0;
            }
            for (int i = 0; i < jarList.Count; i++)
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
                if(rand <= genList[a])
                {
                    target = ((GameObject)jarList[a]);
                    break;
                }
                a++;
            }
            gameObject.transform.position = target.transform.position;
            gameObject.transform.position += new Vector3(-1.5f, 0, z);
            status = false;
            StartCoroutine(target.GetComponent<Jar>().Hold(gameObject));
        }

        if (!freeze&&Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray, Mathf.Infinity);
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                GameObject.Find("GameManager").GetComponent<GameManager>().money += zeldaPrize;
                GameObject.Find("GameManager").GetComponent<GameManager>().MoenyChange();
                StartCoroutine(Freeze());
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
    IEnumerator Freeze() {
        freeze = true;
        freezeState = false;
        gameObject.GetComponent<AudioSource>().Play();
        gameObject.GetComponent<SpriteRenderer>().sprite = freezeSprite;
        yield return new WaitForSeconds(freezeTime);
        freezeState = true;
    }
}
