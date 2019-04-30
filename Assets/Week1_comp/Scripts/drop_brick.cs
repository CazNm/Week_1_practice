using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//이 스크립트는 프리펩의 개념과 사용법을 익히기 위한 스크립트이다.
/* 먼저 프리펩이란 무엇인가? 프리펩은 간단하게 말하자면 미리 준비된 게임 오브젝트 같은 느낌이다.
우리가 처음에 하이어아키에 오브젝트를 배치할때 단순하게 스프라이트만 끌어서 놓았다, 프리펩은 하이어아키에서 제작된 게임 오브젝트를 저장소 넣어두고 원할때
언제든 복제하여 게임 씬에 나타낼 수 있다. 이번 스크립트는 간단하게 랜덤한 위치에 프리펩을 소환하여 충돌하는 판정까지 만들어 볼 것이다.
*/

public class drop_brick : MonoBehaviour
{
    //first we have to make birck drop so we have to get Rigidbody2D component
    // Start is called before the first frame update

    Rigidbody2D block_rig;
    Vector3 Start_position;
    Vector3 Block_position;
    float ran_posX;
    int spawn_d = 0;

    public GameObject block;
    public GameObject blocks;
    GameObject block1;
    GameObject blocks1;

    void Start()
    {
        blocks1 = Instantiate(blocks, Vector3.zero, Quaternion.identity);
        block_rig = GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        ran_posX = Random.Range(0.0f, 1920.0f);
        Start_position = new Vector3(ran_posX, 1080.0f, 0.0f);
        Block_position = Camera.main.ScreenToWorldPoint(Start_position);
        Block_position.z = 0.0f;


        if(spawn_d % 4 == 0) {
            block1 = Instantiate(block, Block_position, Quaternion.identity);
            block1.transform.SetParent(blocks1.transform);
        }

        spawn_d += 1;

        if (spawn_d == 250) spawn_d = 0;
    }
}
