using UnityEngine;
using System.Collections;
using UnityEngine.UI;
 
public class HPStatusUI : MonoBehaviour {
 
    //　敵のステータス
    private Enemy enemyStatus;
    //HP表示用スライダー
    private Slider hpSlider;
 
    void Start() {
        //　自身のルートに取り付けている敵のステータス取得
        enemyStatus = transform.root.GetComponent <Enemy> ();
        //HP用Sliderを子要素から取得
        hpSlider = transform.Find ("HPBar").GetComponent <Slider>();
        //　スライダーの値0～1の間になるように比率を計算
        hpSlider.value = (float) enemyStatus.HP / (float) enemyStatus.MaxHP;
    }
 
    // Update is called once per frame
    void Update () {
        //　カメラと同じ向きに設定
        transform.rotation = Camera.main.transform.rotation;
    }
    //　死んだらHPUIを非表示にする
    public void SetDisable() {
        gameObject.SetActive (false);
    }
 
    public void UpdateHPValue() {
        hpSlider.value = (float)enemyStatus.HP / (float)enemyStatus.MaxHP;
    }
}