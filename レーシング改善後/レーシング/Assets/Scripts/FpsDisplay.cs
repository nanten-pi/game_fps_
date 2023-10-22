using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class FpsDisplay : MonoBehaviour {

    // 変数
    int frameCount;
    float prevTime;
    float fps;
    List<float> list=new List<float>();
    // 初期化処理
    void Start()
    {
        frameCount = 0;
        prevTime = 0.0f;
    }
    // 更新処理
    void Update()
    {
        if(CarController.begin){
            frameCount++;
            float time = Time.realtimeSinceStartup - prevTime;

            if (time >= 0.5f) {
                fps = frameCount / time;
                list.Add(fps);
                Debug.Log(fps);
                //Debug.Log(list.Min());
                //Debug.Log(list.Max());
                Debug.Log("fps_avg"+list.Average());
                frameCount = 0;
                prevTime = Time.realtimeSinceStartup;
            }
        }

    }
}