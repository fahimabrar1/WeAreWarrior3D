using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [Title("Health Bar Data Types")]
    public Slider slider;

    public int initialHealth;
    public Camera mainCamera;




    #region Mono Methods
    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        mainCamera = Camera.main;
    }



    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if (mainCamera != null)
        {
            // Calculate the direction from the object to the camera
            Vector3 lookDir = mainCamera.transform.position - transform.position;
            Quaternion rotation = Quaternion.LookRotation(-lookDir);
            rotation.y = 0;
            rotation.z = 0;
            transform.rotation = rotation;
        }
    }
    #endregion

    #region Methods

    /// <summary>
    /// Passes the current health value to set the normalized value to sldier
    /// </summary>
    /// <param name="currentHealth">the current health of the sodlier</param>
    public void OnSetHealth(int currentHealth)
    {
        slider.value = currentHealth * 1.0f / initialHealth;
    }


    /// <summary>
    /// Sets the initial health value, which can be used to normalize it
    /// </summary>
    /// <param name="val">the total health</param>
    public void SetInitialHealth(int val)
    {
        initialHealth = val;
        OnSetHealth(initialHealth);
    }
    #endregion
}
