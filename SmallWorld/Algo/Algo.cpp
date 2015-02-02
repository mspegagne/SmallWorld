#include "Algo.h"
#include <stdio.h>     
#include <stdlib.h>  
#include <time.h> 
#include <iostream>
#include <list>

#define NOCASE 0
#define DESERT 1
#define FOREST 2
#define MOUNTAIN 3
#define PLAIN 4
#define MARSH 5

#define NOTYPE 0
#define DWARF 1
#define ELF 2
#define ORC 3
#define HUMAN 4


int** Algo::buildMap(int size){

	int nbDesert = 0;
	int nbMountain = 0;
	int nbForest = 0;
	int nbPlain = 0;
	int nbMarsh = 0;

	int** map = new int*[size];
	for (int i = 0; i<size; i++) {
		map[i] = new int[size];
	}

	srand(time(NULL));
	bool a = true;
	
	for (int i = 0; i < size; i++)
	{
		for (int j = 0; j < size; j++)
		{
			while (a)
			{
				int random = rand() % 5 + 1;
				switch (random){
					case DESERT:
						if (nbDesert < (size * size) / 5)
						{
							map[i][j] = DESERT;
							nbDesert++;
							a = false;
						}
						break;

					case MOUNTAIN:
						if (nbMountain < (size * size) / 5)
						{
							map[i][j] = MOUNTAIN;
							nbMountain++;
							a = false;
						}
						break;
					case PLAIN:
						if (nbPlain < (size * size) / 5)
						{
							map[i][j] = PLAIN;
							nbPlain++;
							a = false;
						}
						break;
					case MARSH:
						if (nbMarsh < (size * size) / 5)
						{
							map[i][j] = MARSH;
							nbMarsh++;
							a = false;
						}
						break;

					default:
						map[i][j] = FOREST;
						nbForest++;
						a = false;
						break;
				}
			}
			a = true;			
		}
	}
	return map;
}

//Algo de placement des joueurs en debut de partie
int* Algo::placingPlayer(int size){

	srand(time(NULL));
	int* tablePlayer = new int[4];
	int Res = rand() % 2 + 1; // pour alterner l'apparition des joueurs

	if (Res == 1)
	{
		tablePlayer[0] = 0; //x j1
		tablePlayer[1] = 0; //y j1
		tablePlayer[2] = size - 1; //x j2
		tablePlayer[3] = size - 1; //y j2

	}
	else
	{
		tablePlayer[0] = size - 1;
		tablePlayer[1] = size - 1;
		tablePlayer[2] = 0;
		tablePlayer[3] = 0;
	}
	return tablePlayer;

}

//Case Nord Ouest
bool** Algo::possibleTileNW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((x - 1) >= 0 && (y - 1) >= 0 && mapElement[x - 1][y - 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x - 1][y - 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x - 1][y - 1] == bonus){
				mapMove[x - 1][y - 1] = true;
			}
		}
	}
	else{
		if ((x - 1) >= 0 && mapElement[x - 1][y] != malus){
			if (defaultMovePts == 1){
				mapMove[x - 1][y] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x - 1][y] == bonus){
				mapMove[x - 1][y] = true;
			}
		}
	}

	return mapMove;
}

//Case Ouest
bool** Algo::possibleTileW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((y - 1) >= 0 && mapElement[x][y - 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x][y - 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x - 1][y - 1] == bonus){
				mapMove[x][y - 1] = true;
			}
		}
	}
	else{
		if ((y - 1) >= 0 && mapElement[x][y - 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x][y - 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x][y - 1] == bonus){
				mapMove[x][y - 1] = true;
			}
		}
	}

	return mapMove;
}

//Case Sud Ouest
bool** Algo::possibleTileSW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((x + 1) < size && (y - 1) >= 0 && mapElement[x + 1][y - 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x + 1][y - 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x + 1][y - 1] == bonus){
				mapMove[x + 1][y - 1] = true;
			}
		}
	}
	else{
		if ((x + 1) < size && mapElement[x + 1][y] != malus){
			if (defaultMovePts == 1){
				mapMove[x + 1][y] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x + 1][y] == bonus){
				mapMove[x + 1][y] = true;
			}
		}
	}

	return mapMove;
}

