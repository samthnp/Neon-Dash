using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Shoot : MonoBehaviour
{
   public GameObject shot;
   private Transform playerPosition;

   private float timeBetweenShots;
   public float startTimeBetweenShots;

   public AudioClip projectileFired;
   private AudioSource audioSource;

   private void Start()
   {
      playerPosition = GetComponent<Transform>();
      audioSource = GetComponent<AudioSource>();
   }

   private void Update()
   {
      if (timeBetweenShots <= 0)
      {
         if (Input.GetMouseButtonDown(0))
         {
            Instantiate(shot, playerPosition.position, Quaternion.identity);
            audioSource.PlayOneShot(projectileFired, 0.5f);
            timeBetweenShots = startTimeBetweenShots;
         }
      }
      else
      {
         timeBetweenShots -= Time.deltaTime;
      }
   }
}
