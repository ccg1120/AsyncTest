using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Threading.Tasks;

public class MultiCoreTest : MonoBehaviour {

    static void TaskMethod(string name)
    {
        
        Debug.Log("Task TEST "+ name);
        Debug.Log("thread id :: "+ Thread.CurrentThread.ManagedThreadId);
        Debug.Log("poolthread :: " + Thread.CurrentThread.IsThreadPoolThread);
    }
	// Use this for initialization
	void Start () {
        Task t1 = new Task(() => TaskMethod("t1"));
        Task t2 = new Task(() => TaskMethod("t2"));

        t1.Start();
        t2.Start();

        Task.Run(() => TaskMethod("t3"));
        Thread.Sleep(TimeSpan.FromSeconds(1));

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
}
