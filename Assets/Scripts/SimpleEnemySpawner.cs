using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemySpawner : MonoBehaviour
{
    public EnemyController enemyToSpawn;

    public Transform spwanPoint;

    public float timeBetweenSpawn;
    private float spwanCounter;

    public int amountToSpaw = 15;

    public Castle theCastle;
    public Path thePath;

    // Start is called before the first frame update
    void Start()
    {
        spwanCounter = timeBetweenSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if(amountToSpaw > 0 && theCastle.currentHealth > 0)
        {
            spwanCounter -= Time.deltaTime;

            if(spwanCounter <= 0)
            {
                spwanCounter = timeBetweenSpawn;

                Instantiate(enemyToSpawn, spwanPoint.position, spwanPoint.rotation).Setup(theCastle,thePath);

                amountToSpaw -= 1;
            }
        }

    }
}
