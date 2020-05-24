using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // array of all audio
    Audio[] _audios;

    // normally set by UI volume sliders
    [Range(0,1)]
    public float musicScale, soundScale;

    #region for testing
    // used to trigger volume chance
    float _oldMusicScale, _oldSoundScale;
    // references to objects for testing
    public Transform falling, harp;
    public float harpPitchOffset;
    #endregion

    private void Start()
    {
        // populate audio array
        _audios = FindObjectsOfType<Audio>();
    }

    private void Update()
    {
        #region volume testing
        // normally when setting volume in UI
        // you would call SetMusicScale() directly there
        if (_oldMusicScale != musicScale)
            SetVolumeScale(Audio.AudioType.Music, musicScale);

        if (_oldSoundScale != soundScale)
            SetVolumeScale(Audio.AudioType.Sound, soundScale);

        // setting current value to old value
        _oldMusicScale = musicScale;
        _oldSoundScale = soundScale;
        #endregion

        #region music testing
        // hard coded input check for triggering code
        if (Input.GetKeyDown(KeyCode.Alpha1))
            PlayAllOfType(Audio.AudioType.Music);

        if (Input.GetKeyDown(KeyCode.Alpha2))
            ToggleAllOfType(Audio.AudioType.Music);

        if (Input.GetKeyDown(KeyCode.Alpha3))
            StopAllOfType(Audio.AudioType.Music);
        #endregion

        #region sound testing
        if (Input.GetKeyDown(KeyCode.Space))
            PlayHarp();

        if (Input.GetKeyDown(KeyCode.Return))
            ResetFalling();
        #endregion
    }

    public void SetVolumeScale(Audio.AudioType audioType, float value)
    {
        foreach(Audio a in _audios)
        {
            if (a.audioType == audioType)
                a.SetVolumeScale(value);
        }
    }

    public void PlayAllOfType(Audio.AudioType audioType)
    {
        // checks all audios in audios array
        foreach (Audio a in _audios)
        {
            // if audio type matches play it
            if (a.audioType == audioType)
                a.Play();
        }
    }

    public void ToggleAllOfType(Audio.AudioType audioType)
    {
        // checks all audios in audios array
        foreach (Audio a in _audios)
        {
            // if audio type matches pause/unpause it
            if (a.audioType == audioType)
                a.TogglePause();
        }
    }

    public void StopAllOfType(Audio.AudioType audioType)
    {
        // checks all audios in audios array
        foreach (Audio a in _audios)
        {
            // if audio type matches stop it
            if (a.audioType == audioType)
                a.Stop();
        }
    }
    
    #region for testing
    private void PlayHarp()
    {
        // Random.Range(min, max) where
        // min is inclusive
        // max is exclusive
        // meaning if min is 2 and max 12
        // the range is 2 to 11
        harp.GetComponent<Audio>().SetPitchOffset(Random.Range(-harpPitchOffset, harpPitchOffset));

        // PlayOneShot means that unity plays audio as separet clip
        // meaning we can play multiple once at same time
        harp.GetComponent<Audio>().PlayOneShot();
    }

    private void ResetFalling()
    {
        // resets speed to zero and makes sure gravity is used
        falling.GetComponent<Rigidbody>().velocity = Vector3.zero;
        falling.GetComponent<Rigidbody>().useGravity = true;

        // hard coded reset position
        falling.position = new Vector3(0, 100, 10);

        // forcing audio to play when resetting the object
        // you can have parameter name visible at method calls
        // Play(forceplay: true); is more clear than Play(true);
        falling.GetComponent<Audio>().Play(forceplay: true);
    }
    #endregion
}
