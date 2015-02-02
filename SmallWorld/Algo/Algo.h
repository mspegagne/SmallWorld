#ifdef WANTDLLEXP
#define DLL _declspec(dllexport)
#define EXTERNC extern "C"
#else
#define DLL
#define EXTERNC
#endif
#include <vector>
using std::vector;

class DLL Algo{
public:

	DLL static int** buildMap(int size);

	DLL static int* placingPlayer(int size);

	DLL static bool** possibleTileNW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileSW(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileSE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileNE(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTileAll(int x, int y, int bonus, int malus, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleDwarf(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleElf(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleOrc(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleHuman(int x, int y, int size, bool** mapMove, int** mapElement, double defaultMovePts);

	DLL static bool** possibleTile(int type, int x, int y, int size, int** mapElement, double defaultMovePts);

}; 

