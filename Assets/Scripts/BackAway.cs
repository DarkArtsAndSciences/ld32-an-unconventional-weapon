using UnityEngine;
using System.Collections;

public class BackAway : UnconventionalVictim
{
    public float moveSpeed = 1.0f;
    public float viewAngle = 20.0f;
    public float bodyTurnSpeed = 1.0f;
    public float headTurnSpeed = 0.5f;
    public GameObject head;

    public override void OnStareAt(UnconventionalWeapon eye)
    {
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward,
            new Vector3(eye.transform.position.x - transform.position.x, 0, eye.transform.position.z - transform.position.z),
            bodyTurnSpeed * Time.deltaTime, 0.0f));

        if (head)
            head.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                head.transform.forward,
                eye.transform.position - head.transform.position,
                headTurnSpeed * Time.deltaTime, 0.0f));

        float angle = Vector3.Angle(head ? head.transform.forward : transform.forward, -eye.transform.forward);
        if (angle < viewAngle)
        {
            Vector3 away = new Vector3(0, 0, -eye.transform.forward.z);
            away.Normalize();
            transform.Translate(away * moveSpeed * Time.deltaTime);
        }
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (head)
            Debug.DrawRay(head.transform.position, head.transform.forward, Color.blue);
    }
}
