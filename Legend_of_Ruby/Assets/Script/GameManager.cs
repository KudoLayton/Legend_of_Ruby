﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
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
        GameObject[] copyList = GameObject.FindGameObjectsWithTag("Jar");
        
        foreach (GameObject jar in copyList)
        {
            jarList.Add(jar);
        }
        showMental = mental;
        showMoney = money;
	}
    public void MentalDeal() {
        mental -= mentalDamage;
    }

    public void MoneyDeal() {
        money -= moneyDamage;
    }

    public IEnumerator MentalChange() {
        while (showMental - mentalDamageSpeed > mental) {
            if(showMental - mentalDamageSpeed > mental)
                showMental -= mentalDamageSpeed;
            else if(showMental - mentalDamageSpeed < mental)
                showMental += mentalDamageSpeed;
            yield return new WaitForEndOfFrame();
        }
        showMental = mental;
    }

    public IEnumerator MoenyChange()
    {
        while (showMoney > money)
        {
            if (showMoney > money)
                showMoney--;
            else if (showMoney < money)
                showMoney++;
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
            StartCoroutine(MentalChange());
        if (showMoney > money)
            StartCoroutine(MoenyChange());
	}
}
