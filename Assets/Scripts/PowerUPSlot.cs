using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlot : MonoBehaviour
{
    [Header("Slider ve Uçak Ayarlarý")]
    public Slider powerSlider; 
    public GameObject[] planes; 

    private bool[] slotActivated;

    void Start()
    {
        if (planes.Length != 8)
        {
            Debug.LogError("Lütfen tam olarak 8 uçak tanýmlayýn.");
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

                
                Debug.Log($"Uçak {i + 1} kalkýþa hazýr.");

                
                
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
