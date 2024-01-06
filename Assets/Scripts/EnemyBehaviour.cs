using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed = 2;
    public Transform currentPoint;
    private int pointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = waypoints[pointIndex].transform;
        rb.velocity = new Vector2(0, speed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MoveTowardsWaypoint();
        RotateTowardsWaypoint();
    }

    void MoveTowardsWaypoint()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentPoint.position, speed);

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f)
        {
            currentPoint = waypoints[(pointIndex++) % waypoints.Length].transform;
        }
    }

    void RotateTowardsWaypoint()
    {
        Vector2 direction = currentPoint.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angle -= 90f;
        rb.rotation = angle;
    }
}
