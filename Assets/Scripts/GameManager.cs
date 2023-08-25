using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public int coins = 10;

    

    [Header("Turret Properties/Buttons")]
    public GameObject speedyTurretButton;
    public GameObject heavyTurretButton;
    public GameObject turretButton;
    public int turretPrice = 10;
    public int speedyTurretPrice = 15;
    public int heavyTurretPrice = 20;

    [Header("Scene Manager")]
    public string levelToRestart;
    public string nextLeveltoLoad;
    public string exitLevel;
    public bool gameIsOver;

    [Header("Canvas Elements")]
    public GameObject victoryCanvas;
    public GameObject defeatCanvas;
    public Text castleHealthText;
    public Text coinsText;
    

    private void Start()
    {
        victoryCanvas.SetActive(false);
        defeatCanvas.SetActive(false);
    }
    // Start is called before the first frame update
    private void Update()
    {
        gameIsOver = false;
        gm = this;
        GameObject balloon = GameObject.FindGameObjectWithTag("Balloon");
        SpawnGameObjects spawner = GameObject.Find("Balloon Spawner").GetComponent<SpawnGameObjects>();
        CastleBehavior castle = GameObject.Find("Castle").GetComponent<CastleBehavior>();
        

        if (castle.castleHealth >= 0)
        {
            castleHealthText.text = "Castle Health: " + castle.castleHealth.ToString();
        }
        else
        {
            castleHealthText.text = "Castle Health: 0";
        }

        coinsText.text = "Coins: " + this.GetComponent<GameManager>().coins;

        // Controls turret menu buttons.
        if (gm.coins < 15)
        {
            turretButton.GetComponent<Button>().interactable = false;
        }
        else 
        {
            turretButton.GetComponent<Button>().interactable = true;
        }
        if (gm.coins < 30)
        {
            speedyTurretButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            speedyTurretButton.GetComponent<Button>().interactable = true;
        }
        if (gm.coins < 40)
        {
            heavyTurretButton.GetComponent<Button>().interactable = false;
        }
        else
        {
            heavyTurretButton.GetComponent<Button>().interactable = true;
        }

        // Win conditon: All balloons have been spawned and there are none left in the level.
        if (spawner.numberSpawned == spawner.numberToSpawn)
        {
            //Debug.Log("Done Spawning");
            if (!balloon)
            {
                //gameIsOver = true;
                beatLevel();
            }
        }

        // Lose condition: Castle health drops to zero.
        if (castle.castleHealth <= 0)
        {
            gameIsOver = true;
            gameOver();
        }
    }
    public void balloonHit (int coinsToAdd)
    {
        //Debug.Log("Hit balloon!");
        coins = coins + coinsToAdd;
    }

	public void gameOver()
    {
        defeatCanvas.SetActive(true);
        victoryCanvas.SetActive(false);
        return;
    }

    public void beatLevel()
    {
        //SceneManager.LoadScene(victoryLevel);
        CastleBehavior castle = GameObject.Find("Castle").GetComponent<CastleBehavior>();
        if (castle.castleHealth > 0)
        {
            victoryCanvas.SetActive(true);
        }

    }

    public void restartLevel()
    {
        SceneManager.LoadScene(levelToRestart);
    }

    public void nextLevel()
    {
        SceneManager.LoadScene(nextLeveltoLoad);
    }

    public void exit()
    {
        SceneManager.LoadScene(exitLevel);
    }
        
}
