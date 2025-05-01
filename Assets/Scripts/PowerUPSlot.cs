using UnityEngine;
using UnityEngine.UI;

public class PowerUpSlot : MonoBehaviour
{
    [Header("Slider ve Uçak Ayarlarý")]
    public Slider powerSlider;
    public PlaneFSM[] planes;

    [Header("Slider Ayarlarý")]
    public float fillDuration = 10f; // Slider'ýn 0'dan 1'e kaç saniyede dolacaðý

    private bool[] slotActivated;
    private float currentTime = 0f;

    void Start()
    {
        /*if (planes.Length != 8)
        {
            Debug.LogError("Lütfen tam olarak 8 uçak tanýmlayýn.");
            return;
        }*/

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
                planes[i].isReadyToFly = true;
            }
        }
    }


    /*public void ResetSlots()
    {
        for (int i = 0; i < planes.Length; i++)
        {
            slotActivated[i] = false;
        }

        currentTime = 0f;
        powerSlider.value = 0f;
    }*/
}
