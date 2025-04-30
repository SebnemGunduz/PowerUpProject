using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlot : MonoBehaviour
{
    [Header("Slider ve U�ak Ayarlar�")]
    public Slider powerSlider;
    public GameObject[] planes;

    [Header("Slider Ayarlar�")]
    public float fillDuration = 10f; 

    private bool[] slotActivated;
    private float currentTime = 0f;

    void Start()
    {
        if (planes.Length != 8)
        {
            Debug.LogError("L�tfen tam olarak 8 u�ak tan�mlay�n.");
            return;
        }

        slotActivated = new bool[planes.Length];
        powerSlider.value = 0f;
    }

    void Update()
    {
        
        if (powerSlider.value < 1f)
        {
            currentTime += Time.deltaTime;
            powerSlider.value = Mathf.Clamp01(currentTime / fillDuration);
        }

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

        currentTime = 0f;
        powerSlider.value = 0f;
    }
}
