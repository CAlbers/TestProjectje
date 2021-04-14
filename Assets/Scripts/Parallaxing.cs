using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallaxing : MonoBehaviour
{
    [SerializeField]
    private Vector2 parallaxingEffect;
    private Vector2 startPos;
    private float length;
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        startPos = transform.position;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Kijken naar het verschil tussen de camerapositie en onze startpositie
        Vector2 dist = cam.transform.position * parallaxingEffect;
        Vector2 temp = cam.transform.position * (Vector2.one - parallaxingEffect);

        if (temp.x > startPos.x + length)
            startPos.x += length;
        else if (temp.x < startPos.x - length)
            startPos.x -= length;

        transform.position = startPos + dist;
    }
}
