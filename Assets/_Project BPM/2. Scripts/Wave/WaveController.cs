using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class WaveController : MonoBehaviour
{
	public ZombieAgent zombiePrefabs;
	public int zombiePerWave;
	int zombieRemain;
	List<ZombieAgent> zombieAgents;
	public Transform center;
	public Vector2 randomRange;
	public ScoreController scoreController;
	public TMP_Text remainZombieText;
	public int ZombieRemain { get => zombieRemain; 
		set 
		{
			zombieRemain = value;
			remainZombieText.text = $"ZOM:{zombieRemain}/{zombiePerWave}";
			if (zombieRemain <= 0)
			{
				EndRound();
			}
		}
	}

	private void EndRound()
	{
		//Change music sth
		StartNewWave();
	}

	ZombieAgent SpawnRandom()
	{
		float x = Random.Range(-randomRange.x, randomRange.x);
		float y = Random.Range(-randomRange.y, randomRange.y);
		Vector3 newPos = center.position + center.right*x + center.forward*y;
		ZombieAgent zombie = Instantiate(zombiePrefabs, newPos, Quaternion.identity);
		return zombie;
	}
	void StartNewWave()
	{
		if (zombieAgents == null)
			zombieAgents = new List<ZombieAgent>();
		zombieAgents.Clear();
		zombiePerWave += 3;
		for (int i = 0; i < zombiePerWave; ++i)
		{
			ZombieAgent zombie = SpawnRandom();
			zombieAgents.Add(zombie);
			zombie.GetComponent<Health>().OnDie += () => {--ZombieRemain; scoreController.Score++;};
		}
		ZombieRemain = zombiePerWave;
	}
	private void Start() {
		StartNewWave();
	}
}
