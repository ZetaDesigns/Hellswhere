using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    BuildManager buildmanager;

    void Start ()
    {
        buildmanager = BuildManager.instance;
    }
    public void PurchaseChenzwTurret ()
    {
        Debug.Log("Chenzw");
        buildmanager.SetTurretToBuild(buildmanager.chenzwTurretPrefab);
    }
    public void PurchaseBanhammer ()
    {
        Debug.Log("Chenzw");
        buildmanager.SetTurretToBuild(buildmanager.banHammerPrefab);
    }
}
