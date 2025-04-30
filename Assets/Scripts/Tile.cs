using UnityEngine;

public class Tile : MonoBehaviour
{
    private bool isAvailable = true;

    public void SetAvailable(bool available)
    {
        isAvailable = available;
    }

    public bool IsAvailable()
    {
        return isAvailable;
    }
}
