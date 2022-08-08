using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameMgmt : MonoBehaviour
{

  private GameObject player;
  private Player playerScript;
  private TMP_Text scoreText;
  private TMP_Text livesText;

  private float time = 0;
  
  private int score = 0;
  private int lives = 5;
  private float scoreTimer = 0f;
  private float scoreCoolDown = .5f;

  private float livesTimer = 0f;
  private float livesCoolDown = .5f;

  private void Awake() {
    player = GameObject.Find("Player");
    playerScript = player.GetComponent<Player>();
    scoreText = GameObject.Find("Score Text").GetComponent<TMP_Text>();
    livesText = GameObject.Find("Lives Text").GetComponent<TMP_Text>();
  }

  private void Update()
  {
    time += Time.deltaTime;
    Score();
    Death();
  }

  public void Score()
  {
    if (playerScript.onPointer() && (time - scoreTimer) >= scoreCoolDown)
    {
      score++;
      scoreTimer = time;
      scoreText.text = "Score: " + score;
    }
  }

  private void Death() {
    if (player.transform.position.z >= 20f && (time - livesTimer) >= livesCoolDown)
    {
      lives--;
      livesTimer = time;
      livesText.text = "Lives: " + lives;
      playerScript.Reset();
    }
	}
}
