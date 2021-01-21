using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombineMesh : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CombineMeshes(this.gameObject);
    }

    public void CombineMeshes(GameObject obj)
    {
        //Temporarily set position to zero to make matrix math easier
       // Vector3 position = obj.transform.position;
        //obj.transform.position = Vector3.zero;

        //Get all mesh filters and combine
        MeshFilter[] meshFilters = obj.GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];
        int i = 1;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);
            i++;
        }

        obj.transform.GetComponent<MeshFilter>().mesh = new Mesh();
        obj.transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine, true, true);
        obj.transform.gameObject.SetActive(true);

        //Return to original position
       // obj.transform.position = position;

        //Add collider to mesh (if needed)
        //obj.AddComponent<MeshCollider>();
    }
}
