using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp;
using Model;

namespace WpfApp
{
    class FabriqueImage
    {
        private BitmapImage caseDesert = null;
        private BitmapImage caseForet = null;
        private BitmapImage caseMontagne = null;
        private BitmapImage casePlaine = null;
        private BitmapImage caseMarais = null;
        private BitmapImage nain = null;
        private BitmapImage elf = null;
        private BitmapImage orc = null;
        private BitmapImage humain = null;
        private BitmapImage select = null;
        private BitmapImage suggere = null;


        private static FabriqueImage INSTANCE = new FabriqueImage();

        private FabriqueImage()
        {
            this.caseDesert = new BitmapImage(new Uri("../../Resources/desert.png", UriKind.Relative));
            this.caseForet = new BitmapImage(new Uri("../../Resources/forest.png", UriKind.Relative));
            this.caseMontagne = new BitmapImage(new Uri("../../Resources/mountain.png", UriKind.Relative));
            this.caseMarais = new BitmapImage(new Uri("../../Resources/marsh.png", UriKind.Relative));
            this.casePlaine = new BitmapImage(new Uri("../../Resources/plain.png", UriKind.Relative));


            this.nain = new BitmapImage(new Uri("../../Resources/p_dwarf.png", UriKind.Relative));
            this.elf = new BitmapImage(new Uri("../../Resources/p_elf.png", UriKind.Relative));
            this.orc = new BitmapImage(new Uri("../../Resources/p_orc.png", UriKind.Relative));
            this.humain = new BitmapImage(new Uri("../../Resources/p_human.png", UriKind.Relative));

            this.select = new BitmapImage(new Uri("../../Resources/selectionNoire.png", UriKind.Relative));
            this.suggere = new BitmapImage(new Uri("../../Resources/selectionGrise.png", UriKind.Relative));

        }

        public static FabriqueImage getInstance()
        {
            return INSTANCE;
        }

        public Brush getSuggere()
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = this.suggere;
            return brush;
        }
        public Brush getSelection(bool b)
        {
            ImageBrush brush = new ImageBrush();
            brush.ImageSource = this.select;
            return brush;
        }
        public Brush getBrushCase(ITile c)
        {
            ImageBrush brush = new ImageBrush();
            if (c is TileDesert)
            {
                brush.ImageSource = this.caseDesert;
            }
            else if (c is TileForest)
            {
                brush.ImageSource = this.caseForet;
            }
            else if (c is TileMountain)
            {
                brush.ImageSource = this.caseMontagne;
            }
            else if (c is TilePlain)
            {
                brush.ImageSource = this.casePlaine;
            }
            else if (c is TileMarsh)
            {
                brush.ImageSource = this.caseMarais;
            }
            return brush;
        }

        public Brush getBrushUnite(IUnit u)
        {
            ImageBrush brush = new ImageBrush();
            if (u is DwarfUnit)
            {
                    brush.ImageSource = this.nain;   
            }
            else if (u is ElfUnit)
            {
                    brush.ImageSource = this.elf;

            }
            else if (u is OrcUnit)
            {
                    brush.ImageSource = this.orc;
            }
            else if (u is HumanUnit)
            {
                    brush.ImageSource = this.humain;
            }
            return brush;
        }

    }
}