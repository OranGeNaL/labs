#!/bin/bash

export PATH=${PATH}:$HOME/Post/bin/

name="PABD"

d=$(date +%Y-%m-%d)
t=$(date +%T)
var_backup="${name}_${d}_${t}"

#pg_ctl -D $HOME/SERVER start
pg_dump -Fc -U orangenal ${name} | gzip > $HOME/${var_backup}.gz
#pg_ctl -D $HOME/SERVER stop
