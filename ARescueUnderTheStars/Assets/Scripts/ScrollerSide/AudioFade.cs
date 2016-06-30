using UnityEngine;
using System.Collections;

public class AudioFade : MonoBehaviour {

     public AudioClip track1;
     public AudioClip track2;

    public bool fading = false;

    float audio1Volume = 1f;
    float audio2Volume = 0f;

    bool track2Playing = false;

     void Start()
    {
        GetComponent<AudioSource>().clip = track1;
        GetComponent<AudioSource>().Play();
        //audio.clip = track1;
        //audio.Play();

    }

     
    void Update()
    {

        if (fading)
        {

            fadeOut();

            if (audio1Volume <= 0.3)
            {
                if (track2Playing == false)
                {
                    track2Playing = true;
                    GetComponent<AudioSource>().clip = track2;
                    GetComponent<AudioSource>().Play();
                }

                fadeIn();
            }
            if(audio2Volume >= 1)
            {
                fading = false;
            }
        }
    }

   /* void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 100), "Audio 1 : " + audio1Volume.ToString());
        GUI.Label(new Rect(10, 30, 200, 100), "Audio 2 : " + audio2Volume.ToString());
    } */

    void fadeIn()
    {
        if (audio2Volume < 1)
        {
            audio2Volume += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio2Volume;
        }
    }

    void fadeOut()
    {
        if (audio1Volume > 0.1)
        {
            audio1Volume -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio1Volume;
        }
    }
}
