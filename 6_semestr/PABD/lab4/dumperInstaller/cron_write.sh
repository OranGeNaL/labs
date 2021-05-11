#!/bin/bash

echo "$1" >> /etc/crontab
systemctl stop crond.service
systemctl start crond.service