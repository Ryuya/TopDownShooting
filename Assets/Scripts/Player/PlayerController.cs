using UnityEngine;
using UnityEngine.Serialization;
using UnityStandardAssets.CrossPlatformInput;

namespace Player
{
    public class PlayerController : MonoBehaviour {

        private Animator _animator;
        public float speed = 1000f;
        [HideInInspector]
        public bool isShoot;
        public GameObject inventorySlots;
        public float firingTimer;

        public GameObject josystick1;
        public GameObject josystick2;
        public Vector3 joystick1_startPos;
        public Vector3 joystick2_startPos;

        public projectileActor projectileActor;

        public Weapon currentWeapon;

        public Weapon playerStatus;

        public GameObject equipmemtSlots;
        private Rigidbody _rigidbody;

        //課金アイテムで拡張するかもしれないので、ロードして変わる値かもしれない。
        public int inventoryMaxAmount = 50; 


        // Use this for initialization
        void Start () {
            //最初のPositionを記録して、現在のPositionから角度を求めたい。
            joystick1_startPos = josystick1.transform.position;
            joystick2_startPos = josystick2.transform.position;
            _animator = GetComponent<Animator>();
            projectileActor = GetComponent<projectileActor>();
            _rigidbody = GetComponent<Rigidbody>();
            UpdateParam();
        }
	
        // Update is called once per frame
        void Update () {
            AnimatorMove();
            if(isShoot){
                firingTimer += Time.deltaTime;
                if (firingTimer > currentWeapon.rapidFireCooldown - currentWeapon.rapidFireCooldown * (playerStatus.rapidFireCooldown * 0.01f))
                {
                    projectileActor.Fire();
                    firingTimer = 0;
                }
            }
            RotateMove();
        }
        // ReSharper disable Unity.PerformanceAnalysis
        /// <summary>
        /// 入力受付キャラクターの移動　normalizeはしてない
        /// </summary>
        public void AnimatorMove()
        {
            var x = CrossPlatformInputManager.GetAxisRaw("Horizontal");
            var z = CrossPlatformInputManager.GetAxisRaw("Vertical");
            
            var vel = new Vector3(x, 0, z) * speed;
            _rigidbody.AddForce(vel,ForceMode.Force);
            var velocity = Mathf.Abs(x) + Mathf.Abs(z);
            _animator.SetFloat("Speed", velocity);
            _animator.SetBool("isShoot", isShoot);
        }
        /// <summary>
        /// 攻撃ボタンの入力受付 isShootingをtrueにする
        /// </summary>
        public void RotateMove(){

            if (Vector3.Distance(joystick1_startPos, josystick1.transform.position) > 0.1)
            {
                var angle = Mathf.Atan2(josystick1.transform.position.y - joystick1_startPos.y, josystick1.transform.position.x - joystick1_startPos.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, -angle + 90f, 0f);
            }

            if (Vector3.Distance(joystick2_startPos, josystick2.transform.position) > 0.1)
            {
                var angle = Mathf.Atan2(josystick2.transform.position.y - joystick2_startPos.y, josystick2.transform.position.x - joystick2_startPos.x) * Mathf.Rad2Deg;
                transform.eulerAngles = new Vector3(0f, -angle + 90f, 0f);
                isShoot = true;
            } else{

                isShoot = false;
            }
        }

        // ReSharper disable Unity.PerformanceAnalysis
        public void UpdateParam()
        {
            currentWeapon = null;
            for (int i = 0; i < 5; i++)
            {
                if (equipmemtSlots.transform.GetChild(i).childCount > 0)
                {
                    playerStatus.damage += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.damage;
                    playerStatus.rapidFireCooldown += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.rapidFireCooldown;
                    playerStatus.reloadCoolddown += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.reloadCoolddown;
                    playerStatus.damageCut += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.damageCut;
                    playerStatus.counterAmount += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.counterAmount;
                    playerStatus.dropLuck += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.dropLuck;
                    playerStatus.rareDropLuck += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.rareDropLuck;
                    playerStatus.light += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.light;
                    playerStatus.penetrationRate += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.penetrationRate;
                    playerStatus.criticalRate += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.criticalRate;
                    playerStatus.criticalDamage += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.criticalDamage;
                    playerStatus.weight += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.weight;
                    playerStatus.stunTime += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.stunTime;
                    playerStatus.knockBack += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.knockBack;
                    playerStatus.poisonDamage += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.poisonDamage;
                    playerStatus.electricDamage += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.electricDamage;
                    playerStatus.fireDamage += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.fireDamage;
                    playerStatus.HealAmmount += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.HealAmmount;
                    playerStatus.stealth += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.stealth;
                    playerStatus.timeStopAmmount += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.timeStopAmmount;
                    playerStatus.seedAmount += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.seedAmount;
                    playerStatus.healthAbsorption += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.healthAbsorption;
                    playerStatus.gatherRange += equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon.gatherRange;
                    if (currentWeapon == null)
                    {
                        currentWeapon = equipmemtSlots.transform.GetChild(i).GetChild(0).GetComponent<ItemParam>().weapon;
                    }
                    //playerStatus.damage += weapon.damage;
                }
            }
        }

        public void InitializedParams()
        {
            playerStatus.damage = 0;
            //実際のUnique要素はUniqueParamatorを継承して作成されるからこれでよし！
            //UniqueParamator[] uniqueSlots;
            //連射速度
            playerStatus.rapidFireCooldown = 0f;
            //リロード速度
            playerStatus.reloadCoolddown = 0f;
            //ダメージカット
            playerStatus.damageCut = 0f;
            //カウンター
            playerStatus.counterAmount = 0f;
            //ドロップ率
            playerStatus.dropLuck = 0f;
            //レアアイテムドロップ率
            playerStatus.rareDropLuck = 0f;
            //灯り(視野)
            playerStatus.light = 0f;
            //貫通率
            playerStatus.penetrationRate = 0f;
            //クリティカル率
            playerStatus.criticalRate = 0f;
            //クリティカル上乗せ
            playerStatus.criticalDamage = 0f;
            //重量
            playerStatus.weight = 0f;
            //スタンタイム
            playerStatus.stunTime = 0f;
            //ノックバック
            playerStatus.knockBack = 0f;
            //毒
            playerStatus.poisonDamage = 0f;
            //電撃
            playerStatus.electricDamage = 0f;
            //弾数
            playerStatus.remainingBullets = 0f;
            //炎
            playerStatus.fireDamage = 0f;
            //ヒール
            playerStatus.HealAmmount = 0f;
            //ステルス
            playerStatus.stealth = 0f;
            //タイムストップ（最大値は設けるべき）
            playerStatus.timeStopAmmount = 0f;
            //サモン（シード）倒した敵から植物が生えてくる確率
            playerStatus.seedAmount = 0f;
            //HP吸収
            playerStatus.healthAbsorption = 0f;
            //引き寄せる。
            playerStatus.gatherRange = 0f;
        }
    }
}
