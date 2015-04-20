using UnityEngine;
using System.Collections;

public class UnconventionalWeapon : MonoBehaviour
{
    public bool debug = false;

    protected RaycastHit hit;
    protected GameObject target;

    void Update()
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(transform.position, forward, Color.red);
        if (Physics.Raycast(transform.position, forward, out hit))
        {
            UnconventionalVictim uv;
            if (target != hit.collider.gameObject)
            {
                if (debug) Debug.Log(name + " looks away from " + target.name);
                OnLookAway();
                if (target != null)
                {
                    uv = target.GetComponent<UnconventionalVictim>();
                    if (uv != null) uv.OnLookAway(this);
                }

                if (debug) Debug.Log(name + " looks at " + hit.collider.gameObject.name);
                OnLookAt();
                uv = hit.collider.gameObject.GetComponent<UnconventionalVictim>();
                if (uv != null) uv.OnLookAt(this);
            }
            else
            {
                OnStareAt();
                uv = target.GetComponent<UnconventionalVictim>();
                if (uv != null) uv.OnStareAt(this);
            }
            target = hit.collider.gameObject;
        }
        else
        {
            if (debug) Debug.Log(name + " looks away from " + target.name);
            OnLookAway();
            target = null;

            if (debug) Debug.Log(name + " looks at nothing.");
            OnLookAtNothing();
        }
    }

    protected virtual void OnLookAway() { }
    protected virtual void OnLookAt() { }
    protected virtual void OnStareAt() { }
    protected virtual void OnLookAtNothing() { }
}
