using System;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 200f;
    [SerializeField] float moveSpeed = 12f;
    [SerializeField] float slowSpeed = 8f;
    [SerializeField] float grassSpeed = 4f;
    [SerializeField] float boostSpeed = 17f;
    readonly float destroyDelay = 0.3f;

    private float steerAmount;

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (moveAmount != 0)
        {
            if (moveAmount < 0) steerAmount = Input.GetAxis("Horizontal") * -steerSpeed * Time.deltaTime;
            else steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
        }

        transform.Translate(0, moveAmount, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            PackageEventHandler.RaiseSpeedUpPickedUp(this, EventArgs.Empty);

            int spawnPositionNumber = collision.GetComponent<ObjectNumber>().GetSpawnPositionNumber();
            Spawner.Instance.ClearSpeedUpSpawnPointPosition(spawnPositionNumber);

            moveSpeed = boostSpeed;

            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Grass"))
        {
            moveSpeed = grassSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grass"))
        {
            moveSpeed = slowSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        moveSpeed = slowSpeed;
    }
}
