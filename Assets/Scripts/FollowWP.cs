using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWP : MonoBehaviour
{
    public GameObject[] waypoints;

    public float speed = 10.0f;
    public int numberofWaypoints = 0;
    // Start is called before the first frame update

    int currentWP = 0;

    // Update is called once per frame
    void Update()
    {
        Vector2 balloonPosition = this.transform.position;
        Vector2 waypointPosition = waypoints[currentWP].transform.position;
        //Debug.Log(Vector2.Distance(this.transform.position, waypoints[currentWP].transform.position));

        // Computing distance between tank position and way point position 
        
        if (Vector2.Distance(this.transform.position, waypoints[currentWP].transform.position) < .15) 
        {
            if (currentWP == (numberofWaypoints-1))
            {
                Destroy(this.gameObject);
            }
            else
            {
                currentWP = currentWP + 1;
            }
            
        }

        this.transform.position = Vector2.MoveTowards(balloonPosition, waypointPosition, speed * Time.deltaTime);
        
    }
}
