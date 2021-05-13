#!/bin/bash
#echo "$1" >> $3/qwe
#echo "$2" >> $3/qwe
$3/pg_dump -Ft -f "$1" "$2"