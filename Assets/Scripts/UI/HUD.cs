using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

/*Manages and updates the HUD, which contains your health bar, coins, etc*/

public class HUD : MonoBehaviour
{
    [Header ("Reference")]
    public Animator animator;
    [SerializeField] private GameObject ammoBar;
    public TextMeshProUGUI coinsMesh;
    public TextMeshProUGUI ammoMesh;
    public TextMeshProUGUI healthPotionMesh;
    public TextMeshProUGUI ukainePotionMesh;
    public TextMeshProUGUI waterPotionMesh;


    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject UkaineBar;
    [SerializeField] private GameObject StaminaBar;
    [SerializeField] private Image inventoryItemGraphic;
    [SerializeField] private GameObject startUp;

    private float ammoBarWidth;
    private float ammoBarWidthEased; //Easing variables slowly ease towards a number
    [System.NonSerialized] public Sprite blankUI; //The sprite that is shown in the UI when you don't have any items
    private float coins;

    private float ammo;
    private float ammoEased;

    private float water_potion_count;
    private float water_potion_eased;
    private float ukaine_potion_count;
    private float ukaine_potion_eased;
    private float health_potion_count;
    private float health_potion_eased;

    private float coinsEased;
    public float ukaineBarWidth;
    public float ukaineBarWidthEased;
    public float staminaBarWidth;
    public float staminaBarWidthEased;
    private float healthBarWidth;
    private float healthBarWidthEased;
    [System.NonSerialized] public string loadSceneName;
    [System.NonSerialized] public bool resetPlayer;

    void Start()
    {
        //Set all bar widths to 1, and also the smooth variables.
        healthBarWidth = 1;
        healthBarWidthEased = healthBarWidth;
        ukaineBarWidth = 1;
        ukaineBarWidthEased = ukaineBarWidth;
        staminaBarWidth = 1;
        staminaBarWidthEased = staminaBarWidth;
        //ammoBarWidth = 1;
        //ammoBarWidthEased = ammoBarWidth;
        coins = (float)NewPlayer.Instance.coins;
        ammo = (float)NewPlayer.Instance.ammo;
        health_potion_count= (float)NewPlayer.Instance.healthPotionCount;
        ukaine_potion_count = (float)NewPlayer.Instance.ukainePotionCount;
        water_potion_count = (float)NewPlayer.Instance.waterPotionCount;
        ammoEased = ammo;
        coinsEased = coins;
        health_potion_eased = health_potion_count;
        ukaine_potion_eased = ukaine_potion_count;
        water_potion_eased = water_potion_count;
        

        blankUI = inventoryItemGraphic.GetComponent<Image>().sprite;
    }

    void Update()
    {
        //Update coins text mesh to reflect how many coins the player has! However, we want them to count up.
        coinsMesh.text = Mathf.Round(coinsEased).ToString();
        ammoMesh.text = Mathf.Round(ammoEased).ToString();
        healthPotionMesh.text = Mathf.Round(health_potion_eased).ToString();
        ukainePotionMesh.text = Mathf.Round(ukaine_potion_eased).ToString();
        waterPotionMesh.text = Mathf.Round(water_potion_eased).ToString();
        ammoEased += ((float)NewPlayer.Instance.ammo - ammoEased) * Time.deltaTime * 5f;
        coinsEased += ((float)NewPlayer.Instance.coins - coinsEased) * Time.deltaTime * 5f;
        health_potion_eased += ((float)NewPlayer.Instance.healthPotionCount - health_potion_eased) * Time.deltaTime * 5f;
        ukaine_potion_eased += ((float)NewPlayer.Instance.ukainePotionCount - ukaine_potion_eased) * Time.deltaTime * 5f;
        water_potion_eased += ((float)NewPlayer.Instance.waterPotionCount - water_potion_eased) * Time.deltaTime * 5f;


        if (coinsEased >= coins)
        {
            animator.SetTrigger("getGem");
            coins = coinsEased + 1;
        }

        //Controls the width of the health bar based on the player's total health
        healthBarWidth = (float)NewPlayer.Instance.health / (float)NewPlayer.Instance.maxHealth;
        healthBarWidthEased += (healthBarWidth - healthBarWidthEased) * Time.deltaTime * healthBarWidthEased;
        healthBar.transform.localScale = new Vector2(healthBarWidthEased, 1);
        ukaineBarWidthEased = (float)NewPlayer.Instance.ukaine / (float)NewPlayer.Instance.maxUkaine;
        //ukaineBarWidthEased += (ukaineBarWidth - ukaineBarWidthEased) * Time.deltaTime * ukaineBarWidthEased; //this makes the bar go down slower, which is not optimal for this game
        UkaineBar.transform.localScale = new Vector2(ukaineBarWidthEased, 1);

        staminaBarWidthEased = (float)NewPlayer.Instance.stamina / (float)NewPlayer.Instance.maxStamina;
        StaminaBar.transform.localScale = new Vector2(staminaBarWidthEased, 1);

        //Controls the width of the ammo bar based on the player's total ammo
        if (ammoBar)
        {
            ammoBarWidth = (float)NewPlayer.Instance.ammo / (float)NewPlayer.Instance.maxAmmo;
            ammoBarWidthEased += (ammoBarWidth - ammoBarWidthEased) * Time.deltaTime * ammoBarWidthEased;
            ammoBar.transform.localScale = new Vector2(ammoBarWidthEased, transform.localScale.y);
        }
        
    }

    public void HealthBarHurt()
    {
        animator.SetTrigger("hurt");
    }

    public void SetInventoryImage(Sprite image)
    {
        inventoryItemGraphic.sprite = image;
    }

    void ResetScene()
    {
        if (GameManager.Instance.inventory.ContainsKey("reachedCheckpoint"))
        {
            //Send player back to the checkpoint if they reached one!
            NewPlayer.Instance.ResetLevel();
        }
        else
        {
            //Reload entire scene
            SceneManager.LoadScene(loadSceneName);
        }
    }

}
