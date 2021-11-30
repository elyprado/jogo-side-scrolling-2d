using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControleNPC : MonoBehaviour
{

    private Rigidbody2D rig;
    private float mov = 1F;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mov > 0) {
            GetComponent<SpriteRenderer>().flipX = true;
        } else {
            GetComponent<SpriteRenderer>().flipX = false;
        } 
        rig.velocity = new Vector2(mov, rig.velocity.y);
    }
    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            if (col.gameObject.transform.position.y > gameObject.transform.position.y+1) {
                Destroy(gameObject);            
            } else {
                Destroy(col.gameObject);
            }       
        } else {
            mov = mov * -1;    
        }
    }
}
