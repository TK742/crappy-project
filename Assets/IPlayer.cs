using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static OVRInput;
using Button = OVRInput.Button;

public class IPlayer : MonoBehaviour
{
    Transform root;
    [SerializeField] Transform rroot;
    
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        root = Camera.main.transform;
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            var col = Physics.OverlapSphere(rroot.position, 0.5f);
            foreach (var c in col)
            {
                if (c.TryGetComponent<IObject>(out IObject oobj))
                    oobj.Change();
            }
        }


        if (Input.GetKeyDown(KeyCode.R)
        && Physics.Raycast(root.position, root.forward, out RaycastHit hit)
        && hit.collider.TryGetComponent<IObject>(out IObject obj))
        {
            obj.Change();
        }
/*
        if (GetDown(Button.One, Controller.RTouch)
        && Physics.Raycast(root.position, root.forward, out RaycastHit hhit)
        && hhit.collider.TryGetComponent<IObject>(out IObject oobj))
        {
            oobj.Change();
        }
*/
    }

    /// <summary>
    /// Callback to draw gizmos only if the object is selected.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(rroot.position, 0.5f);
    }
}
