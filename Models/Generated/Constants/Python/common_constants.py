from enum import Enum

class Namespaces(Enum):
     Uri = "http://messring.de/ua"

class BrowseNames(Enum):
    TemperatureVariableType = "TemperatureVariableType"

class VariableTypeIds(Enum):
    TemperatureVariableType = "nsu=http://messring.de/ua;i=1"

def get_VariableTypeIds_name(value: str) -> str:
    try:
        return VariableTypeIds(value).name
    except ValueError:
        return None

