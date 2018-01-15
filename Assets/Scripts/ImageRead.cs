using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
using System.Timers;

public class ImageRead : MonoBehaviour {

    public string Path;
    public string SubPath = ".jpg";
    public Texture2D[] images;
    public long timetotal;

    [SerializeField]
    public List<byte[]> bytesList;
    public bool[] ResultInArray = new bool[10];
    public bool[] ResultOutArray = new bool[10];

    public int count = 0; 
    private void Start()
    {
        UnityEngine.Debug.Log("Main Init!!");
        images = new Texture2D[10];
        bytesList = new List<byte[]>();
        Path = Application.dataPath + "/Data/IMG";
        UnityEngine.Debug.Log("Main Start!!");
     
        for (int index =0; index < 10; index++)
        {
            CreateImage(Path + (index + 1).ToString() + SubPath,index);
            //StartCoroutine(ICreateImage(RoadImage(Path + (index + 1).ToString() + SubPath), index));
        }

        //for (int index = 0; count < 10; index++)
        //{
        //    UnityEngine.Debug.Log("index ::" + index);
            
        //    if (ResultInArray[index] == true)
        //    {
        //        count++;
        //        UnityEngine.Debug.Log("count     ::" + count);
        //    }
        //    if (index >= 9) index = 0;
        //    //if (ResultOutArray[index] && ResultInArray[index])s
        //    //{
        //    //    count++;
        //    //    if (count == 10) break;
        //    //}
        //    //else if (!ResultOutArray[index] && ResultInArray[index])
        //    //{
        //    //    //StartCoroutine(ICreateImage(bytesList[index], index));
        //    //}
        //}
        UnityEngine.Debug.Log("Main END!!"); //모든 비동기 메소드를 생성 시키고 종료 됨 
    }


    private void Update()
    {
        
        if(count <= 9)
        {
            UnityEngine.Debug.Log("Main Update!!");
            for (int index = 0; index < 10; index++)
            {
                UnityEngine.Debug.Log("index ::" + index);

                if (ResultOutArray[index] && ResultInArray[index])
                {
                    count++;
                }
                else if (!ResultOutArray[index] && ResultInArray[index])
                {
                    
                    StartCoroutine(ICreateImage(bytesList[index], index));
                }
            }
        }
        else
        {
            UnityEngine.Debug.Log("Main END!!");
        }
    }
    async void CreateImage(string path,int index)
    {
        Stopwatch sw = new Stopwatch();
        sw.Reset();
        sw.Start();
        UnityEngine.Debug.Log("Task " + index +" Start!!");
        Task<byte[]> task = new Task<byte[]>(()=> RoadImage(path));
        task.Start();
        await task;
        UnityEngine.Debug.Log("Task " + index + " Result :" + task.Result.Length);
        bytesList.Add(task.Result);
        ResultInArray[index] = true;    
        UnityEngine.Debug.Log("Task " + index + " End!!!!!!");

        //StartCoroutine(ICreateImage(task.Result, index));
        sw.Stop();
        timetotal += sw.ElapsedMilliseconds;
        //totalsw.Elapsed = totalsw.Elapsed + sw.Elapsed;
        UnityEngine.Debug.Log("time total :: " + timetotal);
    }

    IEnumerator ICreateImage(byte[] bytes, int index)
    {
        Stopwatch sw = new Stopwatch();
        sw.Reset();
        sw.Start();
        UnityEngine.Debug.Log("Create " + index + " CreateImage Start!");
        UnityEngine.Debug.Log("bytes. length :" + bytes.Length );
        images[index] = new Texture2D(0,0);
        images[index].LoadImage(bytes);
        images[index].Apply();
        UnityEngine.Debug.Log("Create " + index + " CreateImage End!!!!!!");
        ResultOutArray[index] = true;
        //ResultInArray[index] = true;
        sw.Stop();
        //timetotal += sw.ElapsedMilliseconds;
        //totalsw.Elapsed = totalsw.Elapsed + sw.Elapsed;
        UnityEngine.Debug.Log("time total :: " + timetotal);
        yield return null;
    }

    public byte[] RoadImage(string path )
    {
        Stopwatch sw = new Stopwatch();
        sw.Reset();
        sw.Start();
        byte[] bytes = File.ReadAllBytes(path);
        sw.Stop();
        timetotal += sw.ElapsedMilliseconds;
        return bytes;
    }
}
