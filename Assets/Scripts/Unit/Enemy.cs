using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour {
    public NavMeshAgent agent;

    SphereCollider sphereCollider;

    public float SightRange;

    public GameObject target;

    public GameObject sightCollider;

    public int MaxHP = 100;
    public int HP;

    private HPStatusUI hpStatusUI;

	// Use this for initialization
	void Start () {
        sightCollider.AddComponent<SphereCollider>();
        HP = MaxHP;
        sphereCollider = sightCollider.GetComponent<SphereCollider>();
        sphereCollider.isTrigger = true;
        sphereCollider.radius = SightRange;
        sightCollider.gameObject.layer = LayerMask.NameToLayer("AI");

        agent = GetComponent<NavMeshAgent>();
        hpStatusUI = GetComponentInChildren<HPStatusUI>();
	}
	
	// Update is called once per frame
	void Update () {

        if(target != null)
            agent.SetDestination(target.transform.position);

        if(HP <= 0){
            Die();
        }
	}

	public void OnTriggerEnter(Collider other)
	{
        if(other.tag == "Player"){
            target = other.gameObject;
        }
	}

    public void TakeDamage(int damage){
        HP -= damage;
        hpStatusUI.UpdateHPValue();
    }

    public void Die(){
        ItemDrop();
        Destroy(gameObject);
    }

    public void ItemDrop(){
        GameObject dropItem =  Instantiate(Resources.Load("Prefabs/Item1") as GameObject);
        dropItem.transform.position = this.transform.position;
    }
}
