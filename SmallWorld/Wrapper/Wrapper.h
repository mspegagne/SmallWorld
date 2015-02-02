#ifndef __WRAPPER__
#define __WRAPPER__
#endif

#include "../Algo/Algo.h"

#pragma comment(lib, "../Release/Algo.lib")
//#pragma comment(lib, "../Debug/Algo.lib")

using namespace System;

namespace Wrapper {
	public ref class WrapperAlgo{
	private:
		
	public:
		Algo* algo;
		int** buildMap(int size){ return algo->buildMap(size); }
		int* placingPlayer(int size){ return algo->placingPlayer(size); }
		bool** possibleTile(int type, int x, int y, int size, int** mapElement, double defaultMovePts){
			return algo->possibleTile(type, x, y, size, mapElement, defaultMovePts);
		}
		bool** possible(int type, int x, int y, int sizeMap, array<array<int>^>^ mapElement, double defaultMovePts);
	};
}
