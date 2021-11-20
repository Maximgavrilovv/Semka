using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    private int fire_direction;
    private float start_pos;
    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.right * speed;
        if (NewPlayer.Instance.transform.position.x > this.transform.position.x)
        {
            fire_direction = -1;
            this.start_pos = this.transform.position.x;
        }
        else if (NewPlayer.Instance.transform.position.x < this.transform.position.x)
        {
            fire_direction = 1;
            this.start_pos = this.transform.position.x;
            
        }
    }

    private void Update()
    {
        if (Mathf.Abs(this.transform.position.x - this.start_pos) > 10)
        {
            Destroy(gameObject);
            
        }
    }

    void OnTriggerEnter2D (Collider2D col)
     {
         EnemyBase enemy = col.GetComponent<EnemyBase>();
         if (enemy != null)
         {
             enemy.GetHurt(fire_direction, 1);
             Destroy(gameObject);
        }
        
     }


}
