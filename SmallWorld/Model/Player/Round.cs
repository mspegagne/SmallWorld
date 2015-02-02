using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wrapper;

namespace Model
{
    [Serializable()]
    public class Round : IRound
    {
        private IGame game;
        private IPlayer Player;
        private int Xdest;
        private int Ydest;
        private int Xselect;
        private int Yselect;
        private IUnit unitSelect;

        public Round(IGame g, IPlayer p)
        {
            this.game = g;
            this.Player = p;
            unitSelect = null;

        }

        //Calcul des pts de mouvements après déplacement
        public void refreshPtsMove(int x, int y)
        {
            //application des bonus
            //Elf
            if (this.unitSelect is ElfUnit)
            {
                if (this.game.getMap().getTile(x, y) is TileForest)
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 0.5);
                }
                else if (this.game.getMap().getTile(x, y) is TileDesert)
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 2);
                }
                else
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 1);
                }
            }
            
            //Orc
            else if (this.unitSelect is OrcUnit)
            {
               
                if (this.game.getMap().getTile(x, y) is TilePlain)
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 0.5);
                }
                else
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 1);
                }
            }

            //Nain
            else if (this.unitSelect is DwarfUnit)
            {
               
                if (this.game.getMap().getTile(x, y) is TilePlain)
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 0.5);
                }
                else
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 1);
                }
            }

            //Human
            else if (this.unitSelect is HumanUnit)
            {

                if (this.game.getMap().getTile(x, y) is TileMountain)
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 0.5);
                }
                else
                {
                    this.unitSelect.setMovePts(this.unitSelect.getMovePts() - 1);
                }
            }
            
        }

        //getter unité selectionné
        public IUnit getUnitSelect()
        {
            return this.unitSelect;
        }

        //selectionner une unité
        public void selectUnit(IUnit u, int x, int y)
        {
            this.unitSelect = u;
            this.Xselect = x;
            this.Yselect = y;

        }

        //selectionner destination
        public void selectDest(int x, int y)
        {
            this.Xdest = x;
            this.Ydest = y;
        }

        // Deselectionne l'unité selectionnée
        public void deselectUnit()
        {
            this.unitSelect = null;
        }

       //deplacement d'une unité
        public string moveUnit()
        {
            string res ="";
            bool empty = true;
            if (this.game.getMap().getTile(this.Xdest, this.Ydest).isTileEnemy(this.Player))
            {
                empty = false;
                if (!this.game.getMap().getTile(this.Xdest, this.Ydest).isTileEnemy(this.Player))
                {
                    empty = true;
                }
            }

            if (empty && movePossible(this.Xdest, this.Ydest))
            {
                this.game.getMap().getTile(this.Xselect, this.Yselect).deleteUnit(this.unitSelect);
                this.game.getMap().getTile(this.Xdest, this.Ydest).addUnit(this.unitSelect);
                refreshPtsMove(this.Xdest, this.Ydest);
                res += "Déplacement sur la case (" + this.Xdest + " - " + this.Ydest + ").\n";
            }

            deselectUnit();
            return res;
        }

        //retourne vrai si déplacement possible
        unsafe public bool movePossible(int x, int y)
        {
            return getMapSuggestion()[x][y];
        }

        unsafe public bool** getMapSuggestion()
        {
            int type = 0;
            if (unitSelect is DwarfUnit)
            {
                type = 1;
            }
            else if (unitSelect is ElfUnit)
            {
                type = 2;
            }
            else if (unitSelect is OrcUnit)
            {
                type = 3;
            }
            else if (unitSelect is HumanUnit)
            {
                type = 4;
            }

            int[][] mapElement = buildMapElement(this.game.getMap().getSize());
            WrapperAlgo wp = new WrapperAlgo();

            bool** mapMove = wp.possible(this.game.getMap().getSize(), this.Xselect, this.Yselect, type, mapElement, unitSelect.getMovePts());
            return mapMove;
        }

        //ajoute les cases à la map
        unsafe public int[][] buildMapElement(int size)
        {
            size = this.game.getMap().getSize();
            int[][] mapElement = new int[size][];
            for (int k = 0; k < size; k++)
            {
                mapElement[k] = new int[size];
            }
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (this.game.getMap().getTile(i, j) is TileDesert)
                    {
                        mapElement[i][j] = 1;
                    }
                    else if (this.game.getMap().getTile(i, j) is TileForest)
                    {
                        mapElement[i][j] = 2;
                    }
                    else if (this.game.getMap().getTile(i, j) is TileMountain)
                    {
                        mapElement[i][j] = 3;
                    }
                    else if (this.game.getMap().getTile(i, j) is TilePlain)
                    {
                        mapElement[i][j] = 4;
                    }
                    else if (this.game.getMap().getTile(i, j) is TileMarsh)
                    {
                        mapElement[i][j] = 5;
                    }
                }
            }
            return mapElement;
        }

    }


        unsafe public interface IRound
        {
            void selectUnit(IUnit u, int x, int y);

            void selectDest(int x, int y);

            string moveUnit();

            bool movePossible(int x, int y);

            void deselectUnit();

            IUnit getUnitSelect();

            int[][] buildMapElement(int size);

            bool** getMapSuggestion();
        }
    }
