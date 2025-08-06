using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.gameObject.tag == "DeformableMesh")
                {
                    MeshDeformer deformer = hit.transform.GetComponent<MeshDeformer>();
                    if (deformer != null)
                    {
                        deformer.Deform(hit.point, 1.0f, 0.1f, -1.0f, -0.1f, hit.normal);
                       // StartCoroutine(DelayedCut(deformer, hit.point));
                    }
                }
            }
        }
    }

    IEnumerator DelayedCut(MeshDeformer deformer, Vector3 point)
    {
        yield return new WaitForSeconds(1f); // 2-second delay
        deformer.CutHole(point);
    }

}
