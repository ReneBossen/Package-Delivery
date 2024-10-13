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
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.pitch = UnityEngine.Random.Range(0.7f, 0.8f);
    }

    void Update()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        if (moveAmount != 0)
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            if (moveAmount < 0) steerAmount = Input.GetAxis("Horizontal") * -steerSpeed * Time.deltaTime;
            else steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
            transform.Rotate(0, 0, -steerAmount);
        }
        else
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }

        transform.Translate(0, moveAmount, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpeedUp"))
        {
            audioSource.pitch = UnityEngine.Random.Range(0.7f, 0.8f);
            PackageEventHandler.RaiseSpeedUpPickedUp(this, EventArgs.Empty);

            int spawnPositionNumber = collision.GetComponent<ObjectNumber>().GetSpawnPositionNumber();
            Spawner.Instance.ClearSpeedUpSpawnPointPosition(spawnPositionNumber);

            moveSpeed = boostSpeed;

            Destroy(collision.gameObject, destroyDelay);
        }

        if (collision.CompareTag("Grass"))
        {
            audioSource.pitch = UnityEngine.Random.Range(0.3f, 0.4f);
            moveSpeed = grassSpeed;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Grass"))
        {
            audioSource.pitch = UnityEngine.Random.Range(0.6f, 0.7f);
            moveSpeed = slowSpeed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.pitch = UnityEngine.Random.Range(0.6f, 0.7f);
        moveSpeed = slowSpeed;
    }
}