//Case Sud Est
bool** Algo::possibleTileSE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((x + 1) < size  && mapElement[x + 1][y] != malus){
			if (defaultMovePts == 1){
				mapMove[x + 1][y] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x + 1][y] == bonus){
				mapMove[x + 1][y] = true;
			}
		}
	}
	else{
		if ((x + 1) < size && (y + 1) < size && mapElement[x + 1][y + 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x + 1][y + 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x + 1][y + 1] == bonus){
				mapMove[x + 1][y + 1] = true;
			}
		}
	}

	return mapMove;
}

//Case Est
bool** Algo::possibleTileE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((y + 1) < size  && mapElement[x][y + 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x][y + 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x][y + 1] == bonus){
				mapMove[x][y + 1] = true;
			}
		}
	}
	else{
		if ((y + 1) < size && mapElement[x][y + 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x][y + 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x][y + 1] == bonus){
				mapMove[x][y + 1] = true;
			}
		}
	}

	return mapMove;
}

//Case Nord Est
bool** Algo::possibleTileNE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	if (x % 2 == 0){
		if ((x - 1) >= 0 && mapElement[x - 1][y] != malus){
			if (defaultMovePts == 1){
				mapMove[x - 1][y] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x - 1][y] == bonus){
				mapMove[x - 1][y] = true;
			}
		}
	}
	else{
		if ((x - 1) >= 0 && (y + 1) < size && mapElement[x - 1][y + 1] != malus){
			if (defaultMovePts == 1){
				mapMove[x - 1][y + 1] = true;
			}
			else if (defaultMovePts == 0.5 && mapElement[x - 1][y + 1] == bonus){
				mapMove[x - 1][y + 1] = true;
			}
		}
	}

	return mapMove;
}

//Toutes les cases voisines
bool** Algo::possibleTileAll(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	mapMove = Algo::possibleTileNW(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);
	mapMove = Algo::possibleTileW(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);
	mapMove = Algo::possibleTileSW(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);
	mapMove = Algo::possibleTileSE(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);
	mapMove = Algo::possibleTileE(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);
	mapMove = Algo::possibleTileNE(x, y, size, bonus, malus, mapMove, mapElement, defaultMovePts);

	return mapMove;
}

//Dans le cas ou c'est un nain
bool** Algo::possibleDwarf(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	// Particularité Montagne
	if (mapElement[x][y] == MOUNTAIN && defaultMovePts == 1){
		for (int i = 0; i < size; i++){
			for (int j = 0; j < size; j++){
				if (mapElement[i][j] == MOUNTAIN){
					if (i == x && j == y){
					}
					else{
						mapMove[i][j] = true;
					}
				}
			}
		}
	}

	return Algo::possibleTileAll(x, y, size, NOCASE, PLAIN, mapMove, mapElement, defaultMovePts);

}

bool** Algo::possibleElf(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	return Algo::possibleTileAll(x, y, size, DESERT, FOREST, mapMove, mapElement, defaultMovePts);

}

bool** Algo::possibleOrc(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts){
	
	// BONUS Particularité Marais 
	if (mapElement[x][y] == MARSH && defaultMovePts == 1){
		for (int i = 0; i < size; i++){
			for (int j = 0; j < size; j++){
				if (mapElement[i][j] == MARSH){
					if (i == x && j == y){
					}
					else{
						mapMove[i][j] = true;
					}
				}
			}
		}
	}
	return Algo::possibleTileAll(x, y, size, NOCASE, PLAIN, mapMove, mapElement, defaultMovePts);

}

bool** Algo::possibleHuman(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts){

	return Algo::possibleTileAll(x, y, size, NOCASE, PLAIN, mapMove, mapElement, defaultMovePts);

}



bool** Algo::possibleTile(int type, int x, int y, int size, int** mapElement, double defaultMovePts){

	//mapMove va contenir pour chaque case de la map si oui ou non l'unite peut se deplacer
	//initialisation
	bool** mapMove = new bool*[size];
	for (int i = 0; i < size; i++){
		mapMove[i] = new bool[size];
		for (int j = 0; j < size; j++){
			mapMove[i][j] = false;
		}
	}

	//Génération en fonction du type
	switch (type){
		case DWARF :
			return Algo::possibleDwarf(x, y, size, mapMove, mapElement, defaultMovePts);
			break;
		case ELF:
			return Algo::possibleElf(x, y, size, mapMove, mapElement, defaultMovePts);
			break;
		case ORC:
			return Algo::possibleOrc(x, y, size, mapMove, mapElement, defaultMovePts);
			break;
		default:
			return Algo::possibleHuman(x, y, size, mapMove, mapElement, defaultMovePts);
			break;
	}
}