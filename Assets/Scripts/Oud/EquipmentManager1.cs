using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentManager1 : MonoBehaviour
{
    // Bijhouden van items
    // 1) Kan via een Item class met daarin eigenschappen zoals naam/unlocked etc.
    // 2) Lijst maken met GameObjecten

    // Controleren op collision met items en zo items unlocken
    // Switchen van items in je hand doormiddel van 1 t/m 9

    [SerializeField]
    private List<GameObject> inventory = new List<GameObject>();
    [SerializeField]
    private List<bool> unlockedItems = new List<bool>();

    // Start is called before the first frame update
    void Start()
    {
        //Maken de UnlockedItems list even lang als de potentiele items in onze inventory
        for (int i = 0; i < inventory.Count; i++)
        {
            unlockedItems.Add(false);
        }
    }

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
        //Kijken of het itemNumber wel iets onder zich heeft hangen
        if (itemNumber <= inventory.Count)
        {
            //Kijken of het unlocked is, bool checken
            if (unlockedItems[itemNumber])
            {
                //Zo ja dan pakken we het in onze hand
                inventory[itemNumber].SetActive(true);
            }
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
            //2a Controlleren of we hem hebben of niet door onze inventory te lopen
            for (int i = 0; i < inventory.Count; i++)
            {
                //2b Controlleren of we hem hebben of niet door op naam te checken
                if (inventory[i].name == collision.name)
                {
                    //3 Unlocken als we hem nog niet hebben
                    unlockedItems[i] = true;
                    //4 Destroyen
                    Destroy(collision.gameObject);
                }
            }
        }
    }
}
