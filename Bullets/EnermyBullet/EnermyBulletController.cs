using UnityEngine;

public class EnermyBulletController : BulletsMoveController /*敌人子弹控制器*/
{
    [HideInInspector] public int attack_point; //子弹的攻击力

    /*脚本启用时*/
    private void OnEnable()
    {
        Move(); //子弹移动
    }

    /*初始化*/
    private void Start()
    {
        attack_point = StateController.enermy_attack_point; //初始化攻击值
    }

    /*当子弹碰撞到任何碰撞体*/
    private void OnCollisionEnter(Collision collision)
    {
        if (GetComponent<EnermyBulletController>().enabled && collision.collider.tag != "Bullets") //如果脚本存在，除去任何子弹
        {
            if (collision.collider.tag == "Player" && collision.collider.GetComponent<MonoBehaviour>()) //如果碰到了玩家且玩家存活
            {
                collision.collider.GetComponent<PlayerStateChecker>().health_point -= attack_point; //玩家生命值降低
            }
            Destroy(gameObject); //销毁子弹
        }
    }
}