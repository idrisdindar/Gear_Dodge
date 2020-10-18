using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private Animator animator = null;

    private Vector3 targetPos = Vector3.zero;
    internal bool isDestroyed = false;
    private void Start()
    {
        targetPos = new Vector2(Random.Range(-4, 4), Random.Range(-6, 6));
        Invoke("Disappear",Random.Range(6,8));
    }
    private void Update()
    {
        if (!isDestroyed)
        {

            if (Vector2.Distance(transform.position, targetPos) < 0.1f)
            {
                targetPos = new Vector2(Random.Range(-4, 4), Random.Range(-6, 6));
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            }
            transform.Rotate(Vector3.forward * rotSpeed);
        }
    }
    private void Disappear()
    {
        GearSpawner.count--;
        animator.SetTrigger("Disappear");
        Destroy(gameObject, 1f);
    }

}
