using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour {

    public TurretBlueprint chenzwTurret;
    public TurretBlueprint banHammer;


    BuildManager buildmanager;

    void Start ()
    {
        buildmanager = BuildManager.instance;
    }
    public void SelectChenzwTurret ()
    {
        Debug.Log("Chenzw");
        buildmanager.SelectTurretToBuild(chenzwTurret);
    }
    public void SelectBanhammer ()
    {
        Debug.Log("BanHammer");
        buildmanager.SelectTurretToBuild(banHammer);
    }
}
