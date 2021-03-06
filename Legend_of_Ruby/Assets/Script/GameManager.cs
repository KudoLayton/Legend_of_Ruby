﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {
    public GameObject jar;
    GameObject winText;
    GameObject loseText;
    GameObject replayBtn;
    GameObject nextBtn;
    public AudioClip clearsound;
    public AudioClip losesound;
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
    public string nextStage;
    bool fail;
    bool end;
    bool onece;

    IEnumerator Timer() {
        yield return new WaitForSeconds(30f);
        end = true;
    }

	// Use this for initialization
	void Start () {
        fail = false;
        end = false;
        onece = true;
        winText = GameObject.Find("WinText");
        loseText = GameObject.Find("LoseText") ;
        replayBtn = GameObject.Find("Replay");
        nextBtn = GameObject.Find("NextStage");
        winText.SetActive(false);
        loseText.SetActive(false);
        replayBtn.SetActive(false);
        if(nextBtn != null)
            nextBtn.SetActive(false);
        jarList = new ArrayList();
        GameObject[] copyList = GameObject.FindGameObjectsWithTag("Jar");
        StartCoroutine(Timer());
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

    IEnumerator clear() {
        AudioSource.PlayClipAtPoint(clearsound, Vector3.zero);
        yield return new WaitForSeconds(8.5f);
        winText.SetActive(true);
        nextBtn.SetActive(true);
        replayBtn.SetActive(true);
    }
    
	// Update is called once per frame
	void Update () {
        if (!end && !fail)
        {
            GameObject.Find("MentalState").GetComponent<Image>().fillAmount = (float)showMental / totalMental;
            GameObject.Find("LimitMoney").GetComponent<Text>().text = "/" + limitMoney.ToString().PadLeft(3, '0');
            GameObject.Find("Money").GetComponent<Text>().text = showMoney.ToString().PadLeft(3, '0');
            if (showMental != mental)
                StartCoroutine(MentalChange());
            if (showMoney != money)
                StartCoroutine(MoenyChange());
            if (mental <= 0)
            {
                gameObject.GetComponent<AudioSource>().Play();
                fail = true;
            }
        }
        else {
            Destroy(GameObject.Find("Player"));
            Destroy(GameObject.Find("Hanning"));
            GameObject.Find("Main Camera").GetComponent<AudioSource>().Stop();
            if (mental > 0 && money > limitMoney && onece)
            {
                onece = false;
                StartCoroutine(clear());
            }
            else if(onece){
                onece = false;
                loseText.SetActive(true);
                replayBtn.SetActive(true);
                if (!fail)
                {
                    AudioSource.PlayClipAtPoint(losesound, Vector3.zero);
                }
            }
        }
	}
}
