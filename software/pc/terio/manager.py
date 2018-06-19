import logging
import sys
from time import time
from terio import device, async

class IOManager():
    BUTTON_SUPPRESS_TIME = 2 # seconds
    QUEUE_CHECK_PERIOD = 0.05 # seconds

    def __init__(self):
        """
        Only this thread has access to low level GPIO functions. 
        Pin changes are passed through dedicated queue which is handled in a loop.
        Pin state can be changed once every few seconds. Changing pin state more often will put the newest state into pending mode.
        """

        super(self.__class__, self).__init__()
        self.log = logging.getLogger('IOM_T')
        self.asyncIO = async.AsyncIO(self.QUEUE_CHECK_PERIOD, self.__onRead, self.__onWrite, self.__onStart)
        self.timers = {name: 0 for name in device.getNames()}

    def __onRead(self, data):
        return {name: device.getState(name) for name in data}

    def __onWrite(self, data):
        now = time()
        for io, action in data:
            # add if it doesn't exist
            if not io in self.timers:
                self.timers[io] = 0

            # dump too frequent button changes
            if self.timers[io] + self.BUTTON_SUPPRESS_TIME < now:
                self.log.debug('io: {}, action: {}'.format(io, action))
                self.timers[io] = time()
                device.setState(io, action)

    def __onStart(self):
        self.log.info('IO manager thread started')

    def read(self, ios):
        return self.asyncIO.read(ios)

    def write(self, ios):
        self.asyncIO.write(ios)