using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (turret != null)
        {
            Debug.Log("Already built something here");
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject) Instantiate(turretToBuild, transform.position + positionOffset, transform.rotation);

    }
	void OnMouseEnter ()
    {
       rend.material.color = hoverColor;
    }
    void OnMouseExit ()
    {
        rend.material.color = oldColor;
    }
}
