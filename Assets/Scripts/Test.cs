using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    float degreesPerSecond = 2;
    bool rotate;
    private void Update()
    {
    
        {
            transform.Rotate(new Vector3(0, degreesPerSecond, 0));
        
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rotate = true;
            print("H");
        }
    }
}
