using System;
using System.Collections;
using System.Collections.Generic;
using FRPG.Gameplay;
using UnityEngine;

namespace FRPG.Gameplay {
	public class PushDetection : MonoBehaviour {
		Vector3 boxPosition;
		float speed = 5f;
		public int[] roomDimensions = new int[2];
		public int[] boxPositions = new int[50];
		RoomState roomState = new RoomState();
		void Start() {
			boxPosition = transform.position;
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
			//Vector3 boxPosition = transform.position;
			
			if (Input.GetKeyDown(KeyCode.UpArrow)) {
				roomState.UpdateRoomState(new int[] {1,0});

				if (roomState.room[Convert.ToInt32(Math.Floor(boxPosition.y))
				,Convert.ToInt32(Math.Floor(boxPosition.x))] == 2) {
					boxPosition.y += speed * 0.2f;
				}
				//boxPosition.y += speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.DownArrow)) {
				roomState.UpdateRoomState(new int[] {-1,0});

				if (roomState.room[Convert.ToInt32(Math.Floor(boxPosition.y))
				,Convert.ToInt32(Math.Floor(boxPosition.x))] == 2) {
					boxPosition.y -= speed * 0.2f;
				}
				//boxPosition.y -= speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.LeftArrow)) {
				roomState.UpdateRoomState(new int[] {0,-1});

				if (roomState.room[Convert.ToInt32(Math.Floor(boxPosition.y))
				,Convert.ToInt32(Math.Floor(boxPosition.x))] == 2) {
					boxPosition.x -= speed * 0.2f;
				}
				//boxPosition.x -= speed * 0.2f;
			}
			if (Input.GetKeyDown(KeyCode.RightArrow)) {
				roomState.UpdateRoomState(new int[] {0,1});

				if (roomState.room[Convert.ToInt32(Math.Floor(boxPosition.y))
				,Convert.ToInt32(Math.Floor(boxPosition.x))] == 2) {
					boxPosition.x += speed * 0.2f;
				}
				//boxPosition.x += speed * 0.2f;
			}

			transform.position = boxPosition;
		}
	}
}