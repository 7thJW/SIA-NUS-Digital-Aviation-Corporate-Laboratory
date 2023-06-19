using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    private Camera getCam;
    private NavMeshAgent agent;
    private Animator animator;
    public GameObject movepointObj;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        getCam = Camera.main;
        agent = this.gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
                movepointObj.transform.position = hit.point;

            }

        }

        if (agent.velocity.magnitude > 0)
        {
            movepointObj.SetActive(true);
            animator.SetBool("isMoving", true);
        }
        else
        {
            movepointObj.SetActive(false);
            animator.SetBool("isMoving", false);
        }
    }
}
