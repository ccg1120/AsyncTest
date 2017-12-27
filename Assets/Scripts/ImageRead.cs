using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
using UnityEngine.UI;
using System.IO;
using System.Diagnostics;
public class ImageRead : MonoBehaviour {

    public string Path;
    public string SubPath = ".jpg";
    public Texture2D[] images;

    [SerializeField]
    public List<byte[]> bytesList;

    private void Start()
    {
      
        
        images = new Texture2D[10];
        bytesList = new List<byte[]>();
        Path = Application.dataPath + "/Data/IMG";
        
        CreateImage("");
        
        
        
    }

    async void CreateImage(string path)
    {
        Stopwatch sw = new Stopwatch();

        sw.Reset();
        sw.Start();
        for (int index = 0; index < 10; index++)
        {
            Task<byte[]> task = new Task<byte[]>(()=> RoadImage(Path + (index+1).ToString() + SubPath));
            task.Start();
            await task;
            //images[index] = new Texture2D(0,0);

            //images[index].LoadImage(task.Result);
            //images[index].Apply();
            //bytesList.Add(task.Result);
        }
        sw.Stop();
        UnityEngine.Debug.Log(sw.Elapsed.ToString());
    }


    public byte[] RoadImage(string path )
    {
        byte[] bytes = File.ReadAllBytes(path);
        UnityEngine.Debug.Log(bytes.Length);
        return bytes;
    }
}
