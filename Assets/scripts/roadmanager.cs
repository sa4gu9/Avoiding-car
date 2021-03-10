using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;


public class roadmanager : MonoBehaviour
{
    public Button continuebutton;
    public static int whatcar = 1;
    public static int speed = 0;
    public static float plustime = 0;
    public static Stopwatch stw1 = new Stopwatch();//UP
    public static Stopwatch stw2 = new Stopwatch();//DOWN
    public static Stopwatch stw3 = new Stopwatch();//right left
    public static Stopwatch stw4 = new Stopwatch();//minus stop
    public static Stopwatch stw5 = new Stopwatch();//speed
    public static Stopwatch stw6 = new Stopwatch();//time record
    public static Stopwatch stw7 = new Stopwatch();//game over
    public Text txt;//speed
    public Text txt2;//distance
    public Text txt3;//time
    public static int clear = 0;
    public static int minus = 0;
    public static float speedchange = 1f;

    string time;
    int temp = 0;

    public int full;
    int remain;
    int temp_run = 0;
    int run = 0;
    int minute;
    public Image pbar;

    public GameObject road1;
    public GameObject road2;
    public GameObject road3;
    public GameObject road4;

    public static GameObject car;
    public GameObject startline;
    public GameObject endline;
    float endlinef;

    public SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        full = 500;
        continuebutton.gameObject.SetActive(false);
        clear = 0;
        speed = 0;
        stw6.Reset();
        car = GameObject.FindGameObjectWithTag("Player");
        endline.transform.position = new Vector3(0, 1000 * full/100-sprite.sprite.bounds.size.y, 0);
        endlinef = endline.transform.position.y;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (stw6.ElapsedMilliseconds / 1000 >= 60)
        {
            speed = 0;
            txt2.fontSize = 30;
            txt2.text = "Gameover...";
            
            stw6.Stop();
            stw7.Start();
        }
        else
        {         
            txt2.text = "Remain distance : " + remain;
           
        }

        if (stw7.ElapsedMilliseconds >= 10000)
        {
            stw7.Reset();
            SceneManager.LoadScene("scene_start");
        }
        time = string.Format("{0:D2}.{1:D3}sec", stw6.ElapsedMilliseconds / 1000, stw6.ElapsedMilliseconds % 1000);
        txt3.text = time;
        remain = full - run;
        pbar.fillAmount = (float)remain / full;
        movespeed();
        

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            startup();
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            inputup();
        }
        else
        {
            inputnotup();
        }

        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            stw1.Stop();
            stw1.Reset();
            stw2.Start();
        }

        txt.text = "Current speed : " + speed;

        moveroad();

        if (clear == 0)
        {
            startline.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
            if (startline.transform.position.y < -40)
            {
                Destroy(startline.gameObject);
                clear = 1;
            }
            endline.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
        }
        else if (clear <= 2)
        {
            endline.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
        }


        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            bothstop();
        }

        if (stw4.ElapsedMilliseconds >= 1000)
        {
            stw4.Reset();
            stw3.Reset();
        }



        

        temp_run += speed;

        if (temp_run >= 1000)
        {
            temp_run -= 1000;
            run++;
        }

        if (remain <= 0)
        {
            continuebutton.gameObject.SetActive(true);
            clear = 2;
            txt2.fontSize = 30;
            txt2.text = "CLEAR!!!";
            stw6.Stop();

            if (PlayerPrefs.HasKey("best"))
            {
                temp = 0;
                string best = PlayerPrefs.GetString("best");
                print(best+"     "+ txt3);
                for (temp = 0; temp<6; temp++)
                {

                    if (temp == 2)
                        continue;

                    if (best[temp] > txt3.text[temp])
                    {
                        PlayerPrefs.SetString("best", txt3.text);
                        txt3.text = "best record!!";
                        break;
                    }
                    else if (best[temp] == txt3.text[temp])
                    {
                        continue;
                    }
                    else
                    {
                        txt3.text = "slower than best";
                        break;
                    }
                }

                if (temp == 6)
                {
                    txt3.text = "same as best";
                }


            }
            else
            {
                PlayerPrefs.SetString("best", txt3.text);
                txt3.text = "best record!!";
            }

            
            
        }
      

        if (temp == 8)
            txt3.text = "same as best";

        if (remain <= -10)
        {
            Destroy(endline.gameObject);
            clear = 3;
        }
    }

    public void continueclick()
    {
        continuebutton.gameObject.SetActive(false);
        SceneManager.LoadScene("scene_start");
    }

    public static void inputup()
    {
        //speed++;
        if (speed < 0)
        {
            speed++;
        }
        else
        {
            if (plustime <= stw1.ElapsedMilliseconds)
            {
                speed++;
                stw1.Restart();
            }
        }
    }

    public static void inputnotup()
    {
        if (speed > 0)
        {
            if (Mathf.Round(10000 - Mathf.Log(1 + (float)speed / 100) * 1000) * 0.005f <= stw2.ElapsedMilliseconds)
            {
                speed--;
                stw2.Restart();
            }
        }
    }




    void moveroad()
    {
        road1.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
        road2.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
        road3.transform.Translate(new Vector3(0, -((float)speed / 100), 0));
        road4.transform.Translate(new Vector3(0, -((float)speed / 100), 0));

        if (road1.transform.position.y <= -41)
        {
            road1.transform.position = road4.transform.position + new Vector3(0, 24, 0);
        }
        else if (road2.transform.position.y <= -41)
        {
            road2.transform.position = road1.transform.position + new Vector3(0, 24, 0);
        }
        else if (road3.transform.position.y <= -41)
        {
            road3.transform.position = road2.transform.position + new Vector3(0, 24, 0);
        }
        else if (road4.transform.position.y <= -41)
        {
            road4.transform.position = road3.transform.position + new Vector3(0, 24, 0);
        }
    }

    public static void startup()
    {
        if(clear<2)
            stw6.Start();
        stw2.Stop();
        stw2.Reset();
        stw1.Start();
    }

    void movespeed()
    {
        if (speed <= 50)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100*speedchange));
        }
        else if (speed <= 100)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 100f*speedchange);
        }
        else if (speed <= 150)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 300f*speedchange);
        }
        else if (speed <= 200)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 600f*speedchange);
        }
        else if (speed <= 250)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 1000f*speedchange);
        }
        else if (speed <= 300)
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 1500f*speedchange);
        }
        else
        {
            plustime = Mathf.Round(Mathf.Log(1 + (float)speed / 100) * 2100f*speedchange);
        }
    }

    public static void bothstop()
    {
        stw3.Reset();
        minus = 0;
        if (stw4.ElapsedMilliseconds == 0)
            stw4.Start();
    }
}
