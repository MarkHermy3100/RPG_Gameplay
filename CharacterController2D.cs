using System;
using System.Collections;
using System.Collections.Generic;
using FRPG.Gameplay;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FRPG.Gameplay
{
	public class CharacterController2D : MonoBehaviour {
		public int gameOverScreen;
		public float speed = 0.5f;
		public int[] roomDimensions = new int[2];
		public Vector3 charPosition;
		public int[] boxPositions = new int[50];
		public int[] pagePosition = new int[2];
		RoomState roomState = new RoomState();
		void Start() {
			charPosition = transform.position;
			roomState.roomLength = roomDimensions[0];
			roomState.roomWidth = roomDimensions[1];
			roomState.room = new int[roomState.roomWidth,roomState.roomLength];
			roomState.InitializeRoomState();
			roomState.characterPosition[0] = roomState.roomWidth / 2;
			roomState.characterPosition[1] = roomState.roomLength / 2;
			roomState.room[roomState.roomWidth / 2,roomState.roomLength / 2] = 2;
			
			for (int i = 0; i < 50; i += 2) {
				if (boxPositions[i] == 0 && boxPositions[i + 1] == 0)
					break;
				roomState.room[boxPositions[i],boxPositions[i + 1]] = 1;
			}
		}
		void Update() {
			//Vector3 charPosition = transform.position;
			
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				roomState.UpdateRoomState(new int[] {1,0});

				if (roomState.room[Convert.ToInt32(Math.Floor(charPosition.y))
				,Convert.ToInt32(Math.Floor(charPosition.x))] == 0) {
					charPosition.y += speed * 0.2f;
				}
				//charPosition.y += speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				roomState.UpdateRoomState(new int[] {-1,0});

				if (roomState.room[Convert.ToInt32(Math.Floor(charPosition.y))
				,Convert.ToInt32(Math.Floor(charPosition.x))] == 0) {
					charPosition.y -= speed * 0.2f;
				}
				//charPosition.y -= speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				roomState.UpdateRoomState(new int[] {0,-1});

				if (roomState.room[Convert.ToInt32(Math.Floor(charPosition.y))
				,Convert.ToInt32(Math.Floor(charPosition.x))] == 0) {
					charPosition.x -= speed * 0.2f;
				}
				//charPosition.x -= speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				roomState.UpdateRoomState(new int[] {0,1});

				if (roomState.room[Convert.ToInt32(Math.Floor(charPosition.y))
				,Convert.ToInt32(Math.Floor(charPosition.x))] == 0) {
					charPosition.x += speed * 0.2f;
				}
				//charPosition.x += speed * 0.2f;
			}

			transform.position = charPosition;
			
			if (Input.GetKeyDown(KeyCode.R)) {
				SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
			}

			if (Convert.ToInt32(Math.Floor(charPosition.y)) == pagePosition[0]
			&& Convert.ToInt32(Math.Floor(charPosition.x)) == pagePosition[1]) {
				SceneManager.LoadScene(gameOverScreen, LoadSceneMode.Single);
			}
		}

		/*
		void OnDisable() {
			var roomState = new RoomState();
			roomState.roomLength = 5;
			roomState.roomWidth = 5;
			roomState.room = new int[roomState.roomWidth,roomState.roomLength];
			roomState.InitializeRoomState();
			for (int i = 0; i < roomState.roomWidth; ++i) {
				for (int j = 0; j < roomState.roomLength; ++j) {
					//Debug.Log(roomState.room[i, j] + "," + (i * 5 + j));
				}
			}
		}
		*/
	}
}