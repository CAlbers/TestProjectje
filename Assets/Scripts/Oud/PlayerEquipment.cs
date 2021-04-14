using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEquipment : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> inventory = new List<GameObject>();
    [SerializeField]
    private List<bool> unlockedItems = new List<bool>();
    [SerializeField]
    private int currentlyEquiped;

    // Start is called before the first frame update
    void Start()
    {
        //Populate list with bools to set which item is available or not
        for (int i = 0; i < inventory.Count; i++)
        {
            unlockedItems.Add(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int number;
        if (int.TryParse(Input.inputString, out number))
        {
            Debug.Log("Input Noted");
            SwitchEquipment(number);
        }
    }

    private void SwitchEquipment(int itemNumber)
    {
        if(itemNumber == 0)
        {
            inventory[currentlyEquiped].SetActive(false);
        }
        else if (itemNumber < inventory.Count)
        {
            if (unlockedItems[itemNumber])
            {
                inventory[currentlyEquiped].SetActive(false);
                inventory[itemNumber].SetActive(true);
                currentlyEquiped = itemNumber;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Collectible"))
        {
            for (int i = 0; i < inventory.Count; i++)
            {
                if (inventory[i].name == collision.name)
                {
                    unlockedItems[i] = true;
                }
            }
        }
    }
}
