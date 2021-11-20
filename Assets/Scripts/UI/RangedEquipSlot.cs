using UnityEngine.UI;
using UnityEngine;

public class RangedEquipSlot : MonoBehaviour
{
    public Weapon weapon;
    public Image icon;
    #region Singleton

    public static RangedEquipSlot instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        icon.enabled = true;
        weapon = NewPlayer.Instance.RangedWeapon;
        icon.sprite = NewPlayer.Instance.RangedWeapon.icon;

    }

}
