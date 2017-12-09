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
    private Node selectedNode;

    public nodeUI nodeUI;
    public GameObject buildEffect;
    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return StatsManager.Money >= turretToBuild.cost; } }

    public void SelectTurretToBuild (TurretBlueprint turretbp)
    {
        turretToBuild = turretbp;
        DeselectNode();
    }
    public TurretBlueprint GetTurretToBuild ()
    {
        return turretToBuild;
    }
    public void SelectNode (Node node)
    {
        if(selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
    }
    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }
}
