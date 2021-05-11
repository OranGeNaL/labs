import os
import shutil

if __name__ == '__main__':
    path_to_dumper = input("Введите путь, куда установить дампер >>> ")
    postgres = input("Введите путь до вашей папки Postgres >>> ")
    base_name = input("Введите название базы для бекапа >>> ")
    time_interval = input("Введите необходимое время выполнения в формате\nminute hour day month dayofweek\n>>> ")

    os.makedirs(path_to_dumper)
    shutil.copytree("baseDumper", path_to_dumper + "/dumper")

    # print("ln -s " + postgres +"/bin/pg_dump " + path_to_dumper + "/dumper/pg_dump")

    os.system("ln -s " + postgres +"/bin/pg_dump " + path_to_dumper + "/dumper/pg_dump")
    # os.system('./write_opener.sh "%s orangenal %s/dumper/venv/bin/python3.9 %s/dumper/main.py %s"' % (time_interval, path_to_dumper, path_to_dumper, base_name))
    os.system('./write_opener.sh "%s orangenal python3.9 %s/dumper/main.py %s"' % (time_interval, path_to_dumper, base_name))

