using UnityEngine;
using System.Collections;

public class UnconventionalWeapon : MonoBehaviour
{
    public float distance = 10.0f;
    public Material blush;

    private RaycastHit hit;
    private GameObject target;
    private Material lastMaterial;

    void Update()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, fwd, out hit, distance))
        {
            if (hit.collider.gameObject != target)
            {
                if (target != null) OnLookAway();
                OnLookAt();
            }
            else
                OnStareAt();

            target = hit.collider.gameObject;
        }
        else
        {
            if (target != null) OnLookAway();
            OnLookAtNothing();
        }
    }

    private void OnLookAway()
    {
        Debug.Log("not looking at " + target.name);
        target.transform.renderer.sharedMaterial = lastMaterial;
        target = null;
    }

    private void OnLookAt()
    {
        Debug.Log("look, it's " + hit.collider.gameObject.name + "!");
        lastMaterial = hit.transform.renderer.sharedMaterial;
        hit.transform.renderer.sharedMaterial = blush;
    }

    private void OnStareAt()
    {
        //Debug.Log("look, it's " + lastHit.collider.gameObject.name + ", again");
    }

    private void OnLookAtNothing()
    {
        //Debug.Log("look, it's nothing, again");
    }
}
