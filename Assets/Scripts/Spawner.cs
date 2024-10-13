using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner Instance { get; private set; }

    [SerializeField] private int packagesToSpawn = 0, costumersToSpawn = 0, speedUpsToSpawn = 0;
    [SerializeField] private Transform packageParent, costumerParent, speedUpParent;
    [SerializeField] private GameObject packagePrefab, costumerPrefab, speedUpPrefab;
    [SerializeField] private List<Transform> packageSpawnPoints, costumerSpawnPoints, speedUpSpawnPoints;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("More than one spawner");
        }
        Instance = this;
    }

    private void Start()
    {
        PackageEventHandler.PackagedPickedUp += SpawnPackage;
        PackageEventHandler.CostumerRecievedPackage += SpawnCostumer;
        PackageEventHandler.SpeedUpPickedUp += SpawnSpeedUp;

        InitSpawns();
    }

    private void SpawnPackage(object sender, EventArgs eventArgs)
    {
        int spawnPointNumber = GetRandomSpawnPoint(packageSpawnPoints);
        Vector3 spawnPosition = new(packageSpawnPoints[spawnPointNumber].position.x, packageSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(packagePrefab, spawnPosition, packageSpawnPoints[spawnPointNumber].rotation, packageParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }
    private void SpawnPackage()
    {
        int spawnPointNumber = GetRandomSpawnPoint(packageSpawnPoints);
        Vector3 spawnPosition = new(packageSpawnPoints[spawnPointNumber].position.x, packageSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(packagePrefab, spawnPosition, packageSpawnPoints[spawnPointNumber].rotation, packageParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }

    private void SpawnCostumer(object sender, EventArgs eventArgs)
    {
        int spawnPointNumber = GetRandomSpawnPoint(costumerSpawnPoints);
        Vector3 spawnPosition = new(costumerSpawnPoints[spawnPointNumber].position.x, costumerSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(costumerPrefab, spawnPosition, costumerSpawnPoints[spawnPointNumber].rotation, costumerParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }

    private void SpawnCostumer()
    {
        int spawnPointNumber = GetRandomSpawnPoint(costumerSpawnPoints);
        Vector3 spawnPosition = new(costumerSpawnPoints[spawnPointNumber].position.x, costumerSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(costumerPrefab, spawnPosition, costumerSpawnPoints[spawnPointNumber].rotation, costumerParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }

    private void SpawnSpeedUp(object sender, EventArgs eventArgs)
    {
        int spawnPointNumber = GetRandomSpawnPoint(speedUpSpawnPoints);
        Vector3 spawnPosition = new(speedUpSpawnPoints[spawnPointNumber].position.x, speedUpSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(speedUpPrefab, spawnPosition, speedUpSpawnPoints[spawnPointNumber].rotation, speedUpParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }

    private void SpawnSpeedUp()
    {
        int spawnPointNumber = GetRandomSpawnPoint(speedUpSpawnPoints);
        Vector3 spawnPosition = new(speedUpSpawnPoints[spawnPointNumber].position.x, speedUpSpawnPoints[spawnPointNumber].position.y, 0);

        GameObject spawnedObject = Instantiate(speedUpPrefab, spawnPosition, speedUpSpawnPoints[spawnPointNumber].rotation, speedUpParent);
        spawnedObject.GetComponent<ObjectNumber>().SetSpawnPositionNumber(spawnPointNumber);
    }
    private int GetRandomSpawnPoint(List<Transform> spawnPoints)
    {
        int number = GetRandomNumber(spawnPoints.Count);

        while (spawnPoints[number] == null || spawnPoints[number].GetComponent<SpawnPointOccupied>().GetIsOccupied())
        {
            number = GetRandomNumber(spawnPoints.Count);
        }

        if (spawnPoints[number] != null)
        {
            spawnPoints[number].GetComponent<SpawnPointOccupied>().SetIsOccupied(true);
        }

        return number;
    }

    private int GetRandomNumber(int maxAmountExcl)
    {
        return UnityEngine.Random.Range(0, maxAmountExcl);
    }

    private void InitSpawns()
    {
        for (int i = 0; i < packagesToSpawn; i++)
        {
            SpawnPackage();
        }
        for (int i = 0; i < costumersToSpawn; i++)
        {
            SpawnCostumer();
        }
        for (int i = 0; i < speedUpsToSpawn; i++)
        {
            SpawnSpeedUp();
        }
    }

    public void ClearPackageSpawnPointPosition(int spawnPositionNumber)
    {
        packageSpawnPoints[spawnPositionNumber].GetComponent<SpawnPointOccupied>().SetIsOccupied(false);
    }
    public void ClearCostumerSpawnPointPosition(int spawnPositionNumber)
    {
        costumerSpawnPoints[spawnPositionNumber].GetComponent<SpawnPointOccupied>().SetIsOccupied(false);
    }
    public void ClearSpeedUpSpawnPointPosition(int spawnPositionNumber)
    {
        speedUpSpawnPoints[spawnPositionNumber].GetComponent<SpawnPointOccupied>().SetIsOccupied(false);
    }
}
