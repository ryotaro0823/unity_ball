using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalChecker : MonoBehaviour
{
    public PlayerController playercontroller;
    public PlayerFollower playerfollower;
    public TimerController timercontroller;
    public GameObject unityChan_a;
    public GameObject unityChan;
    public AudioSource gameBgm;
    public AudioSource goalBgm;

    public GameObject retryButton;
    public GameObject judgeUi;
    public Text judgeText;
    public int judgecnt;
    // Start is called before the first frame update
    void Start()
    {
        retryButton.SetActive(false);
        judgeUi.SetActive(false);
}

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        timercontroller.enabled = false;
        timercontroller.timerText.SetActive(false);
        gameBgm.Stop();
        goalBgm.Play();
        Resultfunc();
    }

    public void RetryStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resultfunc()
    {
        // iskinematic は物理演算無効
        unityChan_a.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        playerfollower.goal_flg = true;
        retryButton.SetActive(true);
        if (timercontroller.seconds == 0)
        {
            judgeText.text = "Time Up";
        }
        else if (playercontroller.count < judgecnt)
        {
            judgeText.text = "Lose";
        }
        else if (playercontroller.count >= judgecnt)
        {
            unityChan.transform.LookAt(Camera.main.transform);
            unityChan.transform.GetComponent<Animator>().SetTrigger("Goal");
            judgeText.text = "Win";
        }
        judgeUi.SetActive(true);
    }
}
