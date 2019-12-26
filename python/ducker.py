import serial
import termios
import fcntl
import os
import time
import smtplib

SERIAL_PORT='/dev/ttyACM0'
BAUD_RATE=9600

print(serial)
arduino = serial.Serial(SERIAL_PORT, BAUD_RATE, timeout=.1)

keepAlive = True

#Ignore junk buffer
arduino.readline()

while (keepAlive):

    msg = arduino.readline()
    if (len(msg)!=0):
        print(">>Sup.")
        arduino.write("Sup.")
        continue
        
    s = ""
    for c in msg:
        s += chr(c)
    if (len(s)!=0):
        print('<<'+s)