using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileFollow : MonoBehaviour
{
    
    public GameObject target;
    private int damage;
    public float speed = 10.0f;

    public void Seek(GameObject _target, int _damage)
    {
        target = _target;
        damage = _damage;
    }

    // Update is called once per frame
    void Update()
    {
        GameManager manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        if (target == null)
        {
            Destroy(this.gameObject);
            return;
        }

        Vector2 dir = target.transform.position - transform.position;
        float distancethisFrame = speed * Time.deltaTime;

        // dir.magnitude is distance from bullet to target
        if (target.TryGetComponent(out BalloonAttributes balloon))
        {
            if (dir.magnitude <= distancethisFrame)
            {
                Destroy(this.gameObject);
                
                balloon.health = balloon.health - damage;
                //Debug.Log(balloon.health);
                if (balloon.health <= 0)
                {
                    manager.balloonHit(balloon.coins);
                    //Debug.Log("Destroying balloon.");
                    Destroy(target);
                }
                
            }
        }


        transform.Translate(dir.normalized * distancethisFrame, Space.World);
    }
}
