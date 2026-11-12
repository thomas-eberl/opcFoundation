#pragma warning disable CA1707 // Identifiers should not contain underscores
#pragma warning disable CA1515 // Types can be made internal

namespace Heating.WebApi
{
    /// <summary>
    /// The namespaces used in the model.
    /// </summary>
    public static class Namespaces
    {
        /// <remarks />
        public const string Uri = "http://messring.de/ua/Heating";
    }

    /// <summary>
    /// The browse names defined in the model.
    /// </summary>
    public static class BrowseNames
    {
        /// <remarks />
        public const string Boost = "Boost";
        /// <remarks />
        public const string Setpoint = "Setpoint";
        /// <remarks />
        public const string Temperature = "Temperature";
        /// <remarks />
        public const string Thermostat = "Thermostat";
        /// <remarks />
        public const string ThermostatType = "ThermostatType";
    }

    /// <summary>
    /// The well known identifiers for Method nodes.
    /// </summary>
    public static class MethodIds {
        /// <remarks />
        public const string ThermostatType_Boost = "nsu=" + Namespaces.Uri + ";i=4";
        /// <remarks />
        public const string Thermostat_Boost = "nsu=" + Namespaces.Uri + ";i=10";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(MethodIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value?.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Object nodes.
    /// </summary>
    public static class ObjectIds {
        /// <remarks />
        public const string Thermostat = "nsu=" + Namespaces.Uri + ";i=7";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(ObjectIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value?.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for ObjectType nodes.
    /// </summary>
    public static class ObjectTypeIds {
        /// <remarks />
        public const string ThermostatType = "nsu=" + Namespaces.Uri + ";i=1";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(ObjectTypeIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value?.ToString();
        }
    }

    /// <summary>
    /// The well known identifiers for Variable nodes.
    /// </summary>
    public static class VariableIds {
        /// <remarks />
        public const string ThermostatType_Temperature = "nsu=" + Namespaces.Uri + ";i=2";
        /// <remarks />
        public const string ThermostatType_Setpoint = "nsu=" + Namespaces.Uri + ";i=3";
        /// <remarks />
        public const string ThermostatType_Boost_InputArguments = "nsu=" + Namespaces.Uri + ";i=5";
        /// <remarks />
        public const string ThermostatType_Boost_OutputArguments = "nsu=" + Namespaces.Uri + ";i=6";
        /// <remarks />
        public const string Thermostat_Temperature = "nsu=" + Namespaces.Uri + ";i=8";
        /// <remarks />
        public const string Thermostat_Setpoint = "nsu=" + Namespaces.Uri + ";i=9";
        /// <remarks />
        public const string Thermostat_Boost_InputArguments = "nsu=" + Namespaces.Uri + ";i=11";
        /// <remarks />
        public const string Thermostat_Boost_OutputArguments = "nsu=" + Namespaces.Uri + ";i=12";

        /// <summary>
        /// Converts a value to a name for display.
        /// </summary>
        public static string ToName(string value)
        {
            foreach (var field in typeof(VariableIds).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                if (field.GetValue(null).Equals(value))
                {
                    return field.Name;
                }
            }

            return value?.ToString();
        }
    }
    
}