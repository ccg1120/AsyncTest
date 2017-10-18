using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;
using System;
using System.Threading.Tasks;
using System.IO;


public class MultiCoreTest : MonoBehaviour {

    string pathfolder = "Data";
    string filename = "IMG.jpg";
    public SpriteRenderer sr;

    public static Texture2D[] tts = new Texture2D[10];

    static void TaskMethod(string name)
    {
        
        Debug.Log("Task TEST "+ name);
        Debug.Log("thread id :: "+ Thread.CurrentThread.ManagedThreadId);
        Debug.Log("poolthread :: " + Thread.CurrentThread.IsThreadPoolThread);
    }
	// Use this for initialization
	void Start () {
        for(int i = 0; i < 10; i++)
        {
            tts[i] = new Texture2D(1, 1);
        }

        //Task t1 = new Task(() => TaskMethod("t1"));
        //Task t2 = new Task(() => TaskMethod("t2"));

        //t1.Start();
        //t2.Start();

        //Task.Run(() => TaskMethod("t3"));
        //Thread.Sleep(TimeSpan.FromSeconds(1));

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        sw.Reset();
        sw.Start();

        //for (int i = 1; i <= 10; i++)
        //{
        //    string filename = "IMG" + i.ToString() + ".jpg";
        //    ReadImage(filename,i);
        //}

        //Task t1 = new Task(() => ReadImage("IMG1.jpg", 0));
        //Task t2 = new Task(() => ReadImage("IMG2.jpg", 1));
        //Task t3 = new Task(() => ReadImage("IMG3.jpg", 2));
        //Task t4 = new Task(() => ReadImage("IMG4.jpg", 3));
        //Task t5 = new Task(() => ReadImage("IMG5.jpg", 4));

        //Task t6 = new Task(() => ReadImage("IMG6.jpg", 5));
        //Task t7 = new Task(() => ReadImage("IMG7.jpg", 6));
        //Task t8 = new Task(() => ReadImage("IMG8.jpg", 7));
        //Task t9 = new Task(() => ReadImage("IMG9.jpg", 8));
        //Task t10 = new Task(() => ReadImage("IMG10.jpg", 9));

        //Task를 이용한 호출  14초? 정도 소요 cpu사용률 100% 
        Task t1 = new Task(() => IntAddMax());
        Task t2 = new Task(() => IntAddMax());
        Task t3 = new Task(() => IntAddMax());
        Task t4 = new Task(() => IntAddMax());
        Task t5 = new Task(() => IntAddMax());

        Task t6 = new Task(() => IntAddMax());
        Task t7 = new Task(() => IntAddMax());
        Task t8 = new Task(() => IntAddMax());
        Task t9 = new Task(() => IntAddMax());
        Task t10 = new Task(() => IntAddMax());

        // async를 이용한 방식 1분 대로 먼가 느림 cpu사용률 27%정도
        //Task<UInt32> t1 = IntAddMaxasync();
        //Task<UInt32> t2 = IntAddMaxasync();
        //Task<UInt32> t3 = IntAddMaxasync();
        //Task<UInt32> t4 = IntAddMaxasync();
        //Task<UInt32> t5 = IntAddMaxasync();
        //Task<UInt32> t6 = IntAddMaxasync();
        //Task<UInt32> t7 = IntAddMaxasync();
        //Task<UInt32> t8 = IntAddMaxasync();
        //Task<UInt32> t9 = IntAddMaxasync();
        //Task<UInt32> t10 = IntAddMaxasync();

        Debug.Log("t Start working");
        t1.Start();
        t2.Start();
        t3.Start();
        t4.Start();
        t5.Start();
        t6.Start();
        t7.Start();
        t8.Start();
        t9.Start();
        t10.Start();
        Debug.Log("t EndStart");

        Debug.Log("IntAddMax Start working");
        IntAddMax();
        Debug.Log("IntAddMax EndStart");

        //t1.Wait();
        //t2.Wait();
        //t3.Wait();
        //t4.Wait();
        //t5.Wait();
        //t6.Wait();
        //t7.Wait();
        //t8.Wait();
        //t9.Wait();
        //t10.Wait();


        //for (int i = 1; i <= 10; i++)
        //{
        //    IntAddMax();
        //}

        sw.Stop();
        Debug.Log(sw.Elapsed.ToString());
        

        //tasktet.Start();
        //tasktet.Wait();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void ReadImage(string filename, int num)
    {
    
        //Debug.Log(Application.persistentDataPath);
        byte[] bytes = File.ReadAllBytes(@"E:\Study\UnityTask\Assets\Data\"+filename);
        
        //Debug.Log(bytes.Length);
        //Sprite sp = new Sprite();
        
        
        //tts[num].LoadImage(bytes);
        //tts[num].Apply();
        //Debug.Log("texture width :: " + tts[num].width  + " :: texture height ::" + tts[num].height);
        //sp = Sprite.Create(tts[num], new Rect(0,0, tts[num].width, tts[num].height),Vector2.zero);
        //sr.sprite = sp;
        
    }
    public void IntAddMax()
    {
        Debug.Log("IntAddMax");
        UInt32 num = 0;
        for(int i = 0; i < int.MaxValue; i++)
        {
            num = num + (UInt32)i;
        }
        Debug.Log("Done!!");
    }

    async static Task<UInt32> IntAddMaxasync()
    {
        Debug.Log("IntAddMaxasync call");
        Task<UInt32> tt = Task.Run(() => {
            UInt32 num = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                num = num + (UInt32)i;
            }
            return num;
        });

        //await Task.Run(() => {
        //    UInt32 num = 0;
        //    for (int i = 0; i < int.MaxValue; i++)
        //    {
        //        num = num + (UInt32)i;
        //    }
        //    return num;
        //});
        return tt.Result;
        //for (int i = 0; i < int.MaxValue; i++)
        //{
        //    num = num + (UInt32)i;
        //}
        //await Task.FromResult<UInt32>(num);
        //return num;
    }
    //static Task taskall()
    //{
    //    Task<UInt32> t1 = IntAddMaxasync();
    //    Task<UInt32> t2 = IntAddMaxasync();
    //    Task<UInt32> t3 = IntAddMaxasync();
    //    Task<UInt32> t4 = IntAddMaxasync();
    //    Task<UInt32> t5 = IntAddMaxasync();
    //    Task<UInt32> t6 = IntAddMaxasync();
    //    Task<UInt32> t7 = IntAddMaxasync();
    //    Task<UInt32> t8 = IntAddMaxasync();
    //    Task<UInt32> t9 = IntAddMaxasync();
    //    Task<UInt32> t10 = IntAddMaxasync();
    //}
}
