using UnityEngine;
using UnityEngine.Video;
using System.IO;

[RequireComponent(typeof(VideoPlayer))]
public class StartScreenVideo : MonoBehaviour
{
    VideoPlayer vp;

    void Start()
    {
        vp = GetComponent<VideoPlayer>();

        // ✅ StreamingAssets path (works in WebGL)
        string path = Path.Combine(Application.streamingAssetsPath, "Bgvideo.mp4");

        vp.source = VideoSource.Url;
        vp.url = path;

        vp.isLooping = true;
        vp.playOnAwake = false;

        // Prepare then play
        vp.Prepare();
        vp.prepareCompleted += (VideoPlayer v) =>
        {
            v.Play();
        };
    }
}
