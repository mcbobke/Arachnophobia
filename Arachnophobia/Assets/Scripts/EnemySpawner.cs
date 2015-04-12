using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {
	//Organization
	public GameObject EnemyHeir;				//For organizing heirarchy

	//Enemys to be spawned
	public GameObject[] EnemyTypes;				//Set enemy types to be spawned by spawner
	GameObject[] SpawnList;						//List of enemies to spawn

	//Spawning Handler
	public int[] SpawnAmount;					//Amount of enemies available for each tier
	public int TierTransition;					//Per how many kills to transition to next tier
	public int MaxEnemies;						//Max amount of enemies allowed
	public int SpawnRate;						//Initialize to starting rate
	public int active;							//Tells how many enemies are active
	public int KillCount = 0;					//Keeps track of how many enemies have been killed
													//To access next tier of enemies

	int maxIndex;								//For accessing higher tier of enemies
	int currentTier = 0;						//Keeps track enemy tiers allowable
	//Spawning Location
	float xDistance = 6;						//Max distance in x direction from center to spawn
	float yDistance = 5;						//Starting distance in sky

	// Use this for initialization
	void Start () {
        int eTier = 0;                          // Current tier that you are on
		int currentTierCount = 0;               // Amount of enemies created for current tier
		maxIndex = SpawnAmount[0];              // Last index of a created enemy in the game (e.g. how many enemies created, NOT spawned)
		active = 0;                             // How many enemies currently active (spawned)
		SpawnList = new GameObject[MaxEnemies];
		for (int i = 0; i <MaxEnemies; i++){
			if(currentTierCount >= SpawnAmount[eTier]){     // If # enemies of current tier at peak, go to next tier
				currentTierCount = 0;
				eTier++;
			}
			currentTierCount++;
			GameObject enemySpawned = (GameObject)Instantiate(EnemyTypes[eTier]);   // Create a new enemy of current tier
			enemySpawned.transform.parent = EnemyHeir.transform;                    // Use a fake transform
			enemySpawned.SetActive(false);
			SpawnList[i] = enemySpawned;                                            // Put it in array
		}
		InvokeRepeating("SpawnEnemy",0.0f, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (KillCount >= TierTransition){
			TierTransition += TierTransition;       // Move to next tier after certain # of kills
			EnemyTierProgression();
		}
	}

	void SpawnEnemy(){
		int spawned = 0;
		while(spawned < SpawnRate){
			if(active >= maxIndex-1){break;}               // Max number of enemies allowed to be active == last index of created enemies
			int spawnIndex = Random.Range (0, maxIndex-1); // Which one to spawn in SpawnList
			if(!SpawnList[spawnIndex].activeInHierarchy){
				float x_pos = Random.Range((float)(-1.0)*xDistance, xDistance);
				float y_pos = yDistance;
				float z_pos = SpawnList[spawnIndex].transform.position.z;
				SpawnList[spawnIndex].transform.position = new Vector3(x_pos,y_pos,z_pos);      // Gives it a randomized position in x-space
				SpawnList[spawnIndex].SetActive(true);
				spawned++;
				active++;
			}
		}
	}

	void EnemyTierProgression(){
		if(currentTier <EnemyTypes.Length-1)
			maxIndex += SpawnAmount[currentTier++];
		else if(SpawnRate <100)
			SpawnRate++;
	}
}
