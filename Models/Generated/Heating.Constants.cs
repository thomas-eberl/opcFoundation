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
using System.Reflection;
using System.Xml;
using System.Runtime.Serialization;
using Common;
using Opc.Ua;

namespace Common {}

#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable CA1707 // Identifiers should not contain underscores

namespace Heating
{
    #region Method Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Methods
    {
        public const uint ThermostatType_Boost = 4;

        public const uint Thermostat_Boost = 10;
    }
    #endregion

    #region Object Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Objects
    {
        public const uint Thermostat = 7;
    }
    #endregion

    #region ObjectType Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypes
    {
        public const uint ThermostatType = 1;
    }
    #endregion

    #region Variable Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Variables
    {
        public const uint ThermostatType_Temperature = 2;

        public const uint ThermostatType_Setpoint = 3;

        public const uint ThermostatType_Boost_InputArguments = 5;

        public const uint ThermostatType_Boost_OutputArguments = 6;

        public const uint Thermostat_Temperature = 8;

        public const uint Thermostat_Setpoint = 9;

        public const uint Thermostat_Boost_InputArguments = 11;

        public const uint Thermostat_Boost_OutputArguments = 12;
    }
    #endregion

    #region Method Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class MethodIds
    {
        public static readonly ExpandedNodeId ThermostatType_Boost = new ExpandedNodeId(Heating.Methods.ThermostatType_Boost, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId Thermostat_Boost = new ExpandedNodeId(Heating.Methods.Thermostat_Boost, Heating.Namespaces.Heating);
    }
    #endregion

    #region Object Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectIds
    {
        public static readonly ExpandedNodeId Thermostat = new ExpandedNodeId(Heating.Objects.Thermostat, Heating.Namespaces.Heating);
    }
    #endregion

    #region ObjectType Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class ObjectTypeIds
    {
        public static readonly ExpandedNodeId ThermostatType = new ExpandedNodeId(Heating.ObjectTypes.ThermostatType, Heating.Namespaces.Heating);
    }
    #endregion

    #region Variable Node Identifiers
    /// <exclude />
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class VariableIds
    {
        public static readonly ExpandedNodeId ThermostatType_Temperature = new ExpandedNodeId(Heating.Variables.ThermostatType_Temperature, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId ThermostatType_Setpoint = new ExpandedNodeId(Heating.Variables.ThermostatType_Setpoint, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId ThermostatType_Boost_InputArguments = new ExpandedNodeId(Heating.Variables.ThermostatType_Boost_InputArguments, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId ThermostatType_Boost_OutputArguments = new ExpandedNodeId(Heating.Variables.ThermostatType_Boost_OutputArguments, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId Thermostat_Temperature = new ExpandedNodeId(Heating.Variables.Thermostat_Temperature, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId Thermostat_Setpoint = new ExpandedNodeId(Heating.Variables.Thermostat_Setpoint, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId Thermostat_Boost_InputArguments = new ExpandedNodeId(Heating.Variables.Thermostat_Boost_InputArguments, Heating.Namespaces.Heating);

        public static readonly ExpandedNodeId Thermostat_Boost_OutputArguments = new ExpandedNodeId(Heating.Variables.Thermostat_Boost_OutputArguments, Heating.Namespaces.Heating);
    }
    #endregion

    #region BrowseName Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class BrowseNames
    {
        public const string Boost = "Boost";

        public const string Setpoint = "Setpoint";

        public const string Temperature = "Temperature";

        public const string Thermostat = "Thermostat";

        public const string ThermostatType = "ThermostatType";
    }
    #endregion

    #region Namespace Declarations
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Opc.Ua.ModelCompiler", "1.0.0.0")]
    [System.Diagnostics.CodeAnalysis.ExcludeFromCodeCoverageAttribute()]
    public static partial class Namespaces
    {
        /// <summary>
        /// The URI for the Heating namespace (.NET code namespace is 'Heating').
        /// </summary>
        public const string Heating = "http://messring.de/ua/Heating";

        /// <summary>
        /// The URI for the HeatingXsd namespace (.NET code namespace is 'Heating').
        /// </summary>
        public const string HeatingXsd = "http://messring.de/ua/Heating/Types.xsd";

        /// <summary>
        /// The URI for the Common namespace (.NET code namespace is 'Common').
        /// </summary>
        public const string Common = "http://messring.de/ua";

        /// <summary>
        /// The URI for the CommonXsd namespace (.NET code namespace is 'Common').
        /// </summary>
        public const string CommonXsd = "http://messring.de/ua/Types.xsd";

        /// <summary>
        /// The URI for the OpcUa namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUa = "http://opcfoundation.org/UA/";

        /// <summary>
        /// The URI for the OpcUaXsd namespace (.NET code namespace is 'Opc.Ua').
        /// </summary>
        public const string OpcUaXsd = "http://opcfoundation.org/UA/2008/02/Types.xsd";
    }
    #endregion
}