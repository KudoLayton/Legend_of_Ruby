using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {

    public int durability;
    public Sprite[] jarImg;
    public Renderer rend;

    // Use this for initializationㅐ
	void Start () {
        durability = jarImg.Length;
        rend = GetComponent<Renderer>();
    }
	// Update is called once per frame
    void Update()
    {
        if (durability == 0)
            Destroy(gameObject);
        else
        {
            GetComponent<SpriteRenderer>().sprite = jarImg[jarImg.Length - durability];
        }
    }
    
    void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0))
            GetAttack();
    }

    void GetAttack()
    {
        if (durability > 0)
            durability--;
    }
}
