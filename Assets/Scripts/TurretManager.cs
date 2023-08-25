using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretManager : MonoBehaviour
{
    // Start is called before the first frame update
    public void AddTurrettoScene (GameObject turret)
    {
        GameManager manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        manager.coins = manager.coins - manager.turretPrice;
        Instantiate(turret);
    }

    public void AddSpeedyTurrettoScene(GameObject turret)
    {
        GameManager manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        manager.coins = manager.coins - manager.speedyTurretPrice;
        Instantiate(turret);
    }

    public void AddHeavyTurrettoScene(GameObject turret)
    {
        GameManager manager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        manager.coins = manager.coins - manager.heavyTurretPrice;
        Instantiate(turret);
    }
}
