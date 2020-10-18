using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 0f;
    [SerializeField] private float rotSpeed = 0f;
    [SerializeField] private AudioSource audioSource = null;

    internal static bool isGameOver = false;

    private void Start()
    {
        isGameOver = false;
    }

    private void Update()
    {
        if (!isGameOver)
        {
            TouchControls();
            PlayerReappearence();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            //Gear destroyer
            collision.gameObject.GetComponent<GearController>().isDestroyed = true;
            collision.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            collision.gameObject.transform.GetChild(0).gameObject.SetActive(true);
            
            //Player destroyer
            GetComponent<SpriteRenderer>().enabled = false;
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            isGameOver = true;

            audioSource.Play();
        }
    }
    private void TouchControls()
    {
        transform.Translate(Vector3.up * Time.deltaTime * moveSpeed);
        if (TouchControlsHandler.left)
        {
            transform.Rotate(Vector3.forward * rotSpeed);
        }
        else if (TouchControlsHandler.right)
        {
            transform.Rotate(-Vector3.forward * rotSpeed);
        }
    }
    private void PlayerReappearence()
    {
        if (transform.position.x > 3.5 || transform.position.x < -3.5)
        {
            transform.position = new Vector2(-transform.position.x, transform.position.y);
        }
        if (transform.position.y > 5.5 || transform.position.y < -5.5)
        {
            transform.position = new Vector2(transform.position.x, -transform.position.y);
        }
    }
}
