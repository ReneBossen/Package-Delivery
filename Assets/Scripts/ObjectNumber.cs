using UnityEngine;

public class ObjectNumber : MonoBehaviour
{
    private int spawnPositionNumber;

    public void SetSpawnPositionNumber(int number)
    {
        spawnPositionNumber = number;
    }

    public int GetSpawnPositionNumber()
    {
        return spawnPositionNumber;
    }
}