using UnityEngine;

public class SpawnPointOccupied : MonoBehaviour
{
    private bool isOccupied = false;

    public void SetIsOccupied(bool value)
    {
        isOccupied = value;
    }

    public bool GetIsOccupied()
    {
        return isOccupied;
    }
}
