using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shy : UnconventionalVictim
{
    public float publicSpace = 10.0f;
    public float personalSpace = 2.0f;
    public float speed = 1.0f;
    public float maxStareTime = 1.0f;

    private float anxiety = 0.0f;
    private Dictionary<UnconventionalWeapon, float> watchers;

    void Start()
    {
        watchers = new Dictionary<UnconventionalWeapon, float>();
    }

    void Update()
    {
        anxiety -= 0.01f;
        if (anxiety < 0.0f) anxiety = 0.0f;
        if (anxiety > 10.0f) BackAway();
    }

    private void BackAway()
    {
        if (watchers.Count == 0) return;

        foreach (KeyValuePair<UnconventionalWeapon, float> kvp in watchers)
        {
            float since = Time.time - kvp.Value;  // Time.time at OnLookAt
            if (since > maxStareTime)
            {
                float distance = Vector3.Distance(transform.position, kvp.Key.transform.position);
                if (distance < publicSpace)
                {
                    float closeness = 1.0f;
                    if (distance > personalSpace)
                        closeness = (distance - personalSpace) / (publicSpace - personalSpace);
                    Vector3 newPosition = new Vector3(kvp.Key.transform.position.x, transform.position.y, kvp.Key.transform.position.z);
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, -speed * closeness * Time.deltaTime);
                }
            }
        }
    }

    public override void OnLookAt(UnconventionalWeapon eye)
    {
        if (debug) Debug.Log("Help! " + eye.name + " is looking at me!  " + anxiety);
        watchers.Add(eye, Time.time);
    }

    public override void OnLookAway(UnconventionalWeapon eye)
    {
        if (debug) Debug.Log("Nevermind, " + eye.name + " left me alone.  " + anxiety);
        watchers.Remove(eye);
    }

    public override void OnStareAt(UnconventionalWeapon eye)
    {
        anxiety += 0.1f;  // TODO: * distance from self to eye
    }
}
