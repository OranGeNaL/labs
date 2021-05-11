#!/bin/bash
echo "$1" >> qwe
echo "$2" >> qwe
./pg_dump -Ft -f "$1" "$2"