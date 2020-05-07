using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{
    [SerializeField]
    Transform[] wayPoints;
    int currentWayPoint = 0;
    Rigidbody RidgibB;
    [SerializeField]
    float moveSpeed = 5;
    // Start is called before the first frame update
    void Start()
    {
        RidgibB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement();
    }
    void movement()
    {
        if (Vector3.Distance(transform.position, wayPoints[currentWayPoint].position) < .25f)
            {
            currentWayPoint += 1;
            currentWayPoint = currentWayPoint % wayPoints.Length;
        }   
        Vector3 _dir = (wayPoints[currentWayPoint].position - transform.position).normalized;
        RidgibB.MovePosition(transform.position + _dir * moveSpeed * Time.deltaTime);
    }
}
