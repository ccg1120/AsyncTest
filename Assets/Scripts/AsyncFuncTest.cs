using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class AsyncFuncTest : MonoBehaviour {
    /// <summary>
    /// 비동기함수 테스트 
    /// </summary>
    // Use this for initialization
    void Start()
    {
        for (int index = 0; index < 10; index++)
        {
            Test(index);
        }
   
    }
	// U/}pdate is called once per frame
	void Update () {
		
	}
    //테스크를 비동시 함수에 만들고 이를 포문으로 돌리면 원하는 결과가 나옴 
    async void Test(int num)
    {

        //Task[] func2task = new Task[10];

        //for(int index = 0; index < 10; index++)
        //{
        //    func2task[index] = new Task(()=> Func2(index));
        //    func2task[index].Start();
        //    await func2task[index]; // 테스크의 작업이 끝난뒤 다음 함수가 실행되는걸 볼 수있다. 
        //}

        // 이렇게 배열로 돌리면 순차적으로 프로그램이 흘러감 원하는 효과가 나오지않음
        Task func2task = new Task(()=>Func2(num));
        func2task.Start();
        await func2task;
        Func1(num); //그럼일반함수는? 
    }

    public void Func1(int num)
    {
        for (int index = 0; index < 500; index++)
        {
            Debug.Log("Func1 :: " + num + " :: " + index);
        }
    }

    public void Func2(int num )
    {

        for (int index = 0; index < 500; index++)
        {
            Debug.Log("Func2 :: " + num + " :: " + index);
        }
    }
}
