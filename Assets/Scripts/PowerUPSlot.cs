using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlot : MonoBehaviour
{
    [Header("Slider ve U�ak Ayarlar�")]
    public Slider powerSlider; 
    public GameObject[] planes; 

    private bool[] slotActivated;

    void Start()
    {
        if (planes.Length != 8)
        {
            Debug.LogError("L�tfen tam olarak 8 u�ak tan�mlay�n.");
            return;
        }

        slotActivated = new bool[planes.Length];
    }

    void Update()
    {
        float currentValue = powerSlider.value; 
        float slotStep = 1f / planes.Length;

        for (int i = 0; i < planes.Length; i++)
        {
            if (!slotActivated[i] && currentValue >= slotStep * (i + 1))
            {
                slotActivated[i] = true;

                
                Debug.Log($"U�ak {i + 1} kalk��a haz�r.");

                
                
            }
        }
    }

    public void ResetSlots()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            slotActivated[i] = false;
        }
    }
}
