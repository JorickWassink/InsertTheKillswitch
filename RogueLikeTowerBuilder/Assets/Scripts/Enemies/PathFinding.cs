using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding : MonoBehaviour
{
    Rigidbody2D rb;

    TargetID[] targets;
    float speed;
    int currentTarget = 0;


    void Start()
    {

        rb = GetComponent<Rigidbody2D>();

        targets = FindObjectsByType<TargetID>(FindObjectsSortMode.None);

        Array.Sort(targets, (a, b) => a.id.CompareTo(b.id));


    }

    void Update()
    {
        
        this.speed = GetComponent<Enemy>().speed;

        if (currentTarget >= targets.Length) return;

        Transform target = targets[currentTarget].gameObject.transform;

        Vector2 direction = (target.position - transform.position).normalized;

        transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (Vector2.Distance(transform.position, target.position) < 0.1f)
        {
            currentTarget++;
        }
    }


}