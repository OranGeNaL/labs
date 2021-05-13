#!/bin/bash

systemctl stop crond.service
echo "$1" >> /etc/crontab
systemctl start crond.service