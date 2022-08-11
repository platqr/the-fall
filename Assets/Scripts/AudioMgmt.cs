using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMgmt : MonoBehaviour {

  [SerializeField] private AudioSource gameMusic;
  [SerializeField] private AudioSource gameOverMusic;

  [SerializeField] private AudioSource jumpSfx;
  [SerializeField] private AudioSource pointSfx;
  [SerializeField] private AudioSource fallSfx;
  [SerializeField] private AudioSource gameOverSfx;

  public void PlayGameMusic() {
    gameMusic.Play();
    gameOverMusic.Pause();
  }

  public void PlayGameOverMusic() {
    gameOverMusic.Play();
    gameMusic.Pause();
  }

  public void PlayJumpSfx() {
    jumpSfx.Play();
  }
  public void PlayPointSfx() {
    pointSfx.Play();
  }
  public void PlayFallSfx() {
    fallSfx.Play();
  }
  public void PlayGameOverSfx() {
    gameOverSfx.Play();
  }
}
