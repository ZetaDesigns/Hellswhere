using UnityEngine;

[System.Serializable]
public class TurretBlueprint{

    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;

    public int GetSellValue ()
    {
        return cost / 2;
    }
}
