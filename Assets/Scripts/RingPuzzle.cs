using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    private bool ring1;
    private bool ring2;
    private bool ring3;

    public Material[] materials;
    public GameObject bricks;

    private void Start()
    {
        SetBrickMaterial(0);
    }
    public void SetRingStatus(int ring,bool status)
    {
        switch(ring)
        {
            case 1:ring1 = status;break;
            case 2:ring2 = status;break;
            case 3:ring3 = status;break;
        }
        CheckPuzzle();
    }

    private void CheckPuzzle()
    {
        if(ring1&&ring2&&ring3)
        {
            Animator doorAnimator = gameObject.GetComponent<Animator>();
            doorAnimator.SetTrigger("Open");
            SetBrickMaterial(1);
        }
    }

    private void SetBrickMaterial(int i)
    {
        MeshRenderer[] meshes = bricks.GetComponentsInChildren<MeshRenderer>();
        foreach(MeshRenderer m in meshes)
        {
            m.material = materials[i];
        }
    }
}
