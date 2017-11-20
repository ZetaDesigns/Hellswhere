using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("More than one BM in scene!");
            return;
        }
        instance = this;
    }

    public GameObject chenzwTurretPrefab;
    public GameObject banHammerPrefab;
    private GameObject turretToBuild;
    
    public GameObject GetTurretToBuild ()
    {
        return turretToBuild;
    }
    public void SetTurretToBuild (GameObject turret)
    {
        turretToBuild = turret;
    }
}
