/* ========================================================================
 * Copyright (c) 2005-2024 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 *
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 *
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Threading;
using Common;
using Opc.Ua;

namespace Common {}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1515 // Consider making public types internal
#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1028 // Enum Storage should be Int32

namespace Heating
{
    #region ThermostatState Class
    #if (!OPCUA_EXCLUDE_ThermostatState)
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public partial class ThermostatState : BaseObjectState
    {
        #region Constructors
        public ThermostatState(NodeState parent) : base(parent)
        {
        }

        protected override NodeId GetDefaultTypeDefinitionId(NamespaceTable namespaceUris)
        {
            return Opc.Ua.NodeId.Create(Heating.ObjectTypes.ThermostatType, Heating.Namespaces.Heating, namespaceUris);
        }

        #if (!OPCUA_EXCLUDE_InitializationStrings)
        protected override void Initialize(ISystemContext context)
        {
            base.Initialize(context);
            Initialize(context, InitializationString);
            InitializeOptionalChildren(context);
        }

        protected override void Initialize(ISystemContext context, NodeState source)
        {
            InitializeOptionalChildren(context);
            base.Initialize(context, source);
        }

        protected override void InitializeOptionalChildren(ISystemContext context)
        {
            base.InitializeOptionalChildren(context);
        }

        #region Initialization String
        private const string InitializationString =
           "AgAAAB0AAABodHRwOi8vbWVzc3JpbmcuZGUvVUEvSGVhdGluZxUAAABodHRwOi8vbWVzc3JpbmcuZGUv" +
           "dWH/////BGCAAgEAAAABABYAAABUaGVybW9zdGF0VHlwZUluc3RhbmNlAQEBAAEBAQABAAAA/////wMA" +
           "AAA1YIkKAgAAAAEACwAAAFRlbXBlcmF0dXJlAQECAAMAAAAALAAAAFRoZSBtZWFzdXJlZCB0ZW1wZXJh" +
           "dHVyZSBpbiBkZWdyZWVzIENlbHNpdXMuAC8BAgEAAgAAAAAL/////wEB/////wAAAAA1YIkKAgAAAAEA" +
           "CAAAAFNldHBvaW50AQEDAAMAAAAAOAAAAFRoZSB0YXJnZXQgdGVtcGVyYXR1cmUgaW4gZGVncmVlcyBD" +
           "ZWxzaXVzLCBmcm9tIDUgdG8gMzAuAC8APwMAAAAAC/////8DA/////8AAAAAJGGCCgQAAAABAAUAAABC" +
           "b29zdAEBBAADAAAAADEAAABSYWlzZXMgdGhlIHNldHBvaW50IGFuZCByZXR1cm5zIHRoZSBuZXcgc2V0" +
           "cG9pbnQuAC8BAQQABAAAAAEB/////wIAAAAXYKkKAgAAAAAADgAAAElucHV0QXJndW1lbnRzAQEFAAAu" +
           "AEQFAAAAlgEAAAABACoBAUsAAAAHAAAARGVncmVlcwAL/////wAAAAADAAAAAC0AAABUaGUgbnVtYmVy" +
           "IG9mIGRlZ3JlZXMgdG8gYWRkIHRvIHRoZSBzZXRwb2ludC4BACgBAQAAAAEAAAAAAAAAAQH/////AAAA" +
           "ABdgqQoCAAAAAAAPAAAAT3V0cHV0QXJndW1lbnRzAQEGAAAuAEQGAAAAlgEAAAABACoBARoAAAALAAAA" +
           "TmV3U2V0cG9pbnQAC/////8AAAAAAAEAKAEBAAAAAQAAAAAAAAABAf////8AAAAA";
        #endregion
        #endif
        #endregion

        #region Public Properties
        public TemperatureVariableState<double> Temperature
        {
            get => m_temperature;

            set
            {
                if (!Object.ReferenceEquals(m_temperature, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_temperature = value;
            }
        }

        public BaseDataVariableState<double> Setpoint
        {
            get => m_setpoint;

            set
            {
                if (!Object.ReferenceEquals(m_setpoint, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_setpoint = value;
            }
        }

        public BoostMethodState Boost
        {
            get => m_boostMethod;

            set
            {
                if (!Object.ReferenceEquals(m_boostMethod, value))
                {
                    ChangeMasks |= NodeStateChangeMasks.Children;
                }

                m_boostMethod = value;
            }
        }
        #endregion

        #region Overridden Methods
        public override void GetChildren(
            ISystemContext context,
            IList<BaseInstanceState> children)
        {
            if (m_temperature != null)
            {
                children.Add(m_temperature);
            }

            if (m_setpoint != null)
            {
                children.Add(m_setpoint);
            }

            if (m_boostMethod != null)
            {
                children.Add(m_boostMethod);
            }

            base.GetChildren(context, children);
        }
            
        protected override void RemoveExplicitlyDefinedChild(BaseInstanceState child)
        {
            if (Object.ReferenceEquals(m_temperature, child))
            {
                m_temperature = null;
                return;
            }

            if (Object.ReferenceEquals(m_setpoint, child))
            {
                m_setpoint = null;
                return;
            }

            if (Object.ReferenceEquals(m_boostMethod, child))
            {
                m_boostMethod = null;
                return;
            }

            base.RemoveExplicitlyDefinedChild(child);
        }

        protected override BaseInstanceState FindChild(
            ISystemContext context,
            QualifiedName browseName,
            bool createOrReplace,
            BaseInstanceState replacement)
        {
            if (QualifiedName.IsNull(browseName))
            {
                return null;
            }

            BaseInstanceState instance = null;

            switch (browseName.Name)
            {
                case Heating.BrowseNames.Temperature:
                {
                    if (createOrReplace)
                    {
                        if (Temperature == null)
                        {
                            if (replacement == null)
                            {
                                Temperature = new TemperatureVariableState<double>(this);
                            }
                            else
                            {
                                Temperature = (TemperatureVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = Temperature;
                    break;
                }

                case Heating.BrowseNames.Setpoint:
                {
                    if (createOrReplace)
                    {
                        if (Setpoint == null)
                        {
                            if (replacement == null)
                            {
                                Setpoint = new BaseDataVariableState<double>(this);
                            }
                            else
                            {
                                Setpoint = (BaseDataVariableState<double>)replacement;
                            }
                        }
                    }

                    instance = Setpoint;
                    break;
                }

                case Heating.BrowseNames.Boost:
                {
                    if (createOrReplace)
                    {
                        if (Boost == null)
                        {
                            if (replacement == null)
                            {
                                Boost = new BoostMethodState(this);
                            }
                            else
                            {
                                Boost = (BoostMethodState)replacement;
                            }
                        }
                    }

                    instance = Boost;
                    break;
                }
            }

            if (instance != null)
            {
                return instance;
            }

            return base.FindChild(context, browseName, createOrReplace, replacement);
        }
        #endregion

        #region Private Fields
        private TemperatureVariableState<double> m_temperature;
        private BaseDataVariableState<double> m_setpoint;
        private BoostMethodState m_boostMethod;
        #endregion
    }
    #endif
    #endregion
}