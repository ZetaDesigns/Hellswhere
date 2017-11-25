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

    private TurretBlueprint turretToBuild;
    public GameObject buildEffect;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return StatsManager.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild (TurretBlueprint turretbp)
    {
        turretToBuild = turretbp;
    }
    public void BuildTurretOn (Node node)
    {
        if(StatsManager.Money < turretToBuild.cost)
        {
            return;
        }
        StatsManager.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        GameObject effect = (GameObject)Instantiate(buildEffect, node.GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret built! Money left: " + StatsManager.Money);
    }
}
