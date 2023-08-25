using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{
    public VideoPlayer mVideoPlayer;
	bool isPlaying = false;
 
    void Start()
    {
		
    }
 
    void Update()
    {
		if (isPlaying) {
			mVideoPlayer = GetComponent<VideoPlayer>();
			mVideoPlayer.Play();
		} else {
			mVideoPlayer = GetComponent<VideoPlayer>();
			mVideoPlayer.Pause();
		}
	}
	
	public void pauseVideoOn() {
		isPlaying = true;
	}
	
	public void pauseVideoOff() {
		isPlaying = false;
	}
}
