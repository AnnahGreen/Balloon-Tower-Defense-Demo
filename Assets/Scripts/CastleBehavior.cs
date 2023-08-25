using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastleBehavior : MonoBehaviour
{
    
    public int castleHealth = 100;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameManager manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (collision.gameObject.tag == "Balloon")
        {
            castleHealth = castleHealth - collision.gameObject.GetComponent<BalloonAttributes>().damage;
            Destroy(collision.gameObject);
        }

        if (castleHealth <= 0)
        {
            manager.gameOver();
        }
    }
}
