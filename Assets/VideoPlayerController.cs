using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoPlayerController : MonoBehaviour {

    VideoPlayer vp;
    float add = 0;
    float starta;

	// Use this for initialization
	void Start () {

        StartCoroutine(playVideoAfter5Secs());

	}

    IEnumerator playVideoAfter5Secs()
    {
        yield return new WaitForSeconds(5f);

        Debug.Log("Preparing video");

        vp = GetComponent<VideoPlayer>();
        vp.prepareCompleted += Vp_prepareCompleted;
        vp.url = "http://www.html5videoplayer.net/videos/toystory.mp4";
        vp.source = VideoSource.Url;
        vp.renderMode = VideoRenderMode.RenderTexture;
        vp.Prepare();

    }

    private void Vp_prepareCompleted(VideoPlayer source)
    {
        Debug.Log("Playing video");
        vp.Play();
    }

    // Update is called once per frame
    float angleDelta;
    void Update () {

        angleDelta+= 5f;
        var v = this.transform.eulerAngles;
        var y = 45 * Mathf.Sin((angleDelta % 360) * 0.0174533f);

        this.transform.rotation = Quaternion.Euler(v.x, y, v.z);

	}

}
