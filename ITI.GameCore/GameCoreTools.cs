﻿using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ITI.GameCore
{
    //struct for can move to answer
    public struct PossibleMove
    {
        public readonly int X;
        public readonly int Y;
        public readonly List<StudiedPawn> FreeSquares;
        public readonly Pawn Value;
        /// <summary>
        /// Initializes a new instance of the <see cref="PossibleMove" /> struct.
        /// </summary>
        /// <param name="x">The x position of the analyzed pawn.</param>
        /// <param name="y">The y position of the analyzed pawn.</param>
        /// <param name="freeSquares">The free squares.</param>
        /// <param name="value">The value.</param>
        public PossibleMove(int x, int y, List<StudiedPawn> freeSquares, Pawn value)
        {
            X = x;
            Y = y;
            FreeSquares = freeSquares;
            Value = value;
        }
        public bool IsFree
        {
            get { 
                if (FreeSquares.Count == 0) return false;
                return true;
            }
        }
        public int Up
        {
            get { 
                int up = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X == X && value.Y < Y) up++;
                }
                return up;
            }
        }
        public int Down
        {
            get { 
                int down = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X == X && value.Y > Y) down++;
                }
                return down;
            }
        }
        public int Left
        { 
            get { 
                int left = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X < X && value.Y == Y) left++;
                }
                return left;
            }
        }
        public int Right
        {
            get { 
                int right = 0;
                foreach (StudiedPawn value in FreeSquares)
                {
                    if (value.X > X && value.Y == Y) right++;
                }
                return right;
            }
            }
        }

    public struct StudiedPawn
    {
        public readonly int X;
        public readonly int Y;

        public StudiedPawn(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    static public class Helper
    {
        static internal void CheckRange(int width, int height, int x, int y)
        {
            if (x < 0 || x > width) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(x));
            if (y < 0 || y > height) throw new ArgumentOutOfRangeException("Can't aim out of the tafl", nameof(y));

        }

        #region Checkers for emptyness
        /// <summary>
        /// Checks if the pawn above/down/left/right is empty, if so, return true.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        static public bool CheckUp(int x, int y, IReadOnlyTafl _tafl)
        {
            if (y - 1 < 0 || _tafl[x, y - 1] != Pawn.None) return false;
            if (_tafl[x, y - 1] == Pawn.None) return true;
            return false;
        }
        static public bool CheckDown(int x, int y, IReadOnlyTafl _tafl)
        {
            if (y + 1 >= _tafl.Height || _tafl[x, y + 1] != Pawn.None) return false;
            if (_tafl[x, y + 1] == Pawn.None) return true;
            return false;
        }
        static public bool CheckLeft(int x, int y, IReadOnlyTafl _tafl)
        {
            if (x - 1 < 0 || _tafl[x - 1, y] != Pawn.None) return false;
            if (_tafl[x - 1, y] == Pawn.None) return true;
            return false;
        }
        static public bool CheckRight(int x, int y, IReadOnlyTafl _tafl)
        {
            if (x + 1 >= _tafl.Width || _tafl[x + 1, y] != Pawn.None) return false;
            if (_tafl[x + 1, y] == Pawn.None) return true;
            return false;
        }
        #endregion
        /// <summary>
        /// Checks the walls pawn, forteress corner and throne If detected return true.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <returns></returns>
        static public bool CheckWalls(int x, int y, IReadOnlyTafl _tafl) //temp, send that to toolbox;
        {
            if ((_tafl[x, y] == Pawn.Wall)
                || (x == 0 && y == 0)  //Top left corner
                || (x == 0 && y == _tafl.Height - 1) //Bot left corner
                || (x == _tafl.Width - 1 && y == 0)  //top right corner
                || (x == _tafl.Width - 1 && y == _tafl.Height - 1)  //Bot right corner
                || (x == (_tafl.Width - 1) / 2 && y == (_tafl.Height - 1) / 2 && (_tafl[((_tafl.Width - 1) / 2), ((_tafl.Height - 1) / 2)]) == Pawn.None)//Throne only if empty
                ) return true;
            return false;
        }
    }
    public class XML_Tafl
    {
        IReadOnlyTafl _TaflRead;
        TaflBasic _TaflWrite;
        List<XElement> xElements = new List<XElement>();

        internal IReadOnlyTafl TaflToRead { get { return _TaflRead; } private set { _TaflRead = value; } }
        internal TaflBasic TaflToWrite { get { return _TaflWrite; } private set { _TaflWrite = value; } }

        public XML_Tafl()
        { }
        public void CreateBook(IReadOnlyTafl TaflRead)
        {
            _TaflRead = TaflRead;
            //file = new XmlTextReader(Book.title + ".xml");
            XElement map = new XElement("Map",
                new XElement("Title", book.title),
                new XElement("Width", book.height),
                new XElement("Height", book.width),
                Translate()
                );
            map.Save("./" + Book.title + ".xml");
        }
        public List<XElement> Translate()
        {
            for (int i = 0; i < Book.height; i++)
            {
                for (int j = 0; j < Book.width; j++)
                {
                    if (Book.array[i, j] == true)
                    {
                        xElements.Add(new XElement("Tile", "true"));
                    }
                    else if (Book.array[i, j] == false)
                    {
                        xElements.Add(new XElement("Tile", "false"));
                    }
                }
            }
            return xElements;
        }
        public Book ReadBook(string title)
        {
            XmlTextReader reader = new XmlTextReader("./" + title + ".xml");
            Book outbook = new Book();
            outbook.title = Title(reader);
            outbook.width = ArrayWidth(reader);
            outbook.height = ArrayHeight(reader);
            outbook.array = ReadBookArray(reader, outbook.width, outbook.height);
            return outbook;
        }
        public string Title(XmlTextReader xml)
        {
            string title;

            while (xml.Read())
            {
                if (xml.Name == "Title")
                {
                    xml.Read();
                    title = (xml.Value);
                    return title;
                }
            }

            throw new ArgumentException("The XML dosn't contains a title information");
        }
        public int ArrayWidth(XmlTextReader xml)
        {
            int arrayWidth = 0;
            while (xml.Read())
            {
                if (xml.Name == "Width")
                {
                    xml.Read();
                    arrayWidth = Convert.ToInt32(xml.Value);
                    return arrayWidth;
                }
            }

            throw new ArgumentException("The XML dosn't contains a width information");
        }
        public int ArrayHeight(XmlTextReader xml)
        {
            int arrayHeight = 0;
            while (xml.Read())
            {
                if (xml.Name == "Height")
                {
                    xml.Read();
                    arrayHeight = Convert.ToInt32(xml.Value);
                    return arrayHeight;
                }
            }

            throw new ArgumentException("The XML dosn't contains a height information");
        }
        public bool[,] ReadBookArray(XmlTextReader xml, int width, int height)
        {
            int x = 0;
            int y = 0;
            bool[,] tileArray = new bool[width, height];
            if (tileArray == null)
            {
                throw new ArgumentException("The tileArray must not be empty");
            }
            if (xml == null)
            {
                throw new ArgumentException("The XML must not be empty");
            }

            while (xml.Read())
            {
                {
                    if (xml.Name == "Tile")
                    {
                        xml.Read();
                        if (xml.Value == "true")
                        {
                            if (x == width - 1)
                            {
                                tileArray[x, y] = true;
                                x = 0;
                                y++;
                            }
                            else
                            {
                                tileArray[x, y] = true;
                                x++;
                            }
                        }
                        else if (xml.Value == "false")
                        {
                            if (x == width - 1)
                            {
                                tileArray[x, y] = false;
                                x = 0;
                                y++;
                            }
                            else
                            {
                                tileArray[x, y] = false;
                                x++;
                            }
                        }

                    }
                }
            }
            return tileArray;
        }
    }
}
