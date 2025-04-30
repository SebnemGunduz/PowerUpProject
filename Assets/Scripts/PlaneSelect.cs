using UnityEngine;

public class PlaneSelect : MonoBehaviour
{
    private Animator animator;
    private bool hasStarted = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Oyunun baþladýðýný varsayýyoruz (buraya özel bir kontrol gerekiyorsa eklenebilir)
        if (!hasStarted) hasStarted = true;

        if (hasStarted && Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Select");
        }
    }
}
