using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shy : UnconventionalVictim
{
    public Collider personalSpace;
    public float maxStareLength = 1.0f;
    public float normalSpeed = 1.0f;
    public float nervousSpeed = 1.25f;
    public float panicSpeed = 2.0f;

    public BoxCollider targetZone;
    private bool isInTargetZone = false;

    public enum Mood { normal, nervous, panic }
    private Mood mood = Mood.normal;

    public override void Start()
    {
        base.Start();
        if (!personalSpace) Debug.LogError("Shy " + name + " has no personal space.");
    }

    void Update()
    {
        if (watchers.Count == 0)
        {
            mood = Mood.normal;
        }
        else
        {
            float stareLength = 0.0f;
            foreach (KeyValuePair<UnconventionalWeapon, float> kvp in watchers)
            {
                stareLength += (Time.time - kvp.Value);  // kvp.Value == Time.time at OnLookAt
                // TODO: get angle between my forward and their forward (my flee), then average and turn towards it
            }
            mood = stareLength < maxStareLength ? Mood.nervous : Mood.panic;
        }

        if (!isInTargetZone)
            transform.LookAt(targetZone.center);
        Debug.DrawRay(transform.position, transform.forward, Color.green);

        float speed = (mood == Mood.normal) ? normalSpeed : (mood == Mood.nervous) ? nervousSpeed : panicSpeed;
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other == targetZone)
        {
            isInTargetZone = true;
            if (debug) Debug.Log(name + " entered target zone " + targetZone.name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other == targetZone)
        {
            isInTargetZone = false;
            if (debug) Debug.Log(name + " left target zone " + targetZone.name);
        }
    }
}
