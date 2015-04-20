using UnityEngine;
using System.Collections;

public class LockYRotation : MonoBehaviour
{
    private Vector3 initialRotation;

    void Start()
    {
        initialRotation = transform.rotation.eulerAngles;
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, initialRotation.y, transform.rotation.z));
    }
}
