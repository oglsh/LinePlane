﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinePlaneCore.Control.Commands
{
    class ActionCommand: Comands.BaseCommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;
        public ActionCommand(Action<object> Execute, Func<object,bool> CanExecute = null)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        public override void Execute(object parameter) => _Execute(parameter);

    }
}
