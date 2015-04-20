using UnityEngine;
using System.Collections;

public class BackAway : UnconventionalVictim
{
    public bool randomize = true;
    public float personalSpace = 10.0f;
    public float moveSpeed = 1.0f;
    public float viewAngle = 20.0f;
    public float bodyTurnSpeed = 1.0f;
    public float headTurnSpeed = 0.5f;
    public GameObject head;

    void Start()
    {
        if (randomize)
        {
            personalSpace = Random.Range(2.0f, 10.0f);
            moveSpeed = Random.Range(0.5f, 5.0f);
            viewAngle = Random.Range(1.0f, 90.0f);
            bodyTurnSpeed = Random.Range(0.25f, 5.0f);
            headTurnSpeed = Random.Range(0.1f, 2.0f);
        }
    }

    public override void OnStareAt(UnconventionalWeapon eye)
    {
        Vector3 eyePositionXZ = new Vector3(eye.transform.position.x, transform.position.y, eye.transform.position.z);
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                transform.forward,
                eyePositionXZ - transform.position,
                bodyTurnSpeed * Time.deltaTime, 0.0f));

        if (head)
            head.transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
                head.transform.forward,
                eye.transform.position - head.transform.position,
                headTurnSpeed * Time.deltaTime, 0.0f));

        float angle = Vector3.Angle(head ? head.transform.forward : transform.forward, -eye.transform.forward);
        if (angle < viewAngle)
        {
            float distance = Vector3.Distance(eye.transform.position, transform.position);
            if (distance < personalSpace)
                transform.position = Vector3.MoveTowards(transform.position, eyePositionXZ, -moveSpeed * personalSpace/distance * Time.deltaTime);
        }
    }

    void Update()
    {
        Debug.DrawRay(transform.position, transform.forward, Color.green);
        if (head)
            Debug.DrawRay(head.transform.position, head.transform.forward, Color.blue);
    }
}
