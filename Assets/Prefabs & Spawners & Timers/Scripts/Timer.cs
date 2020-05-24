using UnityEngine;

public class Timer : MonoBehaviour
{
    public float _duration = 5f;
    // ↓ This is how you make sliders for the inspector tab
    [Range(0,1),Tooltip("Use this to test how timescale affects the timer")]
    public float _timeScale = 1f;
    private float _currentTime = 0f;


    // Update is called once per frame
    void Update()
    {
        // You can play around with TimeScale by selecting the object with this timer attached to it in playmode. Move the slider to change the current timescale
        Time.timeScale = _timeScale;

        // Add the time between the previous and current frame to the current time

        // Check IF current time is past the duration
            // Do the desired action when the timer is done here

            // You can add a debug message here to throw a message when the timer is done

            // Reset the timer to spawn them more than once
    }
}
