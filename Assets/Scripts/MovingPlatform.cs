using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private Transform pointA, pointB;
    private float _speed = 3f;
    private Vector3 target;
    // Start is called before the first frame update
    void Start()
    {
        target = pointB.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == pointA.position)
        {
            target = pointB.position;
        }
        else if (transform.position == pointB.position)
        {
            target = pointA.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, _speed * Time.fixedDeltaTime);
        if (transform.position.x > pointB.position.x)
        {
            transform.position = pointB.position;
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = this.transform;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            other.transform.parent = null;
        }
    }
}
