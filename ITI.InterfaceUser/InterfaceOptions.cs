﻿using ITI.GameCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ITI.InterfaceUser
{
    public partial class InterfaceOptions : Form
    {

        public int _rectanglePositionX;
        public int _rectanglePositionY;
        public int _rectangleWidth;
        public int _rectangleHeight;
        public int _nextRectanglePositionX;
        public int _nextRectanglePositionY;
        int _width = 7;
        int _height = 7;

        public bool _frenchLanguages = true;

        public string _formTitle;

        public InterfaceOptions()
        {

        }

        public void setPictureBox(int width, int height)
        {
            #region variable création plateau

            if (width == 7)
            {
                _rectanglePositionX = 3;
                _rectangleWidth = 70;
                _nextRectanglePositionX = 73;
            }
            if (width == 9)
            {
                _rectanglePositionX = 6;
                _rectangleWidth = 53;
                _nextRectanglePositionX = 56;
            }
            if (width == 11)
            {
                _rectanglePositionX = 5;
                _rectangleWidth = 43;
                _nextRectanglePositionX = 46;
            }
            if (width == 13)
            {
                _rectanglePositionX = 5;
                _rectangleWidth = 36;
                _nextRectanglePositionX = 39;
            }
            if (width == 15)
            {
                _rectanglePositionX = 4;
                _rectangleWidth = 31;
                _nextRectanglePositionX = 34;
            }

            if (height == 7)
            {
                _rectanglePositionY = 3;
                _rectangleHeight = 70;
                _nextRectanglePositionY = 73;
            }
            if (height == 9)
            {
                _rectanglePositionY = 6;
                _rectangleHeight = 53;
                _nextRectanglePositionY = 56;
            }
            if (height == 11)
            {
                _rectanglePositionY = 5;
                _rectangleHeight = 43;
                _nextRectanglePositionY = 46;
            }
            if (height == 13)
            {
                _rectanglePositionY = 5;
                _rectangleHeight = 36;
                _nextRectanglePositionY = 39;
            }
            if (height == 15)
            {
                _rectanglePositionY = 4;
                _rectangleHeight = 31;
                _nextRectanglePositionY = 34;

            }
            #endregion
        }

        public void FormTitle()
        {
            if (_frenchLanguages == true)
            {
                _formTitle = ("LA TABLE DE TYR");
                
            }
            else
            {
                _formTitle = ("TYR'S TABLE");
            }
        }

        public string Title
        {
            get { return _formTitle; }
        }

        public int Width
        {
            get { return _width; }
            set { _width = value; }
        }

        public int Height
        {
            get { return _height; }
            set { _height = value; }
        }

        public int RectanglePositionX
        {
            get { return _rectanglePositionX; }
        }

        public int RectanglePositionY
        {
            get { return _rectanglePositionY; }
        }

        public int RectangleWidth
        {
            get { return _rectangleWidth; }
        }

        public int RectangleHeight
        {
            get { return _rectangleHeight; }
        }

        public int NextRectanglePositionX
        {
            get { return _nextRectanglePositionX; }
        }

        public int NextRectanglePositionY
        {
            get { return _nextRectanglePositionY; }
        }

        public bool Languages
        {
            get { return _frenchLanguages; }
            set { _frenchLanguages = value; }

        }
    }
}