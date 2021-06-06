using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public GameObject spawnedBall;
    public Transform pL, pR;
    private float moveSpeed = 1.0f, timer = 0.0f, shootTime = 0.0f;
    private bool shootEnabled = true, increase = true;
    private AudioSource audio;

    private void OnSceneLoaded()
    {
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        OnSceneLoaded();
        audio = GetComponent<AudioSource>();
        LevelGenerator.Instance.LevelIsUp += EnableShooting;
        LevelGenerator.Instance.LevelIsUp += IncreaseMoveSpeed;
    }
    private void FixedUpdate()
    {
        if (increase) timer += moveSpeed * Time.deltaTime;
        else timer += moveSpeed * Time.deltaTime;
        if (!shootEnabled) shootTime += Time.deltaTime;
        if (shootTime > 2.0f) GameIsEnd();
        BallMoving(pL.position, pR.position, moveSpeed);
    }

    void Update()
    {
        if (Time.timeScale == 0) return;
        if (Input.touchCount > 0 && (Input.GetTouch(0).position.y < Screen.height / 2) && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            ShootBall();
        }
    }

    private void IncreaseCalc()
    {
        if (timer > 1) increase = false;
        else if (timer < 0) increase = true;

    }

    private void BallMoving(Vector3 leftPoint, Vector3 rightPoint, float speed)
    {
        transform.position = Vector3.Lerp(leftPoint, rightPoint, Mathf.PingPong(timer, 1));
    }

    public void ShootBall()
    {
        if (shootEnabled)
        {
            //spawnedBall = Instantiate(spawnedBall, this.transform.position, Quaternion.identity);
            spawnedBall.gameObject.SetActive(true);
            spawnedBall.transform.position = this.transform.position;
            Rigidbody rb = spawnedBall.GetComponent<Rigidbody>();
            rb.AddForce(Vector3.forward * 1000);
            audio.Play();
            shootEnabled = false;
        }
    }

    private void EnableShooting()
    {
        shootEnabled = true;
        shootTime = 0.0f;
    }

    private void IncreaseMoveSpeed()
    {
        moveSpeed += 0.02f;
    }

    private void GameIsEnd()
    {
        UIManager.Instance.FinishGame();
    }
}