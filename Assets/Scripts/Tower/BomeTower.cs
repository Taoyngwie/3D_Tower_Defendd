using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BomeTower : MonoBehaviour
{
    private Tower theTower;

    public float timeBetweenBombs;
    private float bombCounter;
    
    // Start is called before the first frame update
    void Start()
    {

        theTower = GetComponent<Tower>();

        bombCounter = timeBetweenBombs;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
