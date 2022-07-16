using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMgmt : MonoBehaviour
{

  private GameObject player;
  private Player playerScript;
  private float time = 0;

  private int score = 0;
  private float scoreTimer = 0f;
  private float scoreCoolDown = .5f;

  private void Awake() {
    player = GameObject.Find("Player");
    playerScript = player.GetComponent<Player>();
  }

  private void Update()
  {
    time += Time.deltaTime;
    Reset();
    ChangePerspective();
    Score();
  }

  public void Score()
  {
    if (playerScript.onPointer() && (time - scoreTimer) >= scoreCoolDown)
    {
      score++;
      scoreTimer = time;
      Debug.Log(score);
    }
  }

  private void Reset() {
    if (Input.GetKeyDown(KeyCode.R))
    {
      playerScript.Reset();
    }
	}

  private void ChangePerspective()
  {
    if (Input.GetKeyDown(KeyCode.P))
    {
      Camera.main.orthographic = !Camera.main.orthographic;
    }
  }
}
