"""
{
  "Events": {
    "Heater": [
      {
        "State": true,
        "Time": "2018-06-05T01:30:00"
      },
      {
        "State": false,
        "Time": "2018-06-05T03:00:00"
      }
    ],
    "Lamps": {
      "1": [
        {
          "State": true,
          "Time": "2018-06-05T03:30:00"
        },
        {
          "State": false,
          "Time": "2018-06-05T07:00:00"
        }
      ],
      "2": [],
      "3": [],
      "4": []
    }
  },
  "Config": {
    "Lamps": [
      {
        "Name": "1",
        "Color": {
          "R": 93,
          "G": 201,
          "B": 140
        }
      },
      {
        "Name": "2",
        "Color": {
          "R": 93,
          "G": 201,
          "B": 140
        }
      },
    ],
    "Limits": {
      "Events": [
        {
          "Selected": true,
          "Time": 5,
          "Name": "Kabel"
        }
      ],
      "Min": 40,
      "Max": 65
    }
  }
}
"""

import logging


log = logging.getLogger('DATA_PARSER')

def getField(data, name):
    try:
        return data[name]
    except KeyError:
        log.error('No "{}" field in JSON!'.format(name))
        return None

def getConfig(data):
    return getField(data, 'Config')

def getEvents(data):
    return getField(data, 'Events')

if __name__ == '__main__':
    main()
