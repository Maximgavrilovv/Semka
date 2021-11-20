using UnityEngine.UI;
using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    public Image icon;
    public Button removeButton;
    public MeleeEquipSlot meleeEquip;
    public RangedEquipSlot rangedEquip;
    Weapon temp;

    Weapon weapon;

    public void AddItem(Weapon item)
    {
        weapon = item;
        icon.sprite = weapon.icon;
        icon.enabled = true;
        removeButton.interactable = true;

    }

    public void ClearSlot()
    {
        weapon = null;

        icon.sprite = null;
        icon.enabled = false;
        removeButton.interactable = false;
    }

    public void OnClickRemoveButton()
    {
        Debug.Log(Inventory_game_manager.instance.items.Count);
        
        Inventory_game_manager.instance.Remove(weapon);
        if (weapon.rarity==Weapon.Rarity.COMMON)
        {
            NewPlayer.Instance.coins += 20;
        }else if (weapon.rarity == Weapon.Rarity.UNCOMMON)
        {
            NewPlayer.Instance.coins += 50;
        }else
        if (weapon.rarity == Weapon.Rarity.RARE)
        {
            NewPlayer.Instance.coins += 100;
        }
        else if (weapon.rarity == Weapon.Rarity.EPIC)
        {
            NewPlayer.Instance.coins += 200;
        }
        else if (weapon.rarity == Weapon.Rarity.LEGENDARY)
        {
            NewPlayer.Instance.coins += 400;
        }
        else if (weapon.rarity == Weapon.Rarity.UKANIUM)
        {
            NewPlayer.Instance.coins += 800;
        }
        
            
        
    }

    public void OnItemButtonClick()
    {
        if (weapon.isRanged)
        {
            temp = RangedEquipSlot.instance.weapon;
            RangedEquipSlot.instance.weapon = weapon;
            RangedEquipSlot.instance.icon = icon;
            icon.sprite = temp.icon;
            weapon = temp;
            NewPlayer.Instance.RangedWeapon = weapon;
        }
        else
        {
            Weapon temp = MeleeEquipSlot.instance.weapon;
            MeleeEquipSlot.instance.weapon = weapon;
            MeleeEquipSlot.instance.icon = icon;

            icon.sprite = temp.icon;
            weapon = temp;
            NewPlayer.Instance.MeleeWeapon = weapon;
        }
    }
}
