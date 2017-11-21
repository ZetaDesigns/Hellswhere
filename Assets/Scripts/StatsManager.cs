using UnityEngine;

public class StatsManager : MonoBehaviour {

    public static int Money;
    public int startMoney = 500;

    void Start()
    {
        Money = startMoney;
    }
}
