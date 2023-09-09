using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEditor.Experimental.GraphView;

public class DummyAI : MonoBehaviour
{

    public bool targetPlayer;

    private Transform player;

    private Vector2 startingPosition;
    public float movementSpeed;
    public float nextWaypointDistance = 3f;

    private Path path;
    private int currentWaypoint = 0;
    private bool reachedEnd = false;

    Seeker seeker;
    Rigidbody2D rb;
    Vector2 direction;
    private bool playerOnReach = false;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();

        player = FindObjectOfType<GameManager>().player.transform;
        startingPosition = rb.position;

        
        InvokeRepeating("UpdatePath", 0f, 0.5f);
        
    }

    // FixedUpdate is called once per whatever default is
    void FixedUpdate()
    {
        if(path == null){
            return;
        }

        reachedEnd = currentWaypoint >= path.vectorPath.Count;
        if(reachedEnd){
            rb.velocity = Vector2.zero;
            return;
        }

        direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

        rb.velocity = direction * movementSpeed;

        if(Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance)
            currentWaypoint++;
    }

    //updates path every second
    void UpdatePath(){

        if(seeker.IsDone())
            if(targetPlayer)
                seeker.StartPath(rb.position, player.position, OnPathComplete);
            else{
                seeker.StartPath(rb.position, startingPosition, OnPathComplete);
            }
    }



    void OnPathComplete(Path p){
        if(targetPlayer && p.vectorPath.Count > 1)
            playerOnReach = Vector2.Distance(player.position, p.vectorPath[p.vectorPath.Count-1]) < 1f;
        else{
            playerOnReach = Vector2.Distance(player.position, startingPosition) < 100f;
        }
            

        if(!p.error && playerOnReach){
            targetPlayer = true;
            path = p;
            currentWaypoint = 0;
        }else{
            targetPlayer = false;
        }
    }
}
