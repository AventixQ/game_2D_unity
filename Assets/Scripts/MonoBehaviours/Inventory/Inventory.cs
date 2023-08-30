using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //prefab of slot
    public GameObject slotPrefab;
    public const int numSlots = 5;
    //arrays to hold images, items and slots
    Image[] itemImages = new Image[numSlots]; //tab for images
    Item[] items = new Item[numSlots]; //tab for reference to Scriptable Items
    GameObject[] slots = new GameObject[numSlots]; //for QtyText

    public void Start()
    {
        CreateSlots();
    }

    //creates inventory slots
    public void CreateSlots()
    {
        //if there is Slot prefab in Unity
        if (slotPrefab != null)
        {
            //create five new slots with name ItemSlot_X
            for (int i = 0; i < numSlots; i++)
            {
                GameObject newSlot = Instantiate(slotPrefab);
                newSlot.name = "ItemSlot_" + i;
                newSlot.transform.SetParent(gameObject.transform.GetChild(0).transform);
                slots[i] = newSlot;
                itemImages[i] = newSlot.transform.GetChild(1).GetComponent<Image>();
            }
        }
    }

    //check where to put and add item to the inventory
    public bool AddItem(Item itemToAdd)
    {
        for (int i = 0; i < items.Length; i++)
        {
            //if there is this item, add new text and change quantity
            if (items[i] != null && items[i].itemType == itemToAdd.itemType
            && itemToAdd.stackable == true)
            {
                items[i].quantity = items[i].quantity + 1;
                Slot slotScript = slots[i].gameObject.GetComponent<Slot>();
                Text quantityText = slotScript.qtyText;
                quantityText.enabled = true;
                quantityText.text = items[i].quantity.ToString();
                return true;
            }
            //if there is not the item, add new item to the first empty slot, change quantity to 1 and add image
            if (items[i] == null)
            {
                items[i] = Instantiate(itemToAdd);
                items[i].quantity = 1;
                itemImages[i].sprite = itemToAdd.sprite;
                itemImages[i].enabled = true;
                return true;
            }
        }
        return false;
    }
}