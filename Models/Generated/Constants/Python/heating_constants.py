from enum import Enum

class Namespaces(Enum):
     Uri = "http://messring.de/UA/Heating"

class BrowseNames(Enum):
    Boost = "Boost"
    Setpoint = "Setpoint"
    Temperature = "Temperature"
    Thermostat = "Thermostat"
    ThermostatType = "ThermostatType"

class MethodIds(Enum):
    ThermostatType_Boost = "nsu=http://messring.de/UA/Heating;i=4"
    Thermostat_Boost = "nsu=http://messring.de/UA/Heating;i=10"

def get_MethodIds_name(value: str) -> str:
    try:
        return MethodIds(value).name
    except ValueError:
        return None


class ObjectIds(Enum):
    Thermostat = "nsu=http://messring.de/UA/Heating;i=7"

def get_ObjectIds_name(value: str) -> str:
    try:
        return ObjectIds(value).name
    except ValueError:
        return None


class ObjectTypeIds(Enum):
    ThermostatType = "nsu=http://messring.de/UA/Heating;i=1"

def get_ObjectTypeIds_name(value: str) -> str:
    try:
        return ObjectTypeIds(value).name
    except ValueError:
        return None


class VariableIds(Enum):
    ThermostatType_Temperature = "nsu=http://messring.de/UA/Heating;i=2"
    ThermostatType_Setpoint = "nsu=http://messring.de/UA/Heating;i=3"
    ThermostatType_Boost_InputArguments = "nsu=http://messring.de/UA/Heating;i=5"
    ThermostatType_Boost_OutputArguments = "nsu=http://messring.de/UA/Heating;i=6"
    Thermostat_Temperature = "nsu=http://messring.de/UA/Heating;i=8"
    Thermostat_Setpoint = "nsu=http://messring.de/UA/Heating;i=9"
    Thermostat_Boost_InputArguments = "nsu=http://messring.de/UA/Heating;i=11"
    Thermostat_Boost_OutputArguments = "nsu=http://messring.de/UA/Heating;i=12"

def get_VariableIds_name(value: str) -> str:
    try:
        return VariableIds(value).name
    except ValueError:
        return None

