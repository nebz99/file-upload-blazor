#!/bin/bash

mkdir -p /home/alex/deployment

cd /home/alex/deployment
rm -rf bin
rm -rf obj

git pull 

cd file-upload-blazor
dotnet publish

sudo cp alex-upload.service /etc/systemd/system/alex-upload.service

sudo chmod 700 /etc/systemd/system/alex-upload.service

sudo systemctl daemon-reload

sudo systemctl restart alex-upload


