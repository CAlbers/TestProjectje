using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableOnTrigger : MonoBehaviour
{
    //Object to enable/disable
    public GameObject enableThis;

    // Start is called before the first frame update
    void Start()
    {
        enableThis.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        enableThis.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        enableThis.SetActive(false);
    }
}
