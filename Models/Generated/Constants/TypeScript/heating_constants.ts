export const NS = 'http://messring.de/UA/Heating';

export class BrowseNames {
   static readonly Boost: string = 'Boost'
   static readonly Setpoint: string = 'Setpoint'
   static readonly Temperature: string = 'Temperature'
   static readonly Thermostat: string = 'Thermostat'
   static readonly ThermostatType: string = 'ThermostatType'
}

export class MethodIds {
    static readonly ThermostatType_Boost: string = 'nsu=' + NS + ';i=4'
    static readonly Thermostat_Boost: string = 'nsu=' + NS + ';i=10'
}

export class ObjectIds {
    static readonly Thermostat: string = 'nsu=' + NS + ';i=7'
}

export class ObjectTypeIds {
    static readonly ThermostatType: string = 'nsu=' + NS + ';i=1'
}

export class VariableIds {
    static readonly ThermostatType_Temperature: string = 'nsu=' + NS + ';i=2'
    static readonly ThermostatType_Setpoint: string = 'nsu=' + NS + ';i=3'
    static readonly ThermostatType_Boost_InputArguments: string = 'nsu=' + NS + ';i=5'
    static readonly ThermostatType_Boost_OutputArguments: string = 'nsu=' + NS + ';i=6'
    static readonly Thermostat_Temperature: string = 'nsu=' + NS + ';i=8'
    static readonly Thermostat_Setpoint: string = 'nsu=' + NS + ';i=9'
    static readonly Thermostat_Boost_InputArguments: string = 'nsu=' + NS + ';i=11'
    static readonly Thermostat_Boost_OutputArguments: string = 'nsu=' + NS + ';i=12'
}
