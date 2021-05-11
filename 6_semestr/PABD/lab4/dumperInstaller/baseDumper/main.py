import psutil
import os
import sys
import datetime

message = ""
location = sys.argv[0][:-7]


def dump():
    filename = location + sys.argv[1] + "_" + datetime.datetime.now().strftime('%Y-%m-%d_%H:%M:%S')
    os.system("./dump.sh " + filename + " " + sys.argv[1])
    return "Dump created with name " + filename


for proc in psutil.process_iter():
    name = proc.name()
    if name == "postgres":
        message = dump()
        break
if message == "":
    message = "Running postgres is not found!"
f = open(location + "dump_log", "a")

f.write(message + " " + location + "\n")
f.close()
