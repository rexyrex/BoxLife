using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour,IWeapon {

	private Animator animator;
	public bool isAttacking;
    public GameObject explosion;

	public void PerformAttack ()
	{
		animator.SetTrigger ("Base_Attack");
        AudioController.ac.playSound("swing", "player");
	}

	public void PerformSpecialAttack ()
	{
		animator.SetTrigger ("Spin_Attack");
        AudioController.ac.playSound("swing", "player");
    }

	public List<baseStat> Stats {
		get ;
		set ;
	}

	void Start(){
		animator = GetComponent<Animator> ();
		FloatingTextController.Initialize ();
        explosion = Resources.Load<GameObject>("ParticleEffects/HitParticleEffect");
        
    }

	void OnTriggerEnter(Collider col){



		Debug.Log ("Sword hit " + col.name);

		if (col.tag == "Enemy") {
            int damage = (int)Random.Range(GlobalPlayerData.gpd.getMinDamage(), GlobalPlayerData.gpd.getMaxDamage());
            float offsetX = Random.Range(-0.2f, 0.2f);
            float offsetY = Random.Range(-0.2f, 0.2f);
            float offsetZ = Random.Range(-0.2f, 0.2f);
            Vector3 randomOffsetVector = new Vector3(offsetX, offsetY, offsetZ);

            FloatingTextController.CreatFloatingText (damage.ToString(), col.transform , Color.red);
			col.GetComponent<IEnemy> ().TakeDamage (damage);
/*
            Color c = explosion.GetComponent<ParticleSystem>().main.startColor.color;
            c = Color.blue;
            ParticleSystem ps = explosion.GetComponent<ParticleSystem>();
            ps.startColor = col.GetComponent<Material>().color; ;
  */          
            GameObject explosionInstance = Instantiate(explosion, col.transform.position + randomOffsetVector, Quaternion.identity);
            Destroy(explosionInstance, 2f);
		}
	}



}
