using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyRecord : MonoBehaviour
{
    private static int moneyAmount;

    public static void Record(int amount)
    {
        moneyAmount = amount;
    }

    public static int GetAmount()
    {
        return moneyAmount;
    }

}
