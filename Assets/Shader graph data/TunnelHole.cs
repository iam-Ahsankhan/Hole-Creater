using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class TunnelHole : MonoBehaviour
{
    public Material holeMaterial; // Assign your material in the Inspector
    public float holeSizeValue = 0.3f;
    public float holeDepthValue = 0.3f;
    public Camera mainCamera;

    void Start()
    {
        holeMaterial.SetVector("_HolePosition", new Vector3(0, 0, 0));
        holeMaterial.SetFloat("_HoleSize", 0.3f);
        holeMaterial.SetFloat("_HoleDepth", 0.3f);
    }


    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Hit " + hit.collider.name);
                holeMaterial.SetVector("_HolePosition", hit.point);
                holeMaterial.SetFloat("_HoleSize", holeSizeValue);
                holeMaterial.SetFloat("_HoleDepth", holeDepthValue);
            }
            else
            {
                Debug.Log("No hit");
            }
        }
    }

}
