using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject replayGameDisplay, continueGameDisplay;
    [SerializeField] private float speed;
    Rigidbody rb;
    public float horizontal;
    public float vertical;
    Vector2 move;
    Vector3 startPos;
    bool checkWinZone = true;


    void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;
       
    }
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(horizontal,0,vertical).normalized;
        rb.velocity = movement * speed*Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            replayGameDisplay.SetActive(true);
            transform.position = startPos;
        }
  
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("WinZone"))
        {
            print("Win zone");
            continueGameDisplay.SetActive(true);
            transform.position = startPos;
        }
    }





}
