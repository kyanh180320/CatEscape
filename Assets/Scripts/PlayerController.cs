using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject endGameScreen;
    [SerializeField] GameObject continueButton, tryAgainButton;
    [SerializeField] private float speed;
    Rigidbody rb;
    public float horizontal;
    public float vertical;
    Vector2 move;


    void Start()
    {
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
        if (GameManager.instance.GetStateGame()) return;
        Vector3 movement = new Vector3(horizontal,0,vertical).normalized;
        rb.velocity = movement * speed*Time.deltaTime;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("DeadZone"))
        {
            endGameScreen.SetActive(true);
            GameManager.instance.SetStateGame(true);
            SetStateButton(true);
            joystick.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("WinZone"))
        {
            endGameScreen.SetActive(true);
            GameManager.instance.SetStateGame(true);
            SetStateButton(false);
            joystick.gameObject.SetActive(false);


        }
    }
    void SetStateButton(bool state)
    {
        tryAgainButton.SetActive(state);
        continueButton.SetActive(!state);
    }
 

}
