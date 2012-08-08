﻿/* **********************************************************************************
 *
 * Copyright (c) TCPX. All rights reserved.
 *
 * This source code is subject to terms and conditions of the Microsoft Public
 * License (Ms-PL). A copy of the license can be found in the license.txt file
 * included in this distribution.
 *
 * You must not remove this notice, or any other, from this software.
 *
 * **********************************************************************************/

using System;
using System.Collections.Generic;
using VPNetExamples.Common.ActionInterpreter.Interfaces;
using VpNetFramework.Common.ActionInterpreter.Interfaces;

namespace VPNetExamples.Common.ActionInterpreter.Triggers
{
    [Serializable]
    [Obsolete("Currently not implemented in this VPNet implementation.")]
    public sealed class ATExitZone : ICommandGroup
    {
        #region ITrigger Members

        public string LiteralAction
        {
            get { return "exit zone"; }
        }

        #endregion

        #region IActionTrigger Members

        public string LiteralCommands
        {
            get;set;
        }

        public List<IActionCommand> Commands
        {
            get;
            set;
        }
        
        #endregion
        
        public string LiteralPart { get; set; }


    }
}
