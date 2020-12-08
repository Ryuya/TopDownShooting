using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Weapon {
    //武器名
    public string name;
    //ダメージ floatにしなきゃいけないかもしれない。
    public int damage;
    //武器タイプ
    public ItemType itemType;

    public Rarity rarity;
    //最小,最大弾速
    public float min, max;
    public bool rapidFire;
    public bool shotgun;
    public string spriteName;
    public int uniqueSlotsCount;
    //実際のUnique要素はUniqueParamatorを継承して作成されるからこれでよし！
    public UniqueParamator[] uniqueSlots;
    //連射速度
    public float rapidFireCooldown;
    //リロード速度
    public float reloadCoolddown;
    //ダメージカット
    public float damageCut;
    //カウンター
    public float counterAmount;
    //ドロップ率
    public float dropLuck;
    //レアアイテムドロップ率
    public float rareDropLuck;
    //灯り(視野)
    public float light;
    //貫通率
    public float penetrationRate;
    //クリティカル率
    public float criticalRate;
    //クリティカル上乗せ
    public float criticalDamage;
    //重量
    public float weight;
    //スタンタイム
    public float stunTime;
    //ノックバック
    public float knockBack;
    //毒
    public float poisonDamage;
    //電撃
    public float electricDamage;
    //弾数
    public float remainingBullets;
    //炎
    public float fireDamage;
    //ヒール
    public float HealAmmount;
    //ステルス
    public float stealth;
    //タイムストップ（最大値は設けるべき）
    public float timeStopAmmount;
    //サモン（シード）倒した敵から植物が生えてくる確率
    public float seedAmount;
    //HP吸収
    public float healthAbsorption;
    //引き寄せる。
    public float gatherRange;


    public Sprite itemIcon;
    public enum ItemType
    {
        AR = 1,
        SMG,
        SG,
        SR,
        Laser,
    }

    public enum Rarity
    {
        Normal,
        Rare,
        Unique,
        Legendary
    }

    public Weapon(string name, int damage, ItemType type, Rarity rarity, float min, float max, bool rapidFire,bool shotgun,string spriteName,UniqueParamator uniqueParamator,int uniqueSlotsCount){
        this.name = name;
        this.damage = damage;
        this.itemType = type;
        this.rarity = rarity;
        this.min = min;
        this.max = max;
        this.rapidFire = rapidFire;
        this.shotgun = shotgun;
        itemIcon = Resources.Load<Sprite>("Sprite/" + spriteName);
        uniqueSlots = new UniqueParamator[uniqueSlotsCount];
        if(uniqueSlotsCount > 0)
        uniqueSlots[0] = uniqueParamator;
    }
}
