using System;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    private bool hasPackage;

    [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 hasNoPackageColor = new Color32(1, 1, 1, 1);
    [SerializeField] float DestroyDelay = 0.3f;
    [SerializeField] Countdown timerManager;

    SpriteRenderer spriteRenderer;

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
            spriteRenderer.color = hasPackageColor;

            Destroy(collision.gameObject, DestroyDelay);
        }

        if (collision.CompareTag("Costumer") && hasPackage)
        {
            PackageEventHandler.RaiseCostumerRecievedPackage(this, EventArgs.Empty);

            int spawnPositionNumber = collision.GetComponent<ObjectNumber>().GetSpawnPositionNumber();
            Spawner.Instance.ClearCostumerSpawnPointPosition(spawnPositionNumber);

            hasPackage = false;
            spriteRenderer.color = hasNoPackageColor;
            timerManager.AddTime();

            Destroy(collision.gameObject, DestroyDelay);
        }
    }
}
