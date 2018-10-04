using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public GameObject enemyCar; //holds reference to enemy car prefab
    public static int carsDodged; //holds number of cars player has dodged
    public static float enemySpeed; //holds speed of enemy cars
    int levelThreshold; //number of cars the player needs to dodge before next level
    int level; //counter for levels
    float enemySpawnSpeed; //rate at which enemies are spawned
    //text objects
    public Text levelText;
    public Text CDText;
    public Text ESText;
    public Text LTText;
    public Text ESSText;
    void Start()
    {
        carsDodged = 0;
        enemySpeed = 5;
        levelThreshold = 15;
        level = 1;
        enemySpawnSpeed = 1;
        StartGame();
    }

    void StartGame()
    {
        //starts spawning enemies at current ESS
        InvokeRepeating("SpawnEnemy", 0, enemySpawnSpeed);
    }

    //creates enemy car
    void SpawnEnemy()
    {
        Instantiate(enemyCar);
    }

    private void Update()
    {
        //if the player passes threshold for cars dodged
        if(carsDodged >= levelThreshold)
        {
            //and hasn't died
            if (!PlayerController.dead)
            {
                LevelUp();
            }
        }
        //sets UI text
        UpdateText();
    }

    void LevelUp()
    {
        //raises enemy speed and raises dodging threshold for next level
        enemySpeed *= 1.25f;
        levelThreshold = (int) (levelThreshold * 1.25f);
        carsDodged = 0;
        level++;
        enemySpawnSpeed *= 1.25f;
        //cancels the current spawning and starts again to change ESS
        CancelInvoke();
        StartGame();
    }

    //updates UI text
    void UpdateText()
    {
        levelText.text = "Level: " + level;
        CDText.text = "CD: " + carsDodged;
        ESText.text = "ES: " + enemySpeed;
        LTText.text = "LT: " + levelThreshold;
        ESSText.text = "ES: " + enemySpawnSpeed;
    }
}
