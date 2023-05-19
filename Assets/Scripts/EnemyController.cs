using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPos;
    Vector3 targetPos;
    Vector3 endPos;
    public float speed;
    public float rotateSpeed;
    public float endPosX;
    public float timeDuration;
    public float timeDelay;
    public float timeDurationReset;
    public float timeDelayReset;
    bool rotateEnemyEndPos;
    bool rotateEnemyStartPos;



    private Quaternion targetRotation; // Hướng xoay mục tiêu
    void Start()
    {
        timeDuration = 0;
        timeDurationReset = 0;
        timeDelay = 1.5f;
        timeDelayReset = 2.5f;
        targetRotation = Quaternion.Euler(0, 90f, 0);
        startPos = transform.position;
        targetPos = new Vector3(endPosX, startPos.y, startPos.z);
        endPos = targetPos;
    }

    void Update()
    {
        if (GameManager.instance.GetStateGame()) return;
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, targetPos) < 0.1f)
        {

            if (targetPos == endPos)
            {
                rotateEnemyEndPos = true;
                targetPos = startPos;
            }
            else
            {
                rotateEnemyStartPos = true;
                targetPos = endPos;
            }
        }
        if (rotateEnemyEndPos)
        {
            RotateEnemy(180);
            print("rotateEnemyEndPos :" + rotateEnemyEndPos);


        }

        if (rotateEnemyStartPos)
        {
            print("RotateEnemyStartPos: " + rotateEnemyStartPos);
            RotateEnemy(358f);
        }

    }
    void RotateEnemy(float angle)
    {
        if (timeDuration < timeDelay)
        {
            speed = 0;
            transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
            if (transform.rotation.eulerAngles.y - angle > 0.00000001f)
            {
                transform.rotation = Quaternion.Euler(0, angle, 0);
            }
            timeDuration += Time.deltaTime;
        }

        if (timeDuration > timeDelay)
        {
            speed = 30;
            if (rotateEnemyEndPos)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);

            }
            if (rotateEnemyStartPos)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);

            }
            rotateEnemyEndPos = false;
            rotateEnemyStartPos = false;
            timeDuration = 0;
        }
    }









}
