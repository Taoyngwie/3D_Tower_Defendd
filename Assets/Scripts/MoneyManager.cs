using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public static MoneyManager instance;

    private void Awake()
    {
        instance = this;
    }

    public int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        UIController.instance.goldText.text = currentMoney.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GivMoney(int amountToGive)
    {
        currentMoney += amountToGive;

        UIController.instance.goldText.text = currentMoney.ToString();
    }

    public bool SpendMoney(int amountToGive)
    {
        bool canSpeed = false;

        if(amountToGive <= currentMoney)
        {
            canSpeed = true;

            Debug.Log("Spent " + amountToGive);
            currentMoney -= amountToGive;
        }

        UIController.instance.goldText.text = currentMoney.ToString();


        return canSpeed;
    }
}