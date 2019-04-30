using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class char_behavior : MonoBehaviour
{

    public Vector2 stat_velocity; //물리엔진을 쓰지 않고 수학적 계산으로 움직임을 구현할 때 쓰기위한 벡터
    public Vector2 check_velocity; //인스펙터 창에서 물체의 속도를 브리핑하기 위한 것
    public Vector2 player_pos; // 현재 캐릭터의 위치를 반영한다
    public Vector3 player_data; // 점프키를 눌렀을 때의 플레이어의 위치를 저장한다 점프 높이를 제한하기 위한 데이터다
    public int run = 0;         // 현재 캐릭터가 달리는 상태인지를 판단하기 위한 정수값이다
    public int no_ground = 0;   // 현재 캐릭터 밑에 땅 즉, 발판이 있는지를 판단하기 위한 값이다
    public float jump_r = 200 ; // 좀 더 현실적임 점프를 구현하기 위해서 설정한 점프 힘의 초기 값이다
    public float movespeed;     // 마찬가지로 물리엔진을 사용하지 않을 때 속도 데이터를 지정하기 위한 데이터이다
    public int jump = 0;        // 현재 점프키가 눌렸는지를 판단하는 정수로 여러번 점프키가 눌리지 않도록 방지하기 위한 값이다

    bool reverse = false;
    public int health = 110;      // 애니메이션에서 현재 캐릭터가 보고있는 방향이 어디인지를 판단하는 데이터이다 True면 왼쪽을 본다
    int x_way = 1;              // 속도값을 계산할 때 방향에 따라 달라지기에 설정한 값이다 캐릭터가 보고있는 방향 또한 판단하는데 사용할 수 있다
    Rigidbody2D player_rig;     // 편하게 RigidBody2D를 사용하기 위해 미리 선언한 데이터
    Transform pl_trans;         // 마찬가지식의 데이터
    Animator char_ani;          // 캐릭터의 애니메이션 변경을 위해서 미리 선언한 것

    // Start is called before the first frame update
    void Start()
    {
        player_rig = GetComponent<Rigidbody2D>(); //선언한 데이터들에게 시작 시에 값을 할당한다
        char_ani = GetComponent<Animator>();
        pl_trans = GetComponent<Transform>();
        health = 110;
        char_ani.SetBool("run", false); //처음부터 바로 달리는 애니메이션이 활성화 되면 안되기에 미리 제어한다


    }

    // Update is called once per frame
    void Update()
    {
        player_pos = new Vector2(pl_trans.position.x, pl_trans.position.y); // 매 프레임별로 현재 플레이어의 위치를 반환한다
        check_velocity = player_rig.velocity; // 현재 캐릭터의 방향 속도 데이터를 받아온다 밑에서의 속도 범위를 시각적으로 제어할 수 있도록 해준다
        onMovemnet(); //키 입력과 같은 게임 내에 전달되는 값은 즉각 적으로 반응해야되기 때문에 한번 프레임에 바로 인식할 수 있도록 update함수에 넣어준다
        GameObject.Find("hp_manager").SendMessage("Health", health);              //Fixedupdate에 넣어도 상관은 없지만 프레임이 고정되어 있기 때문에 중복 입력되는 오류를 초래할 수 있다
        fallen();
    }



    void FixedUpdate()
    {
        // 애니메이션과 속도 데이터 처리를 한번에 하기위한 조건문 애니메이션 컨트롤러에 대한 이해도가 생긴다면 코드 구조를 이해 할 수 있을 것이.
        if (run == 1 && reverse == false)
        {
            char_ani.SetBool("walk", false);
            char_ani.SetBool("run", true);

            if (check_velocity.x < 20.0f && check_velocity.x > -20.0f) player_rig.AddForce(new Vector2((x_way) * 100.0f, 0.0f));
            else{ } //없어도 괜찮지만 특정 데이터값 연산시에 else가 없으면 오류가 날 때 가 있어서 추가함
            //player_rig.MovePosition(Vector2.zero);
        }

        else if(run == 1 && reverse == true)
        {
            char_ani.SetBool("walk", false);
            char_ani.SetBool("run", true);

            if (check_velocity.x < 20.0f && check_velocity.x > -20.0f) player_rig.AddForce(new Vector2((x_way) * 100.0f, 0.0f));
            else { }
            //player_rig.MovePosition(Vector2.zero);

        }
        else
        {
            char_ani.SetBool("run", false);
            char_ani.SetBool("walk", true);
        }

        //여기서는 점프시에 자연스러운 점프를 보여주기 위해서 물리엔진 데이터를 조작하는 코드이다
        if(jump == 1)
        {
            if(jump_r > 40.0f)
            {
                if (player_pos.y <= player_data.y + 6)
                {
                    Debug.Log("true");
                    player_rig.AddForce(new Vector2(0.0f, jump_r)); //보통 점프를 하면 위로 갈수록 속도가 느려지는데 고정된 힘을 계속주면 가속도의 법칙으로 천천히 시작해서
                    jump_r -= 10.0f;                                //빠르게 지점까지 가는 부자연 스러운 점프가 된다 그래서 점프힘을 특정 구간까지 순차적으로 줄이고
                }                                                   //자연스러운 점프를 만들어 낸다 그래서 원하는 점프가 나올 때 까지 값을 조정해주자
                else jump_r = 40.0f;
            }
            else
            {
                if (no_ground == 1) { jump = 0; jump_r = 200.0f; }
                player_rig.AddForce(new Vector2(0.0f, -30.0f));

            }
        }

    }


    private void OnTriggerExit2D(Collider2D collision) //트리거로 설정된 히트박스에 다른 히트박스가 사라질 때 땅이 밑에 없는 것과 같으므로 0으로 설정
    {
        no_ground = 0; // there is no ground under the character
    }

    private void OnTriggerStay2D(Collider2D collision) //마찬가지의 이유다
    {
        no_ground = 1; // there is ground under the character
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag.Equals("bricks")) { health -= 10; Destroy(col.gameObject); GameObject.Find("hp_manager").SendMessage("onDamage", health / 10); }
    }
    // 이 메소드는 키입력을 받아주는 메소드이다. 
    void onMovemnet() 
    {
        if (run == 0)
        {
            if (Input.GetKey(KeyCode.D)) //보통 GetKeydown은 키가 눌린 순간에 작동하는 것이고 GetKey는 눌린순간 부터 계속 누르고 있는 시점 까지를 나타낸다.
            {
                Debug.Log("D down");
                x_way = 1;
                reverse = false;
                char_ani.SetBool("reverse", false); //애니메이션을 먼저 바꿔주는데 run보다 먼저 처리함으로써 run조건문에 있는 애니메이션 컨트롤과 충돌을 막기위한 배치다
                char_ani.SetBool("reverse_t", true);
                run = 1;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                Debug.Log("A down");
                x_way = -1;
                reverse = true;
                char_ani.SetBool("reverse", true);
                char_ani.SetBool("reverse_t", false);
                run = 1;
            }

        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            Debug.Log("D up");
            run = 0;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            Debug.Log("A up");
            run = 0;
        }

        if (no_ground == 1 && jump == 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("jump");
                jump = 1;
                player_data.y = GetComponent<Transform>().position.y;
            }
        }
    }

    void fallen()
    {
        Vector3 check_pos= Camera.main.WorldToScreenPoint(pl_trans.transform.position);
        if (check_pos.y < 0.0f) SceneManager.LoadScene("End");
    }

}
