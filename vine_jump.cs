using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine;

public class vine_jump : MonoBehaviour
{

    /*
     * This is an example script that i used to interact with a user during a vine jump sequence
     * If player clicks on screen before the vine video is over then the variables are set to get
     * them to the other side.
     */

    private VideoPlayer vidPlayer;
    private VideoSource videoSource;
    private bool grabbed;
    public GameObject instructions;


    // Use this for initialization
    void Start()
    {
        cave_vars.prev_scene = "vine_jump";
        instructions.SetActive(true);

        grabbed = false;

        vidPlayer = this.GetComponent<VideoPlayer>();
        
        vidPlayer.isLooping = false;

        vidPlayer.loopPointReached += EndReached;
        vidPlayer.Play();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grabbed = true;
            instructions.SetActive(false);
        }
    }

    void EndReached(VideoPlayer vPlayer)
    {
        
        instructions.SetActive(false);
        cave_vars.vine_grabbed = grabbed;
        SceneManager.LoadScene("Cave");
    }

 }
