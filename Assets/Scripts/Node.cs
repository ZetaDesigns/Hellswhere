using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color notEnoughMoneyColor;
    public Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded = false;
    private Renderer rend;
    private Color oldColor;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        oldColor = rend.material.color;
    }

    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }
    void OnMouseDown ()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (turret != null)
        {
            BuildManager.instance.SelectNode(this);
            return;
        }
        if (!BuildManager.instance.CanBuild)
        {
            return;
        }
        BuildTurret(BuildManager.instance.GetTurretToBuild());

    }
    void BuildTurret(TurretBlueprint blueprint)
    {
        if (StatsManager.Money < blueprint.cost)
        {
            return;
        }
        StatsManager.Money -= blueprint.cost;

        GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;
        GameObject effect = (GameObject)Instantiate(BuildManager.instance.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);
        Debug.Log("Turret built!");
    }
    public void UpgradeTurret ()
    {
        if (StatsManager.Money < turretBlueprint.upgradeCost)
        {
            return;
        }
        StatsManager.Money -= turretBlueprint.upgradeCost;
        //Get rid of old turret
        Destroy(turret);
        //Build upgraded one
        GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject effect = (GameObject)Instantiate(BuildManager.instance.buildEffect, GetBuildPosition(), Quaternion.identity);
        Destroy(effect, 5f);

        Debug.Log("Turret upgraded!");
    }
	void OnMouseEnter ()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!BuildManager.instance.CanBuild)
        {
            return;
        }
        if(BuildManager.instance.HasMoney)
        {
           rend.material.color = hoverColor;
        }  else
        {
            rend.material.color = notEnoughMoneyColor;
        }
    }
    void OnMouseExit ()
    {
        rend.material.color = oldColor;
    }
}
