using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMgmt : MonoBehaviour {

  private GameObject player;
  private GameObject pointer;
  private Player playerScript;
  private TMP_Text scoreText;
  private TMP_Text livesText;
  private GameObject gameOverScreen;

  private float time = 0;
  
  private int score = 0;
  private int lives = 4;
  private float scoreTimer = 0f;
  private float scoreCoolDown = .5f;

  private float livesTimer = 0f;
  private float livesCoolDown = .5f;

  private void Awake() {
    player = GameObject.Find("Player");
    pointer = GameObject.Find("Pointer");
    playerScript = player.GetComponent<Player>();
    scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
    livesText = GameObject.Find("Lives Text").GetComponent<TMP_Text>();
    gameOverScreen = GameObject.Find("Game Over Screen");
    gameOverScreen.SetActive(false);
  }

  private void Update() {
    time += Time.deltaTime;
    Score();
    Death();
    Reset();
  }

  private void Start() {
    scoreText.text = "Score: " + score;
    livesText.text = "Lives: " + lives;
  }

  public void Score() {
    if (playerScript.onPointer() && (time - scoreTimer) >= scoreCoolDown) {
      score++;
      scoreTimer = time;
      scoreText.text = "Score: " + score;
    }
  }

  private void Death() {
    if (player.transform.position.z >= 20f && (time - livesTimer) >= livesCoolDown) {
      if (lives > 0) {
        lives--;
        livesTimer = time;
        livesText.text = "Lives: " + lives;
        playerScript.Reset();
      }
      else {
        lives--;
        gameOverScreen.SetActive(true);
        pointer.SetActive(false);
        player.transform.position = new Vector3(50,0,-50f);
        player.SetActive(false);
      }
    }
	}

  private void Reset() {
    if (lives < 0 && Input.GetKeyDown(KeyCode.R)) {
      gameOverScreen.SetActive(false);
      pointer.SetActive(true);
      pointer.transform.position = new Vector3(0,5,0.48f);
      player.SetActive(true);
      playerScript.Reset();
      lives = 4;
      score = 0;
      livesText.text = "Lives: " + lives;
      scoreText.text = "Score: " + score;
    }
  }
}
