using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    public Vector3 positionOffset;
    private GameObject turret;

    private Renderer rend;
    private Color oldColor;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        oldColor = rend.material.color;
    }
    void OnMouseDown ()
    {
        if(EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("Already built something here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
	void OnMouseEnter ()
    {
        if (BuildManager.instance.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
    }
    void OnMouseExit ()
    {
        rend.material.color = oldColor;
    }
}
