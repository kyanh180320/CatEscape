using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Joystick joystick;
    [SerializeField] private GameObject panel;
    [SerializeField] private float speed;
    public TextMeshProUGUI textLoose, textWin;
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
        if (GameManager.instance.GetStateGame()) return;
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
            panel.SetActive(true);
            textLoose.gameObject.SetActive(true);
            GameManager.instance.SetStateGame(true);
            joystick.gameObject.SetActive(false);
        }
        else if (other.gameObject.CompareTag("WinZone"))
        {
            panel.SetActive(true);
            textWin.gameObject.SetActive(true);
            GameManager.instance.SetStateGame(true) ;
            joystick.gameObject.SetActive(false);


        }
    }
 

}
