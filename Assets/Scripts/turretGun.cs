using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turretGun : MonoBehaviour
{
    //public Transform target;

    public GameObject target;

    [Header("Attributes")]
    public float range = 2.0f;
    public float fireRate = 1.0f;
    private float fireCountdown = 0.0f;
    public int damage;

    public GameObject projectilePrefab;
    public LineRenderer circleRenderer;
    //public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] balloons = GameObject.FindGameObjectsWithTag("Balloon");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestBalloon = null;

        foreach (GameObject balloon in balloons)
        {
            float distanceToBalloon = Vector2.Distance(transform.position, balloon.transform.position);
            if (distanceToBalloon < shortestDistance)
            {
                shortestDistance = distanceToBalloon;
                nearestBalloon = balloon;
            }
        }

        if (nearestBalloon != null && shortestDistance <= range)
        {
            target = nearestBalloon;
        }
        else
        {
            target = null;
        }

    }

    void Update()
    {
        if (target == null)
        {
            return;
        }

        Vector3 dir = target.transform.position - transform.position;

        if (fireCountdown <= 0.0f)
        {
            Shoot();
            fireCountdown = 1.0f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletSpawn = (GameObject)Instantiate(projectilePrefab, this.transform.position, this.transform.rotation);
        projectileFollow bullet = bulletSpawn.GetComponent<projectileFollow>();

        this.gameObject.GetComponent<AudioSource>().Play();

        if (bullet != null)
        {
            bullet.Seek(target, damage);
        }

    }


    private void OnDrawGizmosSelected()
    {
        UnityEditor.Handles.color = Color.red;
        CircleCollider2D collider;
        collider = this.GetComponent<CircleCollider2D>();
        UnityEditor.Handles.DrawWireDisc(this.transform.position, Vector3.back, range);
    }
}