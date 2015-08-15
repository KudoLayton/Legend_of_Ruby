﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public int numJar;
    public GameObject jar;
    public ArrayList jarList;
    public int limitMoney;
    public int money;
    public int mental;
    public int showMental;
    public int totalMental;
    public int mentalDamage;
    public int moneyDamage;
    public int mentalDamageSpeed;
    public int showMoney;
    
	// Use this for initialization
	void Start () {
        jarList = new ArrayList();
        showMental = mental;
        showMoney = money;
        for (int i = 0; i < numJar; i++)
        {
            GameObject newjar = (GameObject)Instantiate(jar, new Vector2(Random.Range(-11f, 11f), Random.Range(0f, 8f)), Quaternion.identity);
            jarList.Add(newjar);
        }
	}
    public void MentalDeal() {
        mental -= mentalDamage;
    }

    public void MoneyDeal() {
        money -= moneyDamage;
    }

    IEnumerator MentalDamage() {
        while (showMental - mentalDamageSpeed > mental) {
            showMental -= mentalDamageSpeed;
            yield return new WaitForEndOfFrame();
        }
        showMental = mental;
    }

    IEnumerator MoenyDamage()
    {
        while (showMoney > money)
        {
            showMoney --;
            yield return new WaitForSeconds(0.5f);
        }
        showMoney = money;
    }

    public void JarReset()
    {
        for (int i = 0; i < jarList.Count; i++)
        {
            if ((GameObject)jarList[i] == null)
            {
                jarList.RemoveAt(i);
                i--;
                continue;
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
	void Update () {
        GameObject.Find("MentalState").GetComponent<Image>().fillAmount = (float)showMental / totalMental;
        GameObject.Find("LimitMoney").GetComponent<Text>().text = "/"+limitMoney.ToString().PadLeft(3, '0');
        GameObject.Find("Money").GetComponent<Text>().text = showMoney.ToString().PadLeft(3, '0');
        if (showMental > mental)
            StartCoroutine(MentalDamage());
        if (showMoney > money)
            StartCoroutine(MoenyDamage());
	}
}
