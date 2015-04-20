using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shy : UnconventionalVictim
{
    public Collider personalSpace;
    public float maxStareLength = 1.0f;

    [Tooltip("Minimum time, in seconds, to walk one meter at normal speed.")]
    public float minWalkTime = 2.0f;
    [Tooltip("Maximum time, in seconds, to walk one meter at normal speed.")]
    public float maxWalkTime = 3.0f;
    public float normalSpeed = 1.0f;
    public float nervousSpeed = 1.25f;
    public float panicSpeed = 2.0f;

    public BoxCollider targetZone;
    private Vector3 targetPosition = Vector3.zero;
    private bool isInTargetZone = false;
    private float travelTime;

    public enum Mood { normal, nervous, panic }
    private Mood mood = Mood.normal;

    private Vector3 velocity = Vector3.zero;

    void Start()
    {
        UpdateTarget();
        if (!personalSpace) Debug.LogError("Shy " + name + " has no personal space.");
    }

    void Update()
    {
        /*if (watchers.Count == 0)
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
        float speed = (mood == Mood.normal) ? normalSpeed : (mood == Mood.nervous) ? nervousSpeed : panicSpeed;*/
        float speed = normalSpeed;

        // target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            UpdateTarget();
        Debug.DrawLine(transform.position, targetPosition, Color.yellow);

        // rotation
        Vector3 targetDirection = targetPosition - transform.position;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, speed * Time.deltaTime, 0.0f);
        Debug.DrawRay(transform.position, newDirection, Color.green);
        transform.rotation = Quaternion.LookRotation(newDirection);

        // position
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, travelTime / speed);
    }

    public void UpdateTarget()
    {
        // pick a new random point inside targetZone's bounds
        UpdateTarget(new Vector3(
            Random.Range(targetZone.bounds.min.x, targetZone.bounds.max.x),
            Random.Range(targetZone.bounds.min.y, targetZone.bounds.max.y),
            Random.Range(targetZone.bounds.min.z, targetZone.bounds.max.z)
         ));
    }

    public void UpdateTarget(Vector3 newTarget)
    {
        targetPosition = new Vector3(newTarget.x, transform.position.y, newTarget.z);
        travelTime = Vector3.Distance(transform.position, targetPosition) * Random.Range(minWalkTime, maxWalkTime);
        Debug.Log(name + " has a new target: " + targetPosition.x + "," + targetPosition.z);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (!isInTargetZone && (other == targetZone))
        {
            isInTargetZone = true;
            if (debug) Debug.Log(name + " entered target zone " + targetZone.name);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (isInTargetZone && (other == targetZone))
        {
            isInTargetZone = false;
            if (debug) Debug.Log(name + " left target zone " + targetZone.name);
        }
    }
}
