using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    private void Awake()
    {
        instance = this;
    }

    public bool levelActive;
    private bool levelVictory;

    private Castle theCastle;

    public List<EnemyHealthController> activeEnemies = new List<EnemyHealthController>();

    private SimpleEnemySpawner enemySpawaner;

    // Start is called before the first frame update
    void Start()
    {
        theCastle = FindObjectOfType<Castle>();
        enemySpawaner = FindObjectOfType<SimpleEnemySpawner>();

        levelActive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (levelActive)
        {
            if(theCastle.currentHealth <= 0)
            {
                levelActive = false;
                levelVictory = false;

                UIController.instance.levelFailScreen.SetActive(true);
                UIController.instance.towerButtons.SetActive(false);
            }

            if(activeEnemies.Count == 0 && enemySpawaner.amountToSpaw == 0)
            {
                levelActive = false;
                levelVictory = true;

                UIController.instance.levelComplete.SetActive(true);
                UIController.instance.towerButtons.SetActive(false);
            }
        }
    }
}