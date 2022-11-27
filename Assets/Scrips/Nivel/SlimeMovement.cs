using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    [SerializeField] private Vector3 initialPos;
    [SerializeField] private Vector3 finalPos;
    [SerializeField] private int distance;
    [SerializeField] private float speed = 8f;
    [SerializeField] private Animator animator;
    private bool attack;
    [SerializeField] private GameObject attackCube;


    void FireRay()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitData;
        Physics.Raycast(ray, out hitData);
        if (hitData.distance < 2 && hitData.transform.tag == "Player")
        {
            animator.SetBool("Attack", true);
            attack = true;
            attackCube.SetActive(true);
            //Debug.Log(hitData.transform.tag);
        }
        else
        {
            animator.SetBool("Attack", false);
            attack = false;
            attackCube.SetActive(false);
        }
        
        //Debug.Log(hitData.distance);
    }

    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;
        finalPos = initialPos - new Vector3(distance, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(initialPos, finalPos, Mathf.PingPong(Time.time * speed, 1.0f));
        if (!attack)
        {
            transform.position += transform.forward * Time.deltaTime * speed;
        }
        
        if (transform.position.x <= finalPos.x)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (transform.position.x >= initialPos.x)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        FireRay();

    }
}
