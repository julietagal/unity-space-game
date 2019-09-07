using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform Bullet;
    public Transform CannonPosition;
    public int Score;
    public Text ScoreText;
    public Text Timer;
    float timeLeft;
    float secsLeft;
    float minLeft;
    public Slider Life;

    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score: 0";
        Timer.text = "00:60";
        timeLeft = 60;
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        gameObject.transform.Translate(new Vector3(h, v, 0));
        ScoreText.text = "Score: " + Score;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }

        if (timeLeft > 60)
        {
            minLeft = Mathf.Round(secsLeft / 60);
            secsLeft = Mathf.Round(minLeft % 60);
            if (secsLeft <= 9)
            {
                Timer.text = minLeft + ":0" + secsLeft;
            }
            else
            {

                Timer.text = minLeft + ":" + secsLeft;
            }

        }
        else
        {
            Timer.text = "00:" + Mathf.Round(timeLeft);
        }



        timeLeft = Mathf.Round(secsLeft -= (Time.deltaTime));
    }

    void Shoot()
    {
        Instantiate(Bullet, CannonPosition.position, Quaternion.identity);
    }
}
