using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {

    public int durability;
    public Sprite[] jarImg;
    public Renderer rend;

    Ray ray;
    RaycastHit hit;

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
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log(hit.collider.name);
                if (Input.GetMouseButtonDown(0))
                    GetAttack();
            }
                GetComponent<SpriteRenderer>().sprite = jarImg[jarImg.Length - durability];
        }
    }
    


    void GetAttack()
    {
        if (durability > 0)
            durability--;
    }
}
