using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowableStuff : MonoBehaviour
{

    public GameObject hand;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            for (int i = 0; i < hand.transform.childCount; i++)
            {
                if (gameObject.transform.GetChild(i).gameObject.activeSelf == true)
                {
                    var handActive = Instantiate(gameObject.transform.GetChild(i));
                    //handActive.transform.position = hand.transform.position;
                    handActive.gameObject.AddComponent(typeof(Rigidbody2D));
                    var dir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    handActive.GetComponent<Rigidbody2D>().AddForce(dir * 300);
                }
            }
        }
    }
}
