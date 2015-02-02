#include "Wrapper.h"

bool** Wrapper::WrapperAlgo::possible(int type, int x, int y, int sizeMap, array<array<int>^>^ mapElement, double defaultMovePts){

	int** mapBis = new int*[sizeMap];
	for (int i = 0; i < sizeMap; i++) {
		mapBis[i] = new int[sizeMap];
		for (int j = 0; j < sizeMap; j++) {
			mapBis[i][j] = (int)mapElement[i][j];
		}
	}

	bool** mapMove = Algo::possibleTile(sizeMap, x, y, type, mapBis, defaultMovePts);

	return mapMove;
}