using UnityEngine;
using System.Collections;

public class UnconventionalWeapon : MonoBehaviour
{
    public bool debug = false;

    public float distance = 10.0f;

    protected RaycastHit hit;
    protected GameObject target;

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

    protected virtual void OnLookAway()
    {
        if (target == null) return;
        if (debug) Debug.Log("not looking at " + target.name);

        UnconventionalVictim uv = target.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnLookAway(this);
    }

    protected virtual void OnLookAt()
    {
        if (debug) Debug.Log("look, it's " + hit.collider.gameObject.name + "!");

        UnconventionalVictim uv = hit.collider.gameObject.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnLookAt(this);
    }

    protected virtual void OnStareAt()
    {
        UnconventionalVictim uv = target.GetComponent<UnconventionalVictim>();
        if (uv != null) uv.OnStareAt(this);
    }

    protected virtual void OnLookAtNothing()
    {
        //Debug.Log("look, it's nothing, again");
    }
}
