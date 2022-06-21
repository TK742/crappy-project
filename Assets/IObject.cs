using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IObject : MonoBehaviour
{
    private Renderer r;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        r = GetComponent<Renderer>();
        Change();
    }

    public void Change()
    {
        r.material.color = (r.material.color == Color.red ? Color.green : Color.red);
    }
}
