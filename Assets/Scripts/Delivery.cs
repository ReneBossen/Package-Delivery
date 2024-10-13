using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage;

    [SerializeField] private Sprite hasPackageSprite;
    [SerializeField] private Sprite hasNoPackageSprite;
    [SerializeField] private float DestroyDelay = 0.3f;
    [SerializeField] private Countdown timerManager;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && !hasPackage)
        {
            PackageEventHandler.RaisePackagePickedUp(this, EventArgs.Empty);

            int spawnPositionNumber = collision.GetComponent<ObjectNumber>().GetSpawnPositionNumber();
            Spawner.Instance.ClearPackageSpawnPointPosition(spawnPositionNumber);

            hasPackage = true;
            spriteRenderer.sprite = hasPackageSprite;

            Destroy(collision.gameObject, DestroyDelay);
        }

        if (collision.CompareTag("Costumer") && hasPackage)
        {
            PackageEventHandler.RaiseCostumerRecievedPackage(this, EventArgs.Empty);

            int spawnPositionNumber = collision.GetComponent<ObjectNumber>().GetSpawnPositionNumber();
            Spawner.Instance.ClearCostumerSpawnPointPosition(spawnPositionNumber);

            hasPackage = false;
            spriteRenderer.sprite = hasNoPackageSprite;
            timerManager.AddTime();

            Destroy(collision.gameObject, DestroyDelay);
        }
    }
}
