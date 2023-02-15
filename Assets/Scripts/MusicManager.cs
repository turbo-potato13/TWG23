using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MusicManager : MonoBehaviour
{
    public List<Music> musics;
    private string currentMusicId;
    public int musicNum;
    public AudioMixerGroup mixer;
    public Slider slider;
    public TMP_Text musicName;
    private bool isPlay;

    private void Awake()
    {
        foreach (var music in musics)
        {
            music.audioSource = gameObject.AddComponent<AudioSource>();
            music.audioSource.clip = music.audioClip;
            music.audioSource.outputAudioMixerGroup = mixer;
        }
        musicName.text = "";
        mixer.audioMixer.SetFloat("MusicParam", -10f);
    }

    private void Update()
    {
        if(!musics[musicNum].audioSource.isPlaying && isPlay)
            NextMusic();
    }

    public void NextMusic()
    {
        musics[musicNum].audioSource.Stop();
        musicNum++;
        if (musicNum < musics.Count)
        {
            musics[musicNum].audioSource.Play();
            musicName.text = musics[musicNum].musicId;
        }
        else
        {
            musicNum = 0;
            musics[musicNum].audioSource.Play();
            musicName.text = musics[musicNum].musicId;
        }
    }

    public void PlayMusic()
    {
        if (!musics[musicNum].audioSource.isPlaying)
        {
            musics[musicNum].audioSource.Play();
            musicName.text = musics[musicNum].musicId;
            isPlay = true;
        }
    }
    
    public void PrevMusic()
    {
        musics[musicNum].audioSource.Stop();
        musicNum--;
        if (musicNum >= 0)
        {
            musics[musicNum].audioSource.Play();
            musicName.text = musics[musicNum].musicId;
        }
        else
        {
            musicNum = musics.Count - 1;
            musics[musicNum].audioSource.Play();
            musicName.text = musics[musicNum].musicId;
        }
    }

    public void ChangeVolume()
    {
        Debug.Log("volume: " + Mathf.Lerp(-35, 0, slider.value));
        mixer.audioMixer.SetFloat("MusicParam", Mathf.Lerp(-35, 0, slider.value));
    }
}