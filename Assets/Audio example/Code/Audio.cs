using UnityEngine;

public class Audio : MonoBehaviour
{
    // enums are useful tool when you want to
    // seperate simular objects that differ slightly
    // in this case music and sound work same way
    // but have different volume sliders
    public enum AudioType
    {
        Music,
        Sound
    }
    // this makes enum visible in editor
    public AudioType audioType;

    // original values as audio designer have balanced them
    float _originalVolume, _originalPitch;

    // reference
    AudioSource _audioSource;

    private void Start()
    {
        // finds audio source from this gameobject
        _audioSource = GetComponent<AudioSource>();

        // sets original values
        _originalVolume = _audioSource.volume;
        _originalPitch = _audioSource.pitch;
    }

    // here we have assinged default value for parameter
    // meaning that calling Play() and Play(false) are the same calls
    public void Play(bool forceplay = false)
    {
        // if this clip is playing
        // stop it and play it again
        if (forceplay)
        {
            Stop();
            _audioSource.Play();
            return;
        }

        // dont play audio if it is already playing
        if (_audioSource.isPlaying)
            return;
        _audioSource.Play();
    }

    public void TogglePause()
    {
        if (_audioSource.isPlaying == true)
            _audioSource.Pause();
        else
            _audioSource.UnPause();
    }

    public void Stop() { _audioSource.Stop(); }

    public void PlayOneShot()
    {
        // PlayOneShot means that unity plays audio as separet clip
        // meaning we can play multiple once at same time
        _audioSource.PlayOneShot(_audioSource.clip);
    }
    public void SetVolumeScale(float value = 1)
    {
        // this way we keep original value and
        // have adjustable volume at same time
        _audioSource.volume = _originalVolume * value;
    }
    public void SetPitchOffset(float value = 0)
    {
        // this way we keep original value and
        // have adjustable pitch at same time
        _audioSource.pitch = _originalPitch + value;
    }
    public void SetLoop(bool value) { _audioSource.loop = value; }
}
