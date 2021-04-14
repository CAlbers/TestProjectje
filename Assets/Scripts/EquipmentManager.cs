using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    // Bijhouden van items
    // 1) Kan via een Item class met daarin eigenschappen zoals naam/unlocked etc.
    // 2) Lijst maken met GameObjecten

    // Controleren op collision met items en zo items unlocken
    // Switchen van items in je hand doormiddel van 1 t/m 9

    [SerializeField]
    private List<Item> inventory = new List<Item>();

    [SerializeField]
    private GameObject handSlot;
    // Update is called once per frame
    void Update()
    {
        #region Alternatieve manieren van input checken
        //Per key checken
        //if(Input.GetKeyDown(KeyCode.Alpha1))
        //{
        //    //Equip iets
        //}   

        //Switch case op Input.inputString;
        //string pressedKey = Input.inputString;
        //switch (Input.inputString)
        //{
        //    case "1":
        //        break;
        //    case "2":
        //        break;
        //    case "3":
        //        break;
        //    case "4":
        //        break;
        //} 
        #endregion

        CheckNumberInput();
    }

    private void SwitchEquipment(int itemNumber)
    {
        //Kijken of we wel items hebben en of we het cijfer hebben
        if (itemNumber <= inventory.Count && inventory[itemNumber].equipable)
        {
            //Zo ja dan pakken we het in onze hand
            inventory[itemNumber].gameObject.SetActive(true);
        }
    }

    private void CheckNumberInput()
    {
        //Eerst controlleren of er wel iets ingedrukt wordt. Wel zo netjes/optimaal
        if (Input.inputString.Length != 0)
        {
            int number;
            //We gaan proberen de string om te zetten naar een nummer. Lukt dit dan wordt de variabele number met het resultaat gevuld
            if (int.TryParse(Input.inputString, out number))
            {
                Debug.Log("Je hebt het volgende nummer ingedrukt: " + number);
                //Iets doen met het nummer
                SwitchEquipment(number);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //1 Kijken of het een collectible/item is
        if (collision.CompareTag("Collectible"))
        {
            var item = collision.GetComponent<Item>();

            //2a Controlleren of we hem hebben of niet door onze inventory te lopen
            for (int i = 0; i < inventory.Count; i++)
            {
                //3 Pakken het Item onderdeel van het object wat we raken
                if (inventory[i].name == item.name)
                {
                    //4 Matched de naam dan voegen we hem met 1tje omhoog
                    inventory[i].amount += 1;
                    Destroy(collision.gameObject);
                    return;
                }
            }

            inventory.Add(item);
            item.gameObject.transform.parent = handSlot.transform;
            item.gameObject.transform.localPosition = Vector2.zero;
            item.gameObject.SetActive(false);
        }
    }
}
