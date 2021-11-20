using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject gameObject;
    public int damage;
    public Inventory_game_manager inventory_Game_Manager;
    public enum Rarity {COMMON,UNCOMMON,RARE,EPIC,LEGENDARY,UKANIUM }
    public Rarity rarity;
    public bool isRanged;
    public Sprite icon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject == NewPlayer.Instance.gameObject)
        {
            if (inventory_Game_Manager.items.Count >= inventory_Game_Manager.space)
            {

            }
            else
            {
                inventory_Game_Manager.Add(this);
                Destroy(gameObject);
            }
        }
    }
}
