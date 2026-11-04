export const NS = 'http://messring.de/UA/Heating';

export const BrowseNames = Object.freeze({
   Boost: 'Boost',
   Setpoint: 'Setpoint',
   Temperature: 'Temperature',
   Thermostat: 'Thermostat',
   ThermostatType: 'ThermostatType',
});

export const MethodIds = Object.freeze({
   ThermostatType_Boost: 'nsu=' + NS + ';i=4',
   Thermostat_Boost: 'nsu=' + NS + ';i=10',
});

export const ObjectIds = Object.freeze({
   Thermostat: 'nsu=' + NS + ';i=7',
});

export const ObjectTypeIds = Object.freeze({
   ThermostatType: 'nsu=' + NS + ';i=1',
});

export const VariableIds = Object.freeze({
   ThermostatType_Temperature: 'nsu=' + NS + ';i=2',
   ThermostatType_Setpoint: 'nsu=' + NS + ';i=3',
   ThermostatType_Boost_InputArguments: 'nsu=' + NS + ';i=5',
   ThermostatType_Boost_OutputArguments: 'nsu=' + NS + ';i=6',
   Thermostat_Temperature: 'nsu=' + NS + ';i=8',
   Thermostat_Setpoint: 'nsu=' + NS + ';i=9',
   Thermostat_Boost_InputArguments: 'nsu=' + NS + ';i=11',
   Thermostat_Boost_OutputArguments: 'nsu=' + NS + ';i=12',
});
