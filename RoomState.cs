using System;
using System.Collections;
using System.Collections.Generic;
using FRPG.Gameplay;
using UnityEngine;

namespace FRPG.Gameplay {
	public class RoomState {
		public int roomLength { get; set; }
		public int roomWidth { get; set; }
		public int[] characterPosition { get; set; }
		public int[,] room { get; set; }
		
		public void InitializeRoomState() {
			for (int i = 0; i < roomLength; ++i) {
				room[0,i] = -1;
				room[roomWidth - 1,i] = -1;
			}
			for (int i = 0; i < roomWidth; ++i) {
				room[i,0] = -1;
				room[i,roomLength - 1] = -1;
			}
			characterPosition = new int[2];
			
			/*
			characterPosition = new int[2];
			characterPosition[0] = roomWidth / 2;
			characterPosition[1] = roomLength / 2;
			room[characterPosition[0],characterPosition[1]];

			
			characterPosition[0] = 3;
			characterPosition[1] = 3;
			room[3,3] = 2;
			
			room[9,2] = 1;
			room[3,12] = 1;
			room[2,6] = 1;
			

			get position of the player, boxes, and obstacles
			Player = 2
			Box = 1
			Empty = 0
			Obstacle/Wall = -1
			Page = 3
			*/
		}
		public void UpdateRoomState(int[] characterVelocity) {
			int[] newCharacterPosition = new int[2];
			for (int i = 0; i < 2; ++i)
				newCharacterPosition[i] = characterPosition[i] + characterVelocity[i];
			if (room[newCharacterPosition[0],newCharacterPosition[1]] != -1) {
				if (room[newCharacterPosition[0],newCharacterPosition[1]] == 1) {
					int[] tempBoxPosition = new int[2];
					for (int i = 0; i < 2; ++i)
						tempBoxPosition[i] = newCharacterPosition[i] + characterVelocity[i];
					if (room[tempBoxPosition[0],tempBoxPosition[1]] == 0) {
						room[tempBoxPosition[0],tempBoxPosition[1]] = 1;
						room[characterPosition[0],characterPosition[1]] = 0;
						room[newCharacterPosition[0],newCharacterPosition[1]] = 2;
						for (int i = 0; i < 2; ++i)
							characterPosition[i] = newCharacterPosition[i];
					}
				}
				else if (room[newCharacterPosition[0],newCharacterPosition[1]] == 0) {
					room[characterPosition[0],characterPosition[1]] = 0;
					room[newCharacterPosition[0],newCharacterPosition[1]] = 2;
					for (int i = 0; i < 2; ++i)
						characterPosition[i] = newCharacterPosition[i];
				}
			}
		}
		/*
		As player's vector [a, b] is obtained, check the object next to player in the direction of the vector
		- If it's free, move. If it's a wall, stop.
		- If it's a box, check the object next to said box in the direction of the vector. If it's free, move. If it's a wall or another box, stop.
		The tile where player used to be is now an empty tile.
		*/
	}
}