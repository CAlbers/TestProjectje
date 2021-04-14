using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicRaycastScript : MonoBehaviour
{
    /// <summary>
    /// Hier selecteer je op welke lagen de Raycast moet werken
    /// </summary>
    public LayerMask layersToCheck;
    /// <summary>
    /// Lengte van de Raycast
    /// </summary>
    public float rayLength = 10;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Muispositie uitrekenen in Unity units
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        
        //Richting berekenen. Dit doen we door het verschil tussen de muis en de speler te pakken zodat we weten
        //welke kant we op moeten schieten met onze Ray. We zetten hem om in een Vector2 vanwege onze 2D wereld.
        Vector2 dir = mousePos - new Vector2(transform.position.x, transform.position.y);
        
        //We normalize de Vector om hem een lengte van 1 te geven. Dit voorkomt dat hoe verder de muis zit hoe groter de 
        //Vector2 wordt en des te sneller onze ray/character beweegt
        dir = dir.normalized;


        #region Work in progress
        //Werkt nog niet volledig
        //if (Input.GetMouseButtonDown(1) && Input.GetKeyDown(KeyCode.LeftControl))
        //{
        //    Collider2D coll = Physics2D.OverlapCircle(transform.position, 2f);
        //    if (coll)
        //    {
        //        Debug.Log(coll.name);
        //    }
        //} 
        #endregion

        //Single hit onder linkermuisknop
        if (Input.GetMouseButtonDown(0))
        {
            #region Single Hit Detection
            //Uitkomst van de Raycast slaan we op zodat we er later mee aan de slag kunnen
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rayLength, layersToCheck);

            //Checken of de Raycast iets geraakt heeft en dus niet leeg is
            if (hit == true)
            {
                //We hebben iets geraakt nu programmeren wij de reactie als het obstakel de Enemy is
                if (hit.collider.CompareTag("Enemy"))
                {
                    Debug.Log("Enemy geraakt");
                }

                //Als we iets geraakt hebben tekenen we een groene lijn welke 1 seconden blijft staan
                Debug.DrawRay(transform.position, dir * rayLength, Color.green, 1f);
            }
            else
            {
                //Als we gemist hebben dan tekenen we een rode lijn voor 0,5 seconden
                Debug.DrawRay(transform.position, dir * rayLength, Color.red, 0.5f);
            }
            #endregion 
        }

        //Multi hit onder rechtermuisknop
        else if (Input.GetMouseButtonDown(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, rayLength, layersToCheck);

            #region Multi Hit Detection
            //Schieten een Raycast af die meerdere objecten kan raken en deze stoppen we in een Array genaamd hits.
            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, dir, rayLength, layersToCheck);

            //Controleren of we tenminste 1 object hebben geraakt
            if (hits.Length > 0)
            {
                //Loop door de lijst met objecten die we geraakt hebben
                for (int i = 0; i < hits.Length; i++)
                {
                    //Hier kunnen we nu controlleren wat we geraakt hebben met hits[i].collider.CompareTag();

                    //Als we iets geraakt hebben tekenen we een groene lijn voor elke hit welke 1 seconden blijft staan
                    Debug.DrawRay(transform.position, dir * rayLength, Color.green, 1f);
                }
            }
            else
            {
                //Als we gemist hebben dan tekenen we een rode lijn voor 0,5 seconden
                Debug.DrawRay(transform.position, dir * rayLength, Color.red, 0.5f);
            }
            #endregion
        }
    }
}
