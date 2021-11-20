using UnityEngine.UI;
using UnityEngine;

public class MeleeEquipSlot : MonoBehaviour
{
    public Weapon weapon;
    public Image icon;
    #region Singleton

    public static MeleeEquipSlot instance;
    private void Awake()
    {
        instance = this;
    }
    #endregion

    private void Start()
    {
        icon.enabled = true;
        weapon = NewPlayer.Instance.MeleeWeapon;
        icon.sprite = NewPlayer.Instance.MeleeWeapon.icon;

    }

}
