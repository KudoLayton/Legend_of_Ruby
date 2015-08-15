using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectLevel : MonoBehaviour {

    public int level;
    public int max_level;
    Text text;
    public Sprite hidden;
	
    // Use this for initialization
	void Start () {
        level = 1;
        text = GameObject.Find("Level").GetComponent<Text>();
        text.text = level +"";
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.W))
            changeLevel(true);
        else if (Input.GetKeyDown(KeyCode.S))
            changeLevel(false);
        else if (Input.GetKeyDown(KeyCode.Space))
            goLevel();
	}

    public void up()
    {
        changeLevel(true);
    }
    public void down()
    {
        changeLevel(false);
    }

    public void goLevel()
    {
        Application.LoadLevel("stage"+text.text);
    }

    void changeLevel(bool go)
    {
        
        if (go == true)
        {
            if (level == max_level)
                return;
            level++;
            text.text = level + "";
        }
        else
        {
            if(10000==Random.Range(0,10000))
            {
                GameObject.Find("Calendar").GetComponent<Image>().sprite = hidden;
                text.text = "";
                level = 1;
                Application.LoadLevel("HiForEveryOne");
            }
            if (level == 1)
                return;
            level--;
            text.text = level + "";
        }
    }
}
