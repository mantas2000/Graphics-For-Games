using System;
using System.Text;
using TMPro;
using Unity.Profiling;
using UnityEngine;

public class PerformanceStats : MonoBehaviour
{
    public TextMeshProUGUI statsText;
    private bool _enableStats;
    private ProfilerRecorder _systemUsedMemoryRecorder;

    private void OnEnable()
    {
        _systemUsedMemoryRecorder = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "Total Used Memory");
    }
    
    private void OnDisable()
    {
        _systemUsedMemoryRecorder.Dispose();
    }

    // Update is called once per frame
    private void Update()
    {
        var sb = new StringBuilder(500);
        
        // Get user's input
        if (Input.GetKeyDown(KeyCode.F3))
        {
            _enableStats = !_enableStats;
        }

        // Display performance stats
        if (_enableStats)
        {
            // FPS stats
            var fps = 1 / Time.unscaledDeltaTime;
            sb.AppendLine($"FPS: {Mathf.Round(fps)}");
            
            // Memory stats
            if (_systemUsedMemoryRecorder.Valid)
                sb.AppendLine($"Total Used Memory: {Mathf.Round(_systemUsedMemoryRecorder.LastValue / Mathf.Pow(10, 6))} Mb");
            
            // Display stats
            statsText.text = sb.ToString();
        }
        
        // Otherwise, disable stats
        else
        {
            statsText.text = "";
        }
    }
}
