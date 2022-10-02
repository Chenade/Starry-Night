using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class twinkling : MonoBehaviour
{
    public Light _light;
    public float intensity = 1f;
    public float delta = -1;
    public float step = 0.01f;

    public float timestamp;

    void Start()
    {
        // StartCoroutine(twinkle());
        intensity = 1f;
        _light.intensity = intensity;
        timestamp = 0f;
        intensity = JSONStar.information.data[0].curve[0].y;
    }

    void FixedUpdate()
    {
        timestamp += MainSystem.time_rate * Time.deltaTime;

        for(int i = 0; i < JSONStar.information.data[0].curve.Length; i ++)
        {
            if (Mathf.Abs(timestamp - JSONStar.information.data[0].curve[i].x) < 0.5f)
            {
                intensity = JSONStar.information.data[0].curve[i].y;
                break ;
            }
        }
        if (timestamp > JSONStar.information.data[0].curve[JSONStar.information.data[0].curve.Length - 1].x)
        {
            timestamp = 0;
            intensity = JSONStar.information.data[0].curve[0].y;
        }
        _light.intensity = intensity;

    }

    // IEnumerator twinkle()
    // {
    //     while (true)
    //     {
    //         // Debug.Log("Started Coroutine at timestamp : " + Time.time);

    //         // stage_2.SetActive(false);
    //         // stage_1.SetActive(true);
    //         // Debug.Log(MainSystem.delta_time);
    //         stage_2.transform.localScale += new Vector3(1f, 1f, 1f);
    //         yield return new WaitForSeconds(5);

    //         // stage_1.SetActive(false);
    //         // stage_2.SetActive(true);
    //         // Debug.Log(MainSystem.delta_time);
    //         stage_2.transform.localScale -= new Vector3(1f, 1f, 1f);
    //         yield return new WaitForSeconds(5);
    //         // while(Time.time <= MainSystem.delta_time) ;

    //     }
       
    // }
}
