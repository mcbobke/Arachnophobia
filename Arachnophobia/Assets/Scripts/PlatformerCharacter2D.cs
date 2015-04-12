using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UnityStandardAssets._2D
{
    public class PlatformerCharacter2D : MonoBehaviour
    {
        private float m_MaxSpeed = 5f;                   // The fastest the player can travel in the x axis.
        private float m_JumpForce = 500f;                 // Amount of force added when the player jumps.
        private bool m_AirControl = true;                 // Whether or not a player can steer while jumping.
        const float k_GroundedRadius = .2f;               // Radius of the overlap circle to determine if grounded.
        private bool m_Grounded;                          // Whether or not the player is grounded.
        private bool m_FacingRight = false;                // For determining which way the player is currently facing.
        private bool bounce = false;                      // For determining whether or not the player should bounce.
        public int numLives;                              // How many lives the player has.
        private bool isAlive;                             // If the player is alive.
        private float elapsedTime;                        // Amount of time that has elapsed since last color switch.
        private int colorSwaps;                           // Number of color swaps that have been done.
        public int flashesBeforeNotInvincible;            // Number of total color changes (change and then change back) before becoming vulnerable again.
        private bool isInvincible;
        private float flashRate;

        private Transform m_GroundCheck;                  // A position marking where to check if the player is grounded.
        private Animator m_Anim;                          // Reference to the player's animator component.
        private Rigidbody2D m_Rigidbody2D;
        public EnemySpawner es;
        private List<String> objTags;
        private Color prevColor;
        public GameObject healthText;

        private void Awake()
        {
            // Setting up references.
            m_GroundCheck = transform.Find("GroundCheck");
            m_Anim = GetComponent<Animator>();
            m_Rigidbody2D = GetComponent<Rigidbody2D>();
            isAlive = true;
            objTags = new List<String> { "Spider", "ExplodeSpider", "Web", "WebSpider", "SpiderTall", "Boss Arm" };
            prevColor = new Color(255, 255, 255, 0.3f);
            isInvincible = false;
            flashRate = 0.2f;
        }

        private void Update()
        {
            healthText.GetComponent<Text>().text = numLives.ToString();
        }

        private void FixedUpdate()
        {
            m_Grounded = false;
            Vector2 vel = m_Rigidbody2D.velocity;

            // The player is grounded if a circlecast to the groundcheck position hits anything designated as ground
            // This can be done using layers instead but Sample Assets will not overwrite your project settings.
            Collider2D[] colliders = Physics2D.OverlapCircleAll(m_GroundCheck.position, k_GroundedRadius);
            for (int i = 0; i < colliders.Length; i++)
            {
                // m_Grounded should already be false at this point because you have to jump to be able to bounce, also have to be falling
                if (colliders[i].gameObject != gameObject && objTags.Contains(colliders[i].gameObject.tag) && m_Grounded == false && vel.y < 0)
                {
                    bounce = true;
                    
					//CHANGED FOR EXPLODING - Arielle
					if(colliders[i].gameObject.tag == "Boss Arm"){

					}
                    else if (colliders[i].gameObject.tag != "Web")
                    {
						if(colliders[i].gameObject.tag == "ExplodeSpider")
							colliders[i].gameObject.GetComponent<SpiderExplode>().Reset();
						es.active--;
						es.DeactivateSpider(colliders[i].gameObject);
						colliders[i].gameObject.SetActive(false);
						es.KillCount++;
                    }
                    else
                    {
                        Destroy(colliders[i].gameObject);
                    }
                }

                // The player hit the ground
                else if (colliders[i].gameObject != gameObject && colliders[i].gameObject.tag == "Ground")
                {
                    m_Grounded = true;
                }
            }

            if (isInvincible)
                InvincibleColorChange();

            m_Anim.SetBool("Ground", m_Grounded);
        }

        private void OnCollisionEnter2D(Collision2D coll)
        {
            if (objTags.Contains(coll.gameObject.tag) && coll.gameObject.tag != "Web")
            {
                if (!isInvincible && coll.gameObject.tag != "Boss Arm")
                {
                    if (numLives == 1)
                        isAlive = false;

                    else
                    {
                        --numLives;
                        coll.gameObject.SetActive(false);
                        isInvincible = true;
                        Debug.Log(isInvincible + " this should be true");
                    }

                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>());
                }

                else if (coll.gameObject.tag != "Boss Arm")
                {
                    coll.gameObject.SetActive(false);
                    Physics2D.IgnoreCollision(GetComponent<Collider2D>(), coll.gameObject.GetComponent<Collider2D>());
                }
            }

            Debug.Log(numLives);
        }

        public void Move(float move, bool jump)
        {
            //only control the player if grounded or airControl is turned on
            if (m_Grounded || m_AirControl)
            {
                // The Speed animator parameter is set to the absolute value of the horizontal input.
                m_Anim.SetFloat("Speed", Mathf.Abs(move));

                // Move the character
                m_Rigidbody2D.velocity = new Vector2(move * m_MaxSpeed, m_Rigidbody2D.velocity.y);

                // If the input is moving the player right and the player is facing left...
                if (move > 0 && !m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
                // Otherwise if the input is moving the player left and the player is facing right...
                else if (move < 0 && m_FacingRight)
                {
                    // ... flip the player.
                    Flip();
                }
            }

            // If the player should jump...
            if (m_Grounded && jump && m_Anim.GetBool("Ground"))
            {
                // Add a vertical force to the player.
                m_Grounded = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }

            // If the player should bounce...
            if (bounce)
            {
                bounce = false;
                m_Anim.SetBool("Ground", false);
                m_Rigidbody2D.velocity = new Vector2(0f, 0f);
                m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            }
        }


        private void Flip()
        {
            // Switch the way the player is labelled as facing.
            m_FacingRight = !m_FacingRight;

            // Multiply the player's x local scale by -1.
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

        private void SwapColor()
        {
            Color temp = GetComponent<SpriteRenderer>().color;
            GetComponent<SpriteRenderer>().color = prevColor;
            prevColor = temp;
        }

        private void InvincibleColorChange()
        {
            elapsedTime += Time.deltaTime;

            if (elapsedTime >= flashRate)
            {
                Debug.Log("Calling SwapColor");
                SwapColor();
                colorSwaps += 1;
                elapsedTime = 0.0f;
            }

            if ((colorSwaps / 2) >= flashesBeforeNotInvincible)
            {
                isInvincible = false;
                colorSwaps = 0;
            }
        }
		public void TakeDamage(){
			if(!isInvincible){
				isInvincible = true;
				numLives--;
			}
		}
    }
}