using UnityEngine;

public class DayCycleController : MonoBehaviour
{
    [SerializeField, Range(0, 24)] private float timeOfDay = 12;
    [SerializeField] private LightingPreset preset;
    [SerializeField] private Light sun;
    [SerializeField] private float cycleSpeed = 3f;
    private bool _isDay;

    private void Update()
    {
        // Update time
        timeOfDay += Time.deltaTime / cycleSpeed;
        
        // Ensure time is always between 0-24
        timeOfDay %= 24;
        
        // Update position
        UpdateTime();
    }

    private void OnValidate()
    {
        // Update position
        UpdateTime();
    }

    private void UpdateTime()
    {
        var alpha = timeOfDay / 24f;

        // Set ambient and fog
        RenderSettings.ambientLight = preset.AmbientColor.Evaluate(alpha);
        RenderSettings.fogColor = preset.FogColor.Evaluate(alpha);
        
        // Move sun
        sun.color = preset.DirectionalColor.Evaluate(alpha);
        sun.transform.localRotation = Quaternion.Euler(new Vector3((alpha * 360f) - 90f, 170f, 0));
    }
}
