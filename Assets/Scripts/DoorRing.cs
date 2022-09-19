using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorRing : Item
{
    public Material[] materials;
    public int no;
    public int turningRate=100;
    Vector3 targetRotation = new Vector3(0, 0, 45);
    public bool solved = false;
    RingPuzzle puzzle;
    private bool rotating=false;

    // Start is called before the first frame update
    private void Start()
    {
        puzzle = GetComponentInParent<RingPuzzle>();
    }
    public override void Interact()
    {
        if (!solved&&!rotating)
        {
            StartCoroutine(Rotate(targetRotation, 0.5f));
        }
    }
     public override string HoverMessage()
    {
        if (solved)
        {
            return "Try Solving other rings to place";
        }
        else
        {
            return "Press E to rotate ring";
        }
    }
    
    private void checkRotation()
    {
        //Debug.Log(Mathf.Round(transform.rotation.eulerAngles.z));
        if(Mathf.Round(transform.rotation.eulerAngles.z)==359|| Mathf.Round(transform.rotation.eulerAngles.z) == 0 )
        {
            gameObject.GetComponent<MeshRenderer>().material = materials[1];
            puzzle.SetRingStatus(no, true);
            solved = true;
        }
        else
        {
            gameObject.GetComponent<MeshRenderer>().material = materials[0];
            puzzle.SetRingStatus(no, false);
        }
    }
    IEnumerator Rotate(Vector3 eulerAngles, float duration)
    {
        if (rotating)
        {
            yield break;
        }
        rotating = true;

        Vector3 newRot = transform.eulerAngles + eulerAngles;

        Vector3 currentRot = transform.eulerAngles;

        float counter = 0;
        while (counter < duration)
        {
            counter += Time.deltaTime;
            transform.eulerAngles = Vector3.Lerp(currentRot, newRot, counter / duration);
            yield return null;
        }
        rotating = false;
        checkRotation();
    }
}
