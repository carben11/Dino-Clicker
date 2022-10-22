using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour
{
    Animator anim;

    private void Update()
    {
        anim = GetComponent<Animator>();
    }

    public void Hatch()
    {
        anim.SetTrigger("Crack");
    }
}
