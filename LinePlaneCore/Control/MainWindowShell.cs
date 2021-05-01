﻿using LinePlaneCore.Control.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace LinePlaneCore.Control
{
    internal class MainWindowShell : Base
    {
        

        #region UserButton
        private Visibility _UserButton = Visibility.Hidden;

        /// <summary>
        /// UserButtonClick
        /// </summary>
        public Visibility UserButton
        {
            get => _UserButton;
            set=> Set(ref _UserButton, value);
        }

        #endregion

        #region CanvasData
        Canvas _MainCanvas;

        public Canvas MainCanvas
        {
            get => _MainCanvas;
            set => Set(ref _MainCanvas, value);
        }

        private List<UIElement> ShapeMemory = new List<UIElement>();
        #endregion

        #region Команды

        #region User Interactions
        #region команда кнопки User
        public ICommand ShowUserPanelCommand { get; }

        private void OnShowUserPanelCommandExecuted(object p)
        {
            if (_UserButton == Visibility.Hidden) UserButton = Visibility.Visible;
            else UserButton = Visibility.Hidden;
            Rectangle a=new Rectangle();
            a.Width = 100;
            a.Height = 1000;
            //CanvasObject.Add(a);
        }

        private bool CanShowUserPanelCommandExecuted(object p) => true;
        #endregion

        #region команда перердачи Canvas
        public ICommand CanvasTransportCommand { get; }

        private void OnCanvasTransportCommandExecuted(object p)
        {
            MainCanvas =(System.Windows.Controls.Canvas) p;
        }

        private bool CanCanvasTransportCommandExecuted(object p) => true;
        #endregion

        #region команды следующее\пердидущее действие

        public ICommand DeleteLastCanvasObjCmommand { get; }

        private void OnDeleteLastCanvasObjExecuted(object p)
        {
            int cnt = _MainCanvas.Children.Count;
            ShapeMemory.Add(_MainCanvas.Children[cnt - 1]);
            _MainCanvas.Children.RemoveAt(cnt - 1);

        }

        private bool CanDeleteLastCanvasObjExecuted(object p) 
        {
            if (_MainCanvas.Children.Count > 0) return true;
            else return false;
        }



        public ICommand BackDeleteCanvasObjCmommand { get; }

        private void OnBackDeleteCanvasObjExecuted(object p)
        {
            _MainCanvas.Children.Add(ShapeMemory[ShapeMemory.Count - 1]);
            ShapeMemory.RemoveAt(ShapeMemory.Count - 1);

        }

        private bool CanBackDeleteCanvasObjExecuted(object p)
        {
            if (ShapeMemory.Count > 0) return true;
            else return false;
        }


        #endregion

        №

        #endregion

        #region команда кнопки Save

        public ICommand SaveCommand { get; }

        private void OnSaveCommandExecuted(object p)
        {
            Microsoft.Win32.SaveFileDialog saveimg = new Microsoft.Win32.SaveFileDialog();



            saveimg.Filter = "(.PNG)|*.PNG|(.JPEG)|*.JPEG ; *.jpg|(.BMP)|*.bmp" +
                "|All Files|*.*";

            saveimg.DefaultExt = saveimg.Filter;

            if (saveimg.ShowDialog() == true)
            {
                LinePlaneCore.Logic.SaveCanvasAsImage.Save(_MainCanvas, saveimg.FileName);
            }
        }

        private bool CanSaveCommandExecuted(object p) => true;

        #endregion

        #region команда спавна предмета

        public ICommand SpawnShapeCommand { get; }

        private void OnSpawnShapeCommandExecuted(object p)
        {
            a = new Draw_Square(widith, height);
        }

        private bool CanSpawnShapeCommandExecuted(object p) => true;

        #endregion


        #endregion

        public MainWindowShell()
        {
            CanvasTransportCommand = new ActionCommand(OnCanvasTransportCommandExecuted, CanCanvasTransportCommandExecuted);

            DeleteLastCanvasObjCmommand = new ActionCommand(OnDeleteLastCanvasObjExecuted, CanDeleteLastCanvasObjExecuted);
            BackDeleteCanvasObjCmommand = new ActionCommand(OnBackDeleteCanvasObjExecuted, CanBackDeleteCanvasObjExecuted);

            #region команда для кнопки User
            ShowUserPanelCommand = new ActionCommand(OnShowUserPanelCommandExecuted, CanShowUserPanelCommandExecuted);
            #endregion

            #region команда кнопки Save
            SaveCommand = new ActionCommand(OnSaveCommandExecuted, CanSaveCommandExecuted);
            #endregion


        }

    }
}
