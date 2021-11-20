using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_game_manager : MonoBehaviour

    
{
    #region Singleton

    public static Inventory_game_manager instance;
    private void Awake()
    {
        
        if (instance != null)
        {
            Debug.LogWarning("More than one instance");
        }
        instance = this;
    }
    #endregion
    public delegate void OnItemsChanged();
    public OnItemsChanged onItemsChangedCallback;

    public List<Weapon> items = new List<Weapon>();
    public int space = 12;
    public void Add(Weapon item)
    {
       
        items.Add(item);
        if (onItemsChangedCallback != null)
        {
            onItemsChangedCallback.Invoke();
        }
        Debug.Log(items.Count);
        
    }
    public void Remove(Weapon item)
    {
        items.Remove(item);
        if (onItemsChangedCallback != null)
        {
            onItemsChangedCallback.Invoke();
        }
    }
}
