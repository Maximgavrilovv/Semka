using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using TMPro;
using UnityEngine.SceneManagement;

public class KalmanAbilities : MonoBehaviour
    
{
    private int abilityNumber;
    public List<TextMeshProUGUI> timers;
    public int[] cooldown = new int[4];
    public bool[] canFire = new bool[4];
    public Transform fire_point;
   

    public GameObject potion;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (abilityNumber == 0 && canFire[0])
        {
            canFire[0] = false;
            Instantiate(potion, fire_point.position, fire_point.rotation);
            

        }
        
    }
}
