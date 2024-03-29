using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMgmt : MonoBehaviour {

  private GameObject player;
  private GameObject pointer;
  private Player playerScript;
  private Pointer pointerScript;
  private AudioMgmt audioManager;
  private TMP_Text scoreText;
  private TMP_Text livesText;
  private TMP_Text IdleText;
  private GameObject gameOverScreen;

  private float time = 0;
  
  private int score = 0;
  private int lives = 4;

  private float scoreTimer = 0f;
  private float scoreCoolDown = .5f;

  private float idleTimer = 6f;

  private float livesTimer = 0f;
  private float livesCoolDown = .5f;

  private bool playerIsDead = false;

  private void Awake() {
    player = GameObject.Find("Player");
    pointer = GameObject.Find("Pointer");
    playerScript = player.GetComponent<Player>();
    pointerScript = pointer.GetComponent<Pointer>();
    audioManager = GameObject.Find("Audio Manager").GetComponent<AudioMgmt>();
    scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
    livesText = GameObject.Find("Lives Text").GetComponent<TMP_Text>();
    IdleText = GameObject.Find("Idle Text").GetComponent<TMP_Text>();
    gameOverScreen = GameObject.Find("Game Over Screen");
    gameOverScreen.SetActive(false);
  }

  private void Update() {
    time += Time.deltaTime;
    Score();
    Idle();
    Death();
    Reset();
    if (Input.GetKeyDown(KeyCode.Escape))
    {
      GameOver();
    }
  }

  private void Start() {
    scoreText.text = "Score: " + score;
    livesText.text = "Lives: " + lives;
  }

  public void Score() {
    if (playerScript.onPointer() && (time - scoreTimer) >= scoreCoolDown) {
      score++;
      idleTimer = 6f;
      scoreTimer = time;
      pointerScript.RandomizeSpeed();
      scoreText.text = "Score: " + score;
      audioManager.PlayPointSfx();
    }
  }

  private void Death() {
    if (player.transform.position.z >= 20f && (time - livesTimer) >= livesCoolDown) {
      if (lives > 0) {
        lives--;
        livesTimer = time;
        livesText.text = "Lives: " + lives;
        playerScript.Reset();
        audioManager.PlayFallSfx();
      }
      else {
        GameOver();
      }
    }
	}

  private void GameOver() {
    if (!playerIsDead)
    {
      lives=-1;
      gameOverScreen.SetActive(true);
      pointer.SetActive(false);
      player.transform.position = new Vector3(50,0,-50f);
      player.SetActive(false);
      idleTimer = 0; 
      IdleText.text = "0";
      audioManager.PlayGameOverSfx();
      audioManager.PlayGameOverMusic();
      playerIsDead = true;
    }
  }

  private void Idle() {
    if (idleTimer > 0) {
      idleTimer -= Time.deltaTime;
      IdleText.text = idleTimer.ToString("#.00");
    }
    else {
      idleTimer = 0; 
      IdleText.text = "0";
    }
    if (idleTimer <= 0)
    {
      GameOver();
    }
  }

  private void Reset() {
    if (lives < 0 && Input.GetKeyDown(KeyCode.R)) {
      gameOverScreen.SetActive(false);
      pointer.SetActive(true);
      pointer.transform.position = new Vector3(0,5,0.48f);
      player.SetActive(true);
      playerScript.Reset();
      pointerScript.ResetSpeed();
      lives = 4;
      score = 0;
      idleTimer = 6f;
      audioManager.PlayGameMusic();
      livesText.text = "Lives: " + lives;
      scoreText.text = "Score: " + score;
      playerIsDead = false;
    }
  }
}
