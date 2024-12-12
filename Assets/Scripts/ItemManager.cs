using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class ItemManager : MonoBehaviour
{
    // Fill the list with Editor
    // [SerializeField] private List<Item> _items;
    [SerializeField] private UnityEvent allItemsPickedUp;
    
    // Fill the list with code
    private List<Item> _itemsToPick = new List<Item>();
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // LINQ
        LoadItems();
    }
    
    void Update()
    {

    }

    public void LoadItems()
    {
        // Find objects in scenes
        //Item[] itemsArray = FindObjectsByType<Item>(FindObjectsSortMode.None);
        //GameObject[] itemsArray = GameObject.FindGameObjectsWithTag("Item");

        Item[] itemsArray = GetComponentsInChildren<Item>();
        _itemsToPick = new List<Item>(itemsArray);

        foreach (Item item in _itemsToPick)
        {
            item.Activate();
            item.OnPicked += RemoveItem;
        }
    }

    private void RemoveItem(Item itemToRemove)
    {
        Debug.Log("Removing item");
        itemToRemove.OnPicked -= RemoveItem;
        _itemsToPick.Remove(itemToRemove);
        
        if (_itemsToPick.Count == 0)
        {
            Debug.Log("ON Q GQGNE !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            //LoadItems();
            allItemsPickedUp?.Invoke();
        }
        
    }
    
}
