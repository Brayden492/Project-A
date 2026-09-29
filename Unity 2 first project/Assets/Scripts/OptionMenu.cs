using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider sensitivitySlider;

    void Start()
    {
        sensitivitySlider.value = PlayerPrefs.GetFloat("Sensitivity", 2f);
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
    }

    public void ChangeVolume()
    {
        float volume = volumeSlider.value;

        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();

        if (volume <= 0.001f)
        {
            audioMixer.SetFloat("MasterVolume", -80f);
        }
        else
        {
            audioMixer.SetFloat("MasterVolume", Mathf.Log10(volume) * 20);
            //Debug.Log("Volume: " + volumeSlider.value);
        }
 
    }

    public void ChangeSensitivity()
    {
        PlayerPrefs.SetFloat("Sensitivity", sensitivitySlider.value);
        PlayerPrefs.Save();

        //Debug.Log("Sensitivity: " + sensitivitySlider.value);
    }
}