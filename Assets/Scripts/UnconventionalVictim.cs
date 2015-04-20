using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnconventionalVictim : MonoBehaviour 
{
    public bool debug = false;
    protected Dictionary<UnconventionalWeapon, float> watchers;

    public virtual void Start()
    {
        watchers = new Dictionary<UnconventionalWeapon, float>();
    }

    public virtual void OnLookAt(UnconventionalWeapon eye)
    {
        watchers.Add(eye, Time.time);
    }

    public virtual void OnStareAt(UnconventionalWeapon eye) { }

    public virtual void OnLookAway(UnconventionalWeapon eye)
    {
        watchers.Remove(eye);
    }
}
