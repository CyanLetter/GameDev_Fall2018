using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public int score = 0;
    public float spawnTime = 2f;
    float timeSinceLastSpawn = 0f;

    public Text scoreText;
    public Button reloadButton;

    public GameObject pipePrefab;
    public Transform spawnLocation;
    public float spawnHeightRange = 5f;

    bool gameOver = false;

	// Use this for initialization
	void Start () {
        scoreText.text = "0";
        reloadButton.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (gameOver) {
            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= spawnTime) {
            Spawn();
            timeSinceLastSpawn = 0;
        }
	}

    void Spawn() {
        float spawnHeight = Random.Range(spawnLocation.position.y + spawnHeightRange, spawnLocation.position.y - spawnHeightRange);
        Vector2 spawnPos = new Vector2(spawnLocation.position.x, spawnHeight);
        GameObject newPipe = Instantiate(pipePrefab, spawnPos, spawnLocation.rotation);
    }

    public void AddPoints() {
        score++;
        scoreText.text = score.ToString();
    }

    public void OnGameOver() {
        scoreText.text = "Game Over";
        gameOver = true;
        reloadButton.gameObject.SetActive(true);
    }

    public void Restart() {
        SceneManager.LoadScene("SampleScene");
    }
}
