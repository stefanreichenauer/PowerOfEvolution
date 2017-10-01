using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    public int experiencePoints = 0;
    public int level = 1;
    public int skillPoints = 0;

    int levelThreshold = 100;

    List<Skill> skills = new List<Skill>();

    public UI ui;

    PlayerAttack playerAttack;

    float timeBetweenCollisionDamage;

    public bool colliding = false;
    
    public GameController gameController;

    public Transform firstLevelSpawn;
    public Transform secondLevelSpawn;
    public Transform thirdLevelSpawn;

    PlayerModelChanger modelChanger;

    private void Awake()
    {
        DontDestroyOnLoad(transform.root.gameObject);
    }

    // Use this for initialization
    void Start () {
        playerAttack = GetComponent<PlayerAttack>();
        modelChanger = GetComponent<PlayerModelChanger>();
        timeBetweenCollisionDamage = Time.time;
       // AddSkill(new Skill(1, "horns", new Skill[] { }));
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.V))
        {
            gameController.LoadScene(3);
        }

       // Debug.Log("Test: level: " + level);
    }

    public void increaseExperiencePoints(int expPoints)
    {
        Debug.Log("Player: IncreaseExperiencePoints: " + expPoints);
        experiencePoints += expPoints;

        if(experiencePoints >= levelThreshold)
        {
            experiencePoints -= levelThreshold;
            levelThreshold = (level + 1) * 100;
            skillPoints++;
            level++;
            FindObjectOfType<AudioManager>().Play("level_up");
            ui.changeLevelText(level);
            ui.toggleSkillMessage(true);
        }

        ui.changeExperienceBar(levelThreshold, experiencePoints);
    }

	public void decreaseSkillPoints(int skillPnts)
	{
		if (skillPoints - skillPnts >= 0) {
			skillPoints -= skillPnts;
            if(skillPoints == 0)
            {
                ui.toggleSkillMessage(false);
            }
		}
		Debug.Log (skillPoints);
	}

    public void takeDamage(int healthLoss)
    {
        health = Mathf.Max(0, health - healthLoss);
        ui.changeHealthBar(100f, health);
        //Debug.Log("Enemy healthLoss: health - " + health);
        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
    }


    public void AddSkill(Skill skill)
    {
        skills.Add(skill);

        bool legs = HasSkill("legs");
        bool horns = HasSkill("horns");
        bool hands = HasSkill("hand");
        bool spikes = HasSkill("spikes");
       // Debug.Log("AddSkill: " + legs + " - " + horns + " - " + hands + " - " + spikes);
        modelChanger.changeModel(legs, horns, hands, spikes);
    }

	public bool HasRequirements(Skill skill) {
		foreach (Skill s in skill.Requirements) {
			if (!HasSkill (s.Name)) {
				return false;
			}
		}
		return true;
	}

    public bool HasSkill(string skillName)
    {
        foreach(Skill skill in skills)
        {
            if(skill.Name == skillName)
            {
                return true;
            }
        }

        return false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        colliding = true;
            Debug.Log("Charging Hit: " + playerAttack.chargingAttack);
        if (collision.gameObject.tag == "Enemy")
        {
            if (playerAttack.chargingAttack)
            {
                Debug.Log("Charging Hit: " + playerAttack.chargingAttack);
                collision.gameObject.GetComponent<Enemy>().takeDamage(10);
                playerAttack.chargingAttack = false;
            }
            if (HasSkill("Spikes") && Time.time - timeBetweenCollisionDamage > 1.0f)
            {
                collision.gameObject.GetComponent<Enemy>().takeDamage(10);
            }
        }
        if (collision.gameObject.tag == "EnemyCrab")
        {
            if (playerAttack.chargingAttack)
            {
                Debug.Log("Charging Hit: " + playerAttack.chargingAttack);
                collision.gameObject.GetComponent<EnemyCrab>().takeDamage(10);
                playerAttack.chargingAttack = false;
            }
            else
            {
                takeDamage(10);
            }
            if (HasSkill("Spikes") && Time.time - timeBetweenCollisionDamage > 1.0f)
            {
                collision.gameObject.GetComponent<EnemyCrab>().takeDamage(10);
            }
        }

        if (collision.gameObject.tag == "LevelChange")
        {
            if (HasSkill("legs"))
            {
                gameController.LoadScene(2);

            }
        }

        if (collision.gameObject.tag == "Shell")
        {
            takeDamage(10);
        }

        if (collision.gameObject.tag == "TunnelBlockade" && playerAttack.chargingAttack)
        {
            playerAttack.chargingAttack = false;
            Destroy(collision.gameObject);
            StartCoroutine("LoadThirdLevel");
        }
        
    }

    IEnumerator LoadThirdLevel()
    {
        yield return new WaitForSeconds(1.0f);
        gameController.LoadScene(3);
    }

    private void OnCollisionExit(Collision collision)
    {
        colliding = false;
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 2)
        {
            gameObject.transform.position = secondLevelSpawn.position;
            gameObject.transform.rotation = secondLevelSpawn.rotation;

            GetComponent<Rigidbody>().useGravity = true;

            GameObject crabSpawner = GameObject.FindGameObjectWithTag("CrabSpawner");
            crabSpawner.GetComponent<CrabSpawner>().player = this;
        }
    }


}
