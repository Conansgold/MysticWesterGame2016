using UnityEngine;
using System.Collections;

public class AudioFade : MonoBehaviour {

     public AudioClip track1;
     public AudioClip track2;
    public AudioClip track3;
    public AudioClip track4;

    public bool fadingto1 = false;
    public bool fadingto2 = false;
    public bool fadingto3 = false;
    public bool fadingto4 = false;

    public float audio1Volume = 1f;
    public float audio2Volume = 0f;
    public float audio3Volume = 0f;
    public float audio4Volume = 0f;

    public bool track1Playing = false;
    public bool track2Playing = false;
    public bool track3Playing = false;
    public bool track4Playing = false;

    void Start()
    {
        GetComponent<AudioSource>().clip = track1;
        GetComponent<AudioSource>().Play();
        //audio.clip = track1;
        //audio.Play();

    }

     
    void Update()
    {

        if ((!track2Playing || audio2Volume <1) && fadingto2)
        {

            fadeOut();

            if (audio1Volume <= 0.3 && audio3Volume <= 0.3 && audio4Volume <= 0.3)
            {
                if (track2Playing == false)
                {
                    track2Playing = true;
                    GetComponent<AudioSource>().clip = track2;
                    GetComponent<AudioSource>().Play();
                    track1Playing = false;
                    track3Playing = false;
                    track4Playing = false;
                }

                fadeIn();
            }
            if (audio2Volume >= 1)
            {
                fadingto2 = false;
            }
        }
        else
            fadingto2 = false;
        if ((!track1Playing || audio1Volume < 1) && fadingto1)
        {

            fadeOut();

            if (audio2Volume <= 0.3 && audio3Volume <= 0.3 && audio4Volume <= 0.3)
            {
                if (track1Playing == false)
                {
                    track1Playing = true;
                    GetComponent<AudioSource>().clip = track1;
                    GetComponent<AudioSource>().Play();
                    track2Playing = false;
                    track3Playing = false;
                    track4Playing = false;
                }

                fadeIn();
            }
            if (audio1Volume >= 1)
            {
                fadingto1 = false;
            }
        }
        else
            fadingto1 = false;
        if ((!track3Playing || audio3Volume < 1) && fadingto3)
        {

            fadeOut();

            if (audio2Volume <= 0.3 && audio1Volume <= 0.3 && audio4Volume <= 0.3)
            {
                if (track3Playing == false)
                {
                    track3Playing = true;
                    GetComponent<AudioSource>().clip = track3;
                    GetComponent<AudioSource>().Play();
                    track2Playing = false;
                    track1Playing = false;
                    track4Playing = false;
                }

                fadeIn();
            }
            if (audio3Volume >= 1)
            {
                fadingto3 = false;
            }
        }
        else
            fadingto3 = false;
        if ((!track4Playing || audio4Volume < 1) && fadingto4)
        {

            fadeOut();

            if (audio2Volume <= 0.3 && audio1Volume <= 0.3 && audio3Volume <= 0.3)
            {
                if (track4Playing == false)
                {
                    track4Playing = true;
                    GetComponent<AudioSource>().clip = track4;
                    GetComponent<AudioSource>().Play();
                    track2Playing = false;
                    track1Playing = false;
                    track3Playing = false;
                }

                fadeIn();
            }
            if (audio4Volume >= 1)
            {
                fadingto4 = false;
            }
        }
        else
            fadingto4 = false;
    }

   /* void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 100), "Audio 1 : " + audio1Volume.ToString());
        GUI.Label(new Rect(10, 30, 200, 100), "Audio 2 : " + audio2Volume.ToString());
    } */

    void fadeIn()
    {
        if (fadingto2  && audio2Volume < 1)
        {
            audio2Volume += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio2Volume;
        }
        if (fadingto1 && audio1Volume < 1)
        {
            audio1Volume += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio1Volume;
        }
        if (fadingto3 && audio3Volume < 1)
        {
            audio3Volume += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio3Volume;
        }
        if (fadingto4 && audio4Volume < 1)
        {
            audio4Volume += 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio3Volume;
        }
    }

    void fadeOut()
    {
        if ((fadingto3 || fadingto2 || fadingto4) &&audio1Volume > 0.1)
        {
            audio1Volume -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio1Volume;
        }
        if ((fadingto1 || fadingto2 || fadingto4) && audio3Volume > 0.1)
        {
            audio3Volume -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio3Volume;
        }
        if ((fadingto3 || fadingto1 || fadingto4) && audio2Volume > 0.1)
        {
            audio2Volume -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio2Volume;
        }
        if ((fadingto3 || fadingto1 || fadingto2) && audio4Volume > 0.1)
        {
            audio4Volume -= 0.1f * Time.deltaTime;
            GetComponent<AudioSource>().volume = audio4Volume;
        }
    }
}
