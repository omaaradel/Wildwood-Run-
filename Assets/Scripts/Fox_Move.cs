using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

	public bool running, up, down, jumping, crouching, attacking, shooting;

    private Rigidbody2D rb;
    private Animator anim;
	private SpriteRenderer sp;
	private Enemytrap manager;
	private AudioManager audioManager;
	private winning wonManager;
	private float buildIndex;

	[SerializeField] Transform firePoint;
	[SerializeField] GameObject bulletPrefab;
	[SerializeField] float speed, jumpForce, cooldownHit;
	[SerializeField] float bulletSpeed = 10f;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		manager = GameObject.Find("Player").GetComponent<Enemytrap>();
		audioManager = GameObject.Find("Audio Manager").GetComponent<AudioManager>();
		wonManager = GameObject.Find("Chest Golden").GetComponent<winning>();
		Scene currentScene = SceneManager.GetActiveScene();
		buildIndex = currentScene.buildIndex;
		running =false;
		up=false;
		down=false;
		jumping=false	;
		crouching=false;
	}

	void FixedUpdate()
	{
		
		if (!manager.isdead && !wonManager.won)
		{
			if (attacking == false)
			{                                                  
				if (crouching == false)
				{
					Movement();
					Attack();
					if (buildIndex == 5)  Shoot();
				}
				Jump();
				Crouch();

			}

		}
		else if (manager.isdead) { dead(); }
		 if (wonManager.won) {
			running = false;
			up = false;
			down = false;
			jumping = false;
			crouching = false;
		}

	}



void Movement(){
		//Character Move
		float move = Input.GetAxisRaw("Horizontal");
			//Run
			rb.velocity = new Vector2(move*speed*Time.deltaTime*2,rb.velocity.y);
			running=true;
		

		//Turn
		if(rb.velocity.x<0){
			sp.flipX=true;
		}else if(rb.velocity.x>0){
			sp.flipX=false;
		}
		//Movement Animation
		//if(rb.velocity.x!=0&&running==false){
		//	anim.SetBool("Walking",true);
		//}else{
		//	anim.SetBool("Walking",false);
		//}
		if(rb.velocity.x!=0&&running==true){
			anim.SetBool("Running",true);
		}else{
			anim.SetBool("Running",false);
		}
	}

	void Jump(){
		//Jump
		if(Input.GetKey(KeyCode.Space)&&rb.velocity.y==0){
			rb.AddForce(new Vector2(rb.velocity.x,jumpForce));
			audioManager.playSFX(audioManager.playerJump);

		}
		//Jump Animation
		if(rb.velocity.y>0&&up==false){
			up=true;
			jumping=true;
			anim.SetTrigger("Up");
		}else if(rb.velocity.y<0&&down==false){
			down=true;
			jumping=true;
			anim.SetTrigger("Down");
		}else if(rb.velocity.y==0&&(up==true||down==true)){
			up=false;
			down=false;
			jumping=false;
			anim.SetTrigger("Ground");
		}
	}

	void Attack(){																//I activated the attack animation and when the 
		//Atacking																//animation finish the event calls the AttackEnd()
		if(Input.GetKey(KeyCode.C)){
			rb.velocity=new Vector2(0,0);
			anim.SetTrigger("Attack");
			attacking=true;
			audioManager.playSFX(audioManager.playerPunch);
		}
        
	}

	void AttackEnd(){
		attacking=false;
	}

	void Shoot(){	
			
		if (Input.GetKey(KeyCode.S) )
		{
			anim.SetBool("Special", true);
			Shooty();
		}

		else
		{
			anim.SetBool("Special", false);
			
		}

	}
	void Shooty()
	{
		GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
		audioManager.playSFX(audioManager.playerShoot);
		bullet.transform.Rotate(Vector3.forward * -90);
		Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
		rb.velocity = firePoint.right * bulletSpeed;

		Destroy(bullet, 1f);
	}

	void Crouch(){
		//Crouch
		if(Input.GetKey(KeyCode.DownArrow)){
			anim.SetBool("Crouching",true);
		}else{
			anim.SetBool("Crouching",false);
		}
	}
	void dead()
	{
		
		anim.SetTrigger("Dead");
		rb.bodyType = RigidbodyType2D.Static;
		
	}



	//void OnTriggerEnter2D(Collider2D other){							//Case of Bullet
	//	if(other.tag=="Enemy"){
	//		anim.SetTrigger("Damage");
	//		//Hurt();
	//	}
	//}								

	//void OnCollisionEnter2D(Collision2D other) {						//Case of Touch
	//	if(other.gameObject.tag=="Enemy"){
	//		anim.SetTrigger("Damage");
	//		//Hurt();
	//	}
	//}

	//void Hurt(){
	//	if(rateOfHit<Time.time){
	//		rateOfHit=Time.time+cooldownHit;
	//		Destroy(life[qtdLife-1]);
	//		qtdLife-=1;
	//	}
	//}


}
	