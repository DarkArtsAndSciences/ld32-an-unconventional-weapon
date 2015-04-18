using UnityEngine;
using System.Collections;

public class UnconventionalWeapon : MonoBehaviour
{
    public bool debug = false;

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
                OnLookAway();
                OnLookAt();
            }
            else
            {
                OnStareAt();
            }
            target = hit.collider.gameObject;
        }
        else
        {
            OnLookAway();
            target = null;
            OnLookAtNothing();
        }
    }

    private void OnLookAway()
    {
        if (target == null) return;

        if (debug) Debug.Log("not looking at " + target.name);

        target.renderer.sharedMaterial = lastMaterial;

        UnconventionalVictim uv = target.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnLookAway(this);
    }

    private void OnLookAt()
    {
        if (debug) Debug.Log("look, it's " + hit.collider.gameObject.name + "!");

        lastMaterial = hit.collider.gameObject.renderer.sharedMaterial;
        hit.collider.gameObject.renderer.sharedMaterial = blush;

        UnconventionalVictim uv = hit.collider.gameObject.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnLookAt(this);
    }

    private void OnStareAt()
    {
        UnconventionalVictim uv = target.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnStareAt(this);
    }

    private void OnLookAtNothing()
    {
        //Debug.Log("look, it's nothing, again");
    }
}
