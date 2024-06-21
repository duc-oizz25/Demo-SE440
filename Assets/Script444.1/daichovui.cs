using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class daichovui : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {  //demo lambda
        MoveGameObject(() =>
        {
            Debug.Log("Call Back");
        });
        //demo multi thread 1
        Debug.Log("Start Cound Down");
        StartCoroutine (CountDown());
        Debug.Log("End Call cound down");
        //demo multi thread 2
        MultiThread02();    
    }

    private async void MultiThread02()
    {
        Debug.Log("Start multi tasks");
        List<UniTask> tasks = new List<UniTask>();
        tasks.Add(TaskA("Move Object", 2000));
        tasks.Add(TaskA("Sacle Object", 4000));
        await UniTask.WhenAll(tasks);
        Debug.Log("Completed tasks");
    }

    private async UniTask TaskA(String log, int delay)
    {
        Debug.Log($"(Task Start {log} )");
        await UniTask.Delay(delay);
        Debug.Log($"(Task Done {log} )");
    }

    private IEnumerator CountDown()
    {
        Debug.Log("Sart CountDown");
        int countTime = 3;
        for (int i = 0; i < countTime; i++) 
        {
            yield return null;  
        }
        Debug.Log("End countDown");
    }
    private void MoveGameObject(Action callback)
    {
        Debug.Log("Move Game Object completed");
        callback?.Invoke(); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
