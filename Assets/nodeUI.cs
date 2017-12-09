using UnityEngine;
using UnityEngine.UI;

public class nodeUI : MonoBehaviour {

    public GameObject ui;
    private Node target;
    public Button upgradeButton;
    public Text UpgradeCostText;

    public void SetTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetBuildPosition();
        if(!target.isUpgraded)
        {
            UpgradeCostText.text = "$" + target.turretBlueprint.upgradeCost.ToString();
            upgradeButton.interactable = true;
        } else
        {
            upgradeButton.interactable = false;
            UpgradeCostText.text = "MAX!";
        }
        
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }

    public void Upgrade ()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
}
