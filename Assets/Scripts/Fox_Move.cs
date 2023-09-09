using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class Fox_Move : MonoBehaviour {

    public float speed,jumpForce,cooldownHit;
	public bool running,up,down,jumping,crouching,attacking,special;
    private Rigidbody2D rb;
    private Animator anim;
	private SpriteRenderer sp;
	private float rateOfHit;
	private GameObject[] life;
	private int qtdLife;
	private Enemytrap manager;
	public AudioSource punchsound;
	public AudioSource Jumpcsound;


	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
		sp=GetComponent<SpriteRenderer>();
		manager = GameObject.Find("Player").GetComponent<Enemytrap>();
		running =false;
		up=false;
		down=false;
		jumping=false	;
		crouching=false;
		rateOfHit=Time.time;
		//life=GameObject.FindGameObjectsWithTag("Life");
		//qtdLife=life.Length;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//Character doesnt choose direction in Jump	   //If you want to choose direction in jump
		if (!manager.isdead)
		{
			if (attacking == false)
			{                                                   //just delete the (jumping==false)
				if (crouching == false)
				{
					Movement();
					Attack();
					Special();
				}
				Jump();
				Crouch();
				
			}

		}
        else { dead(); }
			
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
			Jumpcsound.Play();

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
			punchsound.Play();
		}
	}

	void AttackEnd(){
		attacking=false;
	}

	void Special(){
			anim.SetBool("Special",false);
		
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
		Debug.Log("manga");
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
