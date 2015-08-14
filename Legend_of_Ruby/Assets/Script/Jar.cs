using UnityEngine;
using System.Collections;

public class Jar : MonoBehaviour {
    public Camera cam;
    public int durability;
    public Sprite[] jarImg;
    RaycastHit2D hit;
    // Use this for initialization
	void Start () {
//        cam = GameObject.Find("Main Camera").GetComponent<Camera>();
        durability = jarImg.Length;
    }
	// Update is called once per frame
    void Update()
    {
        if (durability == 0)
            Destroy(gameObject);
        else
        {
/*            hit = Physics2D.Raycast(cam.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            GetComponent<SpriteRenderer>().sprite = jarImg[jarImg.Length - durability];
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.name);
                if (Input.GetMouseButtonDown(0))
                    GetAttack();
            }
*/        }
    }
    
    void GetAttack()
    {
        if (durability > 0)
            durability--;
    }
}
