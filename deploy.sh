#!/bin/bash

cd /home/alex/deployment/file-upload-blazor

rm -rf bin
rm -rf obj
git pull 
dotnet publish

sudo cp alex-upload.service /etc/systemd/system/alex-upload.service

sudo chmod 700 /etc/systemd/system/alex-upload.service

sudo systemctl daemon-reload

sudo systemctl restart alex-upload


